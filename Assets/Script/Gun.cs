using UnityEngine;

[System.Serializable]//강제로 Sound를 인스펙터에 띄우기
public class Sound //밍 재생기
{
    public string soundName;
    public AudioClip clip;
}

public class Gun : MonoBehaviour
{
    [SerializeField] Player player;//플레이어나이스!~~~
    [SerializeField] private Transform FPos;//총알 방향지정

    //임시건총알
    [SerializeField] private GameObject ImBull1;
    [SerializeField] private GameObject ImBull2;
    [SerializeField] private GameObject ImBull3;
    [SerializeField] private GameObject ImBull4;
    [SerializeField] private GameObject ImBull5;
    [SerializeField] private GameObject ImBull6;

    Animator animer;

    public int GunType = 0;
    // 0 = 임시건
    // 1 = 권총
    // 2 = 소총
    bool Reloading = false;
    bool shotanime = false;

    //소리부문
    [Header("음악플레이어")]
    public AudioSource[] SePlayer;

    [Header("우먼플레이어")]
    public AudioSource[] womanPlayer;

    [Header("엠퍼러플레이어")]
    public AudioSource[] emperorPlayer;

    [Header("효과음")]
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
        //임시건
        if (GunType == 0)
        {
            if (Input.GetKey(KeyCode.Mouse0) && shotanime == false && Reloading != true && GameManager.instance.Im_currentBullet > 0 && GunType == 0)
            {
                animer.SetBool("Im_Shot", true);
                shotanime = true;
                PlaySE("Im_Shot");//재생
                Instantiate(ImBull1, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull2, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull3, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull4, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull5, FPos.transform.position, FPos.transform.rotation);
                player.bandong += 430;
                Invoke("imBan", 0.05f);//발사처리
                GameManager.instance.Im_currentBullet -= 1;

            }
            if (Input.GetKey(KeyCode.R) && Reloading == false && shotanime != true && GameManager.instance.Im_currentBullet == 0&&GunType==0)
            {
                animer.SetBool("Im_Reload", true);
                Reloading = true;
                PlaySE("Im_Reload");//재생
                Invoke("imRe", 0.7f);//장전처리
                GameManager.instance.Im_currentBullet = 4;
            }
        }
        //핸드건
        if (GunType == 1)
        {
            if (Input.GetKey(KeyCode.Mouse0) && shotanime == false && Reloading != true && GameManager.instance.H_currentBullet > 0 && GunType == 1)
            {
                animer.SetBool("H_Shot", true);
                shotanime = true;
                PlaySE("Im_Shot");//재생
                Instantiate(ImBull1, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull2, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull3, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull4, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull5, FPos.transform.position, FPos.transform.rotation);
                player.bandong += 300;
                Invoke("HBan0", 0.05f);
                Invoke("HBan", 0.4f);//발사처리
                GameManager.instance.H_currentBullet -= 1;

            }
            if (Input.GetKey(KeyCode.R) && Reloading == false && shotanime != true && GameManager.instance.H_currentBullet == 0 && GunType == 1)
            {
                animer.SetBool("H_Reload", true);
                Reloading = true;
                PlaySE("Im_Reload");//재생
                Invoke("HRe",2f);//장전처리
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
                PlaySE("Im_Shot");//재생
                Instantiate(ImBull1, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull2, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull3, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull4, FPos.transform.position, FPos.transform.rotation);
                Instantiate(ImBull5, FPos.transform.position, FPos.transform.rotation);
                player.bandong += 300;
                Invoke("AkBan0", 0.02f);
                Invoke("AkBan", 0.02f);//발사처리
                GameManager.instance.Ak_currentBullet -= 1;

            }
            if (Input.GetKey(KeyCode.R) && Reloading == false && shotanime != true && GameManager.instance.Ak_currentBullet == 0 && GunType == 2)
            {
                animer.SetBool("Ak_Reload", true);
                Reloading = true;
                PlaySE("AKpoop");//재생
                Invoke("AKreing1", 1.13f);

                Invoke("AkRe", 3.2f);//장전처리
                GameManager.instance.Ak_currentBullet = 30;
            }
        }
    }

#region 임시건
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

#region 핸드건
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

    //소리관련
    void PlaySE(string SoundName)
    {
        for(int i = 0; i < SE.Length; i++)//등록된 SE관리
        {
            if(SoundName == SE[i].soundName)
            {
                for(int j = 0; j<SePlayer.Length; j++)
                {
                    if (!SePlayer[j].isPlaying)//j번째 se플레이어가 재생중이지 않는다면 만족
                    {
                        SePlayer[j].clip = SE[i].clip;
                        //不재생중 플레이어에 전 조건문의 효과음 삽입☆
                        SePlayer[j].Play();//재생
                        return; //재생시키고 튀기
                    }   
                }
                return; //ㅌㅌ
            }
        }
        Debug.Log("등록된 SE無");
    }
}
