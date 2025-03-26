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



    // �Ѿ˸���
    [SerializeField] private GameObject bull;

    [Header("���� ������Ʈ")]
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
        if (FindRay == true)//�÷��̾� ����
        {
            FaceToPlayer();
            Attack();
        }
        if (FindRay == false)//�÷��̾� �Ȱ���
        {
            FaceToPlayer();
            moving();
        }
    }

    void FaceToPlayer()
    {
        // ���� ���ϱ� 
        // ���� ���Ͱ� = ��ǥ ���� - ���� ����
        Vector3 dir = target.transform.position - transform.position; dir.y = 0f;

        // ������ ���ʹϾ� �� ���ϱ� 
        // ���ʹϾ� �� = ���ʹϾ� ���� ��(���� ����) 
        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        // ���� ������ 
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
            S_OHoOHo();//Ȯ���� ���� �Ҹ����
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

    //�Ҹ�
    void S_ngOOK()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(ngOOK, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 3f);
    }
    void S_OHoOHo()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(OHoOHo, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 1f);
    }

    void S_OhaOhaOhaOha()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(OhaOhaOhaOha, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 3f);
    }
}
