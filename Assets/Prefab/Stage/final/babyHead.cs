using UnityEngine;

public class babyHead : MonoBehaviour
{
    [SerializeField] finalBoss final;
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
        if (collision.gameObject.tag == "PlayerSBull" && final.canHit == true)
        {
            final.EnemyHp -= 10;
            final.stun();
        }
        if (collision.gameObject.tag == "PlayerGBull" && final.canHit == true)
        {
            final.EnemyHp -= 30;
            final.stun();
        }
    }
}
