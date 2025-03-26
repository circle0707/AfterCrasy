using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class finalBoss : MonoBehaviour
{
    [Header("�⺻����")]
    Rigidbody ri;
    Animator animer;
    public int EnemyHp;
    [SerializeField] float EnemySpeed;
    [SerializeField] GameObject target;

    [Header("bool ����")]
    bool samangSound = true;
    bool canMove = false;
    public bool canHit = false;

    [Header("������Ʈ��")]
    [SerializeField] GameObject uselyBull;
    [SerializeField] GameObject BangBull1;
    [SerializeField] GameObject BangBull2;
    [SerializeField] GameObject BangBull3;
    [SerializeField] GameObject BangBull4;
    [SerializeField] GameObject BangBull5;
    [SerializeField] GameObject emperor;
    [SerializeField] GameObject Blood;

    [SerializeField] GameObject pos;
    [SerializeField] GameObject pos2;
    [SerializeField] GameObject meat;

    [Header("���� ������Ʈ")]
    [SerializeField] GameObject WaOwa;
    [SerializeField] GameObject yuiHIHIHI;
    [SerializeField] GameObject AAA;
    [SerializeField] GameObject ait;

    void Start()
    {
        ri = GetComponent<Rigidbody>();
        animer = GetComponent<Animator>();
        target = GameObject.Find("Player");

        StartCoroutine(Battle());//���� �ڷ�ƾ
    }

    void Update()
    {
        panByeol_HP();
        Moving();
    }

#region �ڷ�ƾ
    IEnumerator Battle()
    {
        while (true)
        {
            ri.velocity = ri.velocity;
            animeOFF();
            canMove = true;
            walking();
            yield return new WaitForSeconds(1.5f);
            FaceToPlayer();
            yield return new WaitForSeconds(1.5f);
            FaceToPlayer();
            yield return new WaitForSeconds(1.5f);

            canMove = false;
            attack1();
            Instantiate(uselyBull, pos.transform.position, pos.transform.rotation);
            yield return new WaitForSeconds(1);
            Instantiate(uselyBull, pos.transform.position, pos.transform.rotation);
            yield return new WaitForSeconds(1);

            canMove = true;
            walking();
            yield return new WaitForSeconds(1.5f);
            FaceToPlayer();
            yield return new WaitForSeconds(1.5f);
            FaceToPlayer();
            yield return new WaitForSeconds(1.5f);

            canMove = false;
            attack2();
            Instantiate(BangBull1, pos2.transform.position , pos2.transform.rotation);
            Instantiate(BangBull2, pos2.transform.position , pos2.transform.rotation);
            Instantiate(BangBull3, pos2.transform.position , pos2.transform.rotation);
            Instantiate(BangBull4, pos2.transform.position , pos2.transform.rotation);
            Instantiate(BangBull5, pos2.transform.position , pos2.transform.rotation);
            yield return new WaitForSeconds(1);
            Instantiate(emperor, pos2.transform.position, pos2.transform.rotation);

            canMove = true;
            S_yuiHIHIHI();
            walking();
            yield return new WaitForSeconds(1.5f);
            FaceToMeat();
            yield return new WaitForSeconds(1.5f);
            FaceToMeat();
            yield return new WaitForSeconds(1.5f);
            FaceToMeat();
            yield return new WaitForSeconds(1.5f);
            FaceToMeat();
            yield return new WaitForSeconds(1.5f);

            canMove = false;
            Cossack();
            canHit = true;
            yield return new WaitForSeconds(5);
            canHit = false;

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
    #endregion

#region Ȱ��
    void Moving()
    {
        if (canMove == true)
        {
            Vector3 vel = transform.forward / 1.2f * EnemySpeed;
            vel.y = ri.velocity.y;
            ri.velocity = vel;
        }
    }

    void FaceToPlayer()
    {
        Vector3 dir = target.transform.position - transform.position; dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir.normalized);

        // ���� ������ 
        transform.rotation = rot;
    }
    void FaceToMeat()
    {
        Vector3 dir1 = target.transform.position - transform.position; dir1.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir1.normalized);

        // ���� ������ 
        transform.rotation = rot;
    }

    #endregion

#region �ִϸ��̼�
    void walking()
    {
        FaceToPlayer();
        animeOFF();
        animer.SetBool("walk", true);
    }

    void attack1()
    {
        FaceToPlayer();
        animeOFF();
        animer.SetBool("attack", true);
        S_WaOwa();
    }
    void attack2()
    {
        FaceToPlayer();
        animeOFF();
        animer.SetBool("attack", true);
        S_WaOwa();
    }
    void Cossack()
    {
        animeOFF();
        animer.SetBool("koshark", true);
    }

    public void stun()
    {
        animeOFF();
        animer.SetBool("stun", true);
        S_AAA();
    }

    void animeOFF()
    {
        animer.SetBool("walk", false);
        animer.SetBool("attack", false);
        animer.SetBool("koshark", false);
        animer.SetBool("stun", false);
    }
    #endregion

#region �Ǻ�
    void panByeol_HP()
    {
        if (EnemyHp <= 0)
        {
            if (samangSound == true)
            {
                S_ait();
            }
            samangSound = false;
            Instantiate(Blood, this.transform.position, this.transform.rotation);
            StopCoroutine(Battle());
            animeOFF();
            StartCoroutine(up());
            Invoke("DIE", 5f);
        }
    }
    void DIE()
    {
        SceneManager.LoadScene("end");
    }
    #endregion

#region �Ҹ�
    void S_WaOwa()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(WaOwa, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 1f);
    }
    void S_yuiHIHIHI()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(yuiHIHIHI, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 2.3f);
    }
    void S_AAA()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(AAA, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 2f);
    }
    void S_ait()
    {
        //���������� �ı� ������ ���� ����
        var copy = Instantiate(ait, this.transform.position, this.transform.rotation);
        //���� ������ �ı��� �ƴ�, ����� ������Ʈ �ı�
        Destroy(copy, 5f);
    }
    #endregion


}
