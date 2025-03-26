using UnityEngine;

public class GoldenBall : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 bang;
    void Start()
    {
        target = GameObject.Find("Player");
        Invoke("des", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * 70 * Time.deltaTime;
        bang = (target.transform.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, bang, 0.24f);
    }
    void des()
    {
        Destroy(gameObject);
    }

}
