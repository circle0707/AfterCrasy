using UnityEngine;

public class Event1_2E : MonoBehaviour
{
    int sujeongHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        panByeol_HP();
    }
    void panByeol_HP()
    {
        if (sujeongHP <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.Event1_2kill = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerSBull")
        {
            sujeongHP -= 50;
        }
        if (collision.gameObject.tag == "PlayerGBull")
        {
            sujeongHP -= 50;
        }
    }
}
