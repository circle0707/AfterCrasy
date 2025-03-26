using UnityEngine;

public class KingWoman : Event1_3Mana
{
    bool samangSound = true;
    Rigidbody ri;
    Animator animer;

    [SerializeField] int EnemyHp;
    [SerializeField] GameObject target;
    [SerializeField] float EnemySpeed;
    bool FindRay;
    bool canBull = true;



    // 총알모음
    [SerializeField] private GameObject bull;

    [Header("사운드 오브젝트")]
    [SerializeField] GameObject ngOOK;
    [SerializeField] GameObject OHoOHo;
    [SerializeField] GameObject OhaOhaOhaOha;

    void Start()
    {
        ri = GetComponent<Rigidbody>();
        animer = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        panByeol_HP();
        RayToPlayer();
        if (FindRay == true)//플레이어 감지
        {
            FaceToPlayer();
            Attack();
        }
        if (FindRay == false)//플레이어 안감지
        {
            FaceToPlayer();
            moving();
        }
    }

    void FaceToPlayer()
    {
        // 방향 구하기 
        // 방향 벡터값 = 목표 벡터 - 시작 벡터
        Vector3 dir = target.transform.position - transform.position; dir.y = 0f;

        // 방향의 쿼터니언 값 구하기 
        // 쿼터니언 값 = 쿼터니언 방향 값(방향 백터) 
        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        // 방향 돌리기 
        transform.rotation = rot;
    }
    void RayToPlayer()
    {
        Vector3 dir = target.transform.position - transform.position; dir.y = 0f;
        FindRay = Physics.Raycast(ri.position, dir.normalized, 20, LayerMask.GetMask("Player"));
        Debug.DrawRay(ri.position, dir.normalized * 10, Color.red);
    }

    void moving()
    {
        animer.SetBool("attack", false);
        Vector3 vel = transform.forward * EnemySpeed;
        vel.y = ri.velocity.y;
        ri.velocity = vel;
        /*transform.position += transform.forward * EnemySpeed * Time.deltaTime;*/
        int ran = Random.Range(0, 4000);
        if (ran == 5)
        {
            S_OHoOHo();//확률에 따른 소리재생
        }
    }

    void Attack()
    {
        if (canBull == true)
        {
            animer.SetBool("attack", true);
            S_ngOOK();
            Instantiate(bull, this.transform.position, this.transform.rotation);
            canBull = false;
            Invoke("anime", 0.6f);
        }
    }
    void anime()
    {
        animer.SetBool("attack", false);
        canBull = true;
    }

    //HP
    void panByeol_HP()
    {
        if (EnemyHp <= 0)
        {
            if (samangSound == true)
            {
                S_OhaOhaOhaOha();
            }
            samangSound = false;
            Destroy(gameObject);
            GameManager.instance.Event1_3kill = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerSBull")
        {
            EnemyHp -= 10;
        }
        if (collision.gameObject.tag == "PlayerGBull")
        {
            EnemyHp -= 30;
        }
    }

    //소리
    void S_ngOOK()
    {
        //원본프리펩 파괴 방지를 위한 복사
        var copy = Instantiate(ngOOK, this.transform.position, this.transform.rotation);
        //원본 프리펩 파괴가 아닌, 복사된 오브젝트 파괴
        Destroy(copy, 3f);
    }
    void S_OHoOHo()
    {
        //원본프리펩 파괴 방지를 위한 복사
        var copy = Instantiate(OHoOHo, this.transform.position, this.transform.rotation);
        //원본 프리펩 파괴가 아닌, 복사된 오브젝트 파괴
        Destroy(copy, 1f);
    }

    void S_OhaOhaOhaOha()
    {
        //원본프리펩 파괴 방지를 위한 복사
        var copy = Instantiate(OhaOhaOhaOha, this.transform.position, this.transform.rotation);
        //원본 프리펩 파괴가 아닌, 복사된 오브젝트 파괴
        Destroy(copy, 3f);
    }
}
