using UnityEngine;

public class Event1_3S : MonoBehaviour
{
    [SerializeField] Event1_3Mana E;
    [SerializeField] private GameObject DOOR;
    [SerializeField] private GameObject POS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(DOOR, POS.transform.position, POS.transform.rotation);
            E.ming = true;
            Destroy(gameObject);
        }
    }
}
