using UnityEngine;

public class sontop_s : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("des", 1.7f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 50f);
    }
    void des()
    {
        Destroy(gameObject);
    }
}
