using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Event1_3Mana E;
    [SerializeField] TextMeshProUGUI BulletText; //ÃÑ¾Ë UIÅØ½ºÆ®
    [SerializeField] Slider HPBar;
    public int Im_currentBullet = 4;
    public int H_currentBullet = 7;
    public int Ak_currentBullet = 30;
    public int MaxBullet = 4;

    public float MaxHP = 1000;
    public float currentHP = 1000;

    public int Event1_1Kill = 0;
    public bool Event1_2kill = false;
    public bool Event1_3kill = false;

    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
    }

    private void Update()
    {
        updateBullet();
        Event1_1();
        Event1_2();
        Event1_3();
        updateHP();
    }

    void updateBullet()
    {
        if(Gun.instance.GunType == 0)
        {
            MaxBullet = 4;
            BulletText.text = Im_currentBullet + " / " + MaxBullet;
        }
        if (Gun.instance.GunType == 1)
        {
            MaxBullet = 7;
            BulletText.text = H_currentBullet + " / " + MaxBullet;
        }
        if (Gun.instance.GunType == 2)
        {
            MaxBullet = 30;
            BulletText.text = Ak_currentBullet + " / " + MaxBullet;
        }
    }

    void updateHP()
    {
        HPBar.value = (float)currentHP / (float)MaxHP;
    }

    void Event1_1()
    {
        if (Event1_1Kill >= 10)
        {
            Destroy(GameObject.Find("StairWoman"));
        }
    }
    void Event1_2()
    {
        if (Event1_2kill == true)
        {
            Destroy(GameObject.Find("1FDOOR"));
        }
    }
    void Event1_3()
    {
        if (Event1_3kill == true)
        {
            E.ming = false;
            Destroy(GameObject.Find("Event1-3DOOR(Clone)"));
            Destroy(GameObject.Find("2FDOOR"));
        }
    }
}
