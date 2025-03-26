using UnityEngine;

public class Event1_3Mana : MonoBehaviour
{
    public bool ming = false;
    bool doubleMing = false;
    [SerializeField] private GameObject pos1;
    [SerializeField] private GameObject pos2;
    [SerializeField] private GameObject pos3;
    [SerializeField] private GameObject pos4;
    [SerializeField] private GameObject KINGpos;
    

    [SerializeField] private GameObject woman;
    [SerializeField] private GameObject KINGWOMAN;

    //Å¸ÀÌ¸Ó
    float timer;
    int waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        waitingTime = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if(ming == true)
        {
            if(doubleMing == false)
            {
                Invoke("bossSpawn", 2f);
                doubleMing = true;
            }
            timer += Time.deltaTime;

            if (timer > waitingTime)
            {
                Invoke("womanSpawn", 10f);
                timer = 0;
            }
        }
        
    }

    void bossSpawn()
    {
        Instantiate(KINGWOMAN, KINGpos.transform.position, KINGpos.transform.rotation);
    }
    void womanSpawn()
    {
        Instantiate(woman, pos1.transform.position, pos1.transform.rotation);
        Instantiate(woman, pos2.transform.position, pos2.transform.rotation);
        Instantiate(woman, pos3.transform.position, pos3.transform.rotation);
        Instantiate(woman, pos4.transform.position, pos4.transform.rotation);
    }
}
