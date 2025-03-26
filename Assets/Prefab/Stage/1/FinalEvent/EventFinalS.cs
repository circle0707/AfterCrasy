
using UnityEngine;

public class EventFinalS : MonoBehaviour
{
    [SerializeField] private GameObject DOOR;
    [SerializeField] private GameObject doorPOS;
    [SerializeField] Player player;

    bool run = false;
    [SerializeField] private GameObject Pos;

    [SerializeField] private GameObject Emperor;
    [SerializeField] private GameObject King;


    [SerializeField] private GameObject bgm;
    [SerializeField] private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
       bgm = GameObject.Find("bgm");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.PlayerHP = 1000;
            Invoke("ifif", 1f);
        }
    }

    void ifif()
    {
        Destroy(bgm);
        Instantiate(boss, doorPOS.transform.position, doorPOS.transform.rotation);
        Instantiate(DOOR, doorPOS.transform.position, doorPOS.transform.rotation);
        Instantiate(King, Pos.transform.position, Pos.transform.rotation);
        Instantiate(Emperor, Pos.transform.position, Pos.transform.rotation);
        Destroy(gameObject);
    }


}
