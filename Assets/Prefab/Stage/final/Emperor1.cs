using System.Collections;
using UnityEngine;

public class Emperor : MonoBehaviour
{
    bool samangSound = true;
    Rigidbody ri;
    Animator animer;
    bool canMove = false;
    [SerializeField] private GameObject bull;

    [SerializeField] int EnemyHp;
    [SerializeField] GameObject target;
    [SerializeField] GameObject shild;
    [SerializeField] GameObject pos;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject women;
    [SerializeField] float EnemySpeed;
    [SerializeField] GameObject Blood;

    [Header("���� ������Ʈ")]
    [SerializeField] GameObject OhaOhaOhaOha;
    [SerializeField] GameObject suckTion;
    [SerializeField] GameObject minoz;
    // Start is called before the first frame update
    void Start()
    {
        ri = GetComponent<Rigidbody>();
        animer = GetComponent<Animator>();
        target = GameObject.Find("Player");

        StartCoroutine(Skill());
    }
    IEnumerator Skill()
    {
        while (true)
        {
            ri.velocity = ri.velocity;
            animeOff();
            yield return new WaitForSeconds(3);
            attack1();
            yield return new WaitForSeconds(2);
            animeOff();
            yield return new WaitForSeconds(2);
            canMove = true;
            walk();
            yield return new WaitForSeconds(5);
            attack2();
            yield return new WaitForSeconds(3);
            canMove = false;
            animeOff();
            yield return new WaitForSeconds(1.5f);
            attack1();
            yield return new WaitForSeconds(2);
        }
    }
    IEnumerator up()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);
            transform.position += Vector3.up / 9;
        }

    }

    void Update()
    {
        panByeol_HP();
        Moving();
    }
    void Moving()
    {
        if (canMove == true)
        {
            Vector3 vel = transform.forward / 1.2f * EnemySpeed;
            vel.y = ri.velocity.y;
            ri.velocity = vel;
        }
    }

    void attack1()
    {
        S_OhaOhaOhaOha();
        FaceToPlayer();
        animeOff();
        Instantiate(bull, this.transform.position += new Vector3(0, 15, 0), this.transform.rotation);
        animer.SetBool("attack1", true);

    }

    void attack2()
    {
        FaceToPlayer();
        animeOff();
        animer.SetBool("attack2", true);
        Invoke("AddShild", 0.8f);
        Invoke("SpawnWomen", 1f);
        S_suckTion();
        ri.AddForce(((transform.forward * 5) + (transform.up / 9)) * EnemySpeed * 2f, ForceMode.Impulse);
    }
    void walk()
    {
        FaceToPlayer();
        animeOff();
        animer.SetBool("walk", true);
    }

    void animeOff()
    {
        animer.SetBool("attack1", false);
        animer.SetBool("attack2", false);
        animer.SetBool("walk", false);
    }

    void FaceToPlayer()
    {
        Vector3 dir = target.transform.position - transform.position; dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        // ���� ������ 
        transform.rotation = rot;
    }

    void AddShild()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(shild, pos.transform.position, pos.transform.rotation);//.transform.parent = parent.transform;
        copy.transform.parent = parent.transform;
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 3f);
    }

    void SpawnWomen()
    {
        Instantiate(women, this.transform.position, this.transform.rotation);
        Instantiate(women, this.transform.position, this.transform.rotation);
    }

    void panByeol_HP()
    {
        if (EnemyHp <= 0)
        {
            if (samangSound == true)
            {
                S_minoz();
            }
            samangSound = false;
            Instantiate(Blood, this.transform.position, this.transform.rotation).transform.parent = parent.transform;
            StopCoroutine(Skill());
            animeOff();
            StartCoroutine(up());
            Destroy(gameObject, 5f);
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
    void S_OhaOhaOhaOha()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(OhaOhaOhaOha, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 3f);
    }
    void S_suckTion()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(suckTion, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 2f);
    }
    void S_minoz()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(minoz, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 5f);
    }
}
