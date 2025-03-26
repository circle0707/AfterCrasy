using UnityEngine;

[System.Serializable]//������ Sound�� �ν����Ϳ� ����
public class Sound //�� �����
{
    public string soundName;
    public AudioClip clip;
}

public class Gun : MonoBehaviour
{
    [SerializeField] Player player;//�÷��̾�̽�!~~~
    [SerializeField] private Transform FPos;//�Ѿ� ��������

    //�ӽð��Ѿ�
    [SerializeField] private GameObject ImBull1;
    [SerializeField] private GameObject ImBull2;
    [SerializeField] private GameObject ImBull3;
    [SerializeField] private GameObject ImBull4;
    [SerializeField] private GameObject ImBull5;
    [SerializeField] private GameObject ImBull6;

    Animator animer;

    public int GunType = 0;
    // 0 = �ӽð�
    // 1 = ����
    // 2 = ����
    bool Reloading = false;
    bool shotanime = false;

    //�Ҹ��ι�
    [Header("�����÷��̾�")]
    public AudioSource[] SePlayer;

    [Header("����÷��̾�")]
    public AudioSource[] womanPlayer;

    [Header("���۷��÷��̾�")]
    public AudioSource[] emperorPlayer;

    [Header("ȿ����")]
    public Sound[] SE;

    public static Gun instance;

    private void Awake()
    {
        if (Gun.instance == null)
        {
            Gun.instance = this;
        }
    }
    void Start()
    {
        animer = GetComponent<Animator>();
    }


    void Update()
    {
        ShootingControl();
        GunChoose();
    }

    void GunChoose()
    {
        if (Input.GetKey(KeyCode.Alpha1) && Reloading == false && shotanime == false)
        {
            GunType = 0;
            animer.SetInteger("GunState", 0);
        }
        if (Input.GetKey(KeyCode.Alpha2) && Reloading == false && shotanime == false)
        {
            GunType = 1;
            animer.SetInteger("GunState", 1);
        }
        if (Input.GetKey(KeyCode.Alpha3) && Reloading == false && shotanime == false)
        {
            GunType = 2;
            animer.SetInteger("GunState", 2);
        }
    }
        void ShootingControl()
    {
        //�ӽð�
        if (GunType == 0)
        {
            if (Input.GetKey(KeyCode.Mouse0) && shotanime == false && Reloading != true && GameManager.instance.Im_currentBullet > 0 && GunType == 0)
            {
                animer.SetBool("Im_Shot", true);
                shotanime = true;
                PlaySE("Im_Shot");//���
                Instantiate(ImBull1, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull2, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull3, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull4, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull5, FPos.transform.position, FPos.transform.rotation);
                player.bandong += 430;
                Invoke("imBan", 0.05f);//�߻�ó��
                GameManager.instance.Im_currentBullet -= 1;

            }
            if (Input.GetKey(KeyCode.R) && Reloading == false && shotanime != true && GameManager.instance.Im_currentBullet == 0&&GunType==0)
            {
                animer.SetBool("Im_Reload", true);
                Reloading = true;
                PlaySE("Im_Reload");//���
                Invoke("imRe", 0.7f);//����ó��
                GameManager.instance.Im_currentBullet = 4;
            }
        }
        //�ڵ��
        if (GunType == 1)
        {
            if (Input.GetKey(KeyCode.Mouse0) && shotanime == false && Reloading != true && GameManager.instance.H_currentBullet > 0 && GunType == 1)
            {
                animer.SetBool("H_Shot", true);
                shotanime = true;
                PlaySE("Im_Shot");//���
                Instantiate(ImBull1, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull2, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull3, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull4, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull5, FPos.transform.position, FPos.transform.rotation);
                player.bandong += 300;
                Invoke("HBan0", 0.05f);
                Invoke("HBan", 0.4f);//�߻�ó��
                GameManager.instance.H_currentBullet -= 1;

            }
            if (Input.GetKey(KeyCode.R) && Reloading == false && shotanime != true && GameManager.instance.H_currentBullet == 0 && GunType == 1)
            {
                animer.SetBool("H_Reload", true);
                Reloading = true;
                PlaySE("Im_Reload");//���
                Invoke("HRe",2f);//����ó��
                GameManager.instance.H_currentBullet = 7;
            }
        }

        //ak
        if (GunType == 2)
        {
            if (Input.GetKey(KeyCode.Mouse0) && shotanime == false && Reloading != true && GameManager.instance.Ak_currentBullet > 0 && GunType == 2)
            {
                animer.SetBool("Ak_Shot", true);
                shotanime = true;
                PlaySE("Im_Shot");//���
                Instantiate(ImBull1, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull2, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull3, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull4, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull5, FPos.transform.position, FPos.transform.rotation);
                player.bandong += 300;
                Invoke("AkBan0", 0.02f);
                Invoke("AkBan", 0.02f);//�߻�ó��
                GameManager.instance.Ak_currentBullet -= 1;

            }
            if (Input.GetKey(KeyCode.R) && Reloading == false && shotanime != true && GameManager.instance.Ak_currentBullet == 0 && GunType == 2)
            {
                animer.SetBool("Ak_Reload", true);
                Reloading = true;
                PlaySE("AKpoop");//���
                Invoke("AKreing1", 1.13f);

                Invoke("AkRe", 3.2f);//����ó��
                GameManager.instance.Ak_currentBullet = 30;
            }
        }
    }

#region �ӽð�
    void imBan()
    {
        animer.SetBool("Im_Shot", false);
        player.bandong =0;
        Invoke("imBan2", 0.2f);
    }
    void imBan2()
    {
        shotanime = false;
        animer.SetBool("Im_Shot", false);
    }
    void imRe()
    {
        animer.SetBool("Im_Reload", false);
        Reloading = false;
    }
    #endregion

#region �ڵ��
    void HBan0()
    {
        player.bandong = 0;
    }
    void HBan()
    {
        animer.SetBool("H_Shot", false);
        player.bandong = 0;
        Invoke("HBan2", 0.2f);
    }
    void HBan2()
    {
        shotanime = false;
        animer.SetBool("H_Shot", false);
    }
    void HRe()
    {
        animer.SetBool("H_Reload", false);
        Reloading = false;
    }
    #endregion

#region ak
    void AkBan0()
    {
        player.bandong = 0;
    }
    void AkBan()
    {
        animer.SetBool("Ak_Shot", false);
        player.bandong = 0;
        Invoke("AkBan2", 0.2f);
    }
    void AkBan2()
    {
        shotanime = false;
        animer.SetBool("Ak_Shot", false);
    }
    void AkRe()
    {
        animer.SetBool("Ak_Reload", false);
        Reloading = false;
    }

    void AKreing1()
    {
        PlaySE("AKhoi");
        Invoke("AKreing2", 0.6f);
    }
    void AKreing2()
    {
        PlaySE("ping");
    }
    #endregion

    //�Ҹ�����
    void PlaySE(string SoundName)
    {
        for(int i = 0; i < SE.Length; i++)//��ϵ� SE����
        {
            if(SoundName == SE[i].soundName)
            {
                for(int j = 0; j<SePlayer.Length; j++)
                {
                    if (!SePlayer[j].isPlaying)//j��° se�÷��̾ ��������� �ʴ´ٸ� ����
                    {
                        SePlayer[j].clip = SE[i].clip;
                        //������� �÷��̾ �� ���ǹ��� ȿ���� ���ԡ�
                        SePlayer[j].Play();//���
                        return; //�����Ű�� Ƣ��
                    }   
                }
                return; //����
            }
        }
        Debug.Log("��ϵ� SE��");
    }
}
