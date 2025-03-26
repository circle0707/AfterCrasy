using UnityEngine;

public class bangBall4 : MonoBehaviour
{
    void Start()
    {
        Invoke("des", 5f);
    }
    void Update()
    {
        transform.Translate(new Vector3(-1f, 0, 1) * Time.deltaTime * 150f);
    }
    void des()
    {
        Destroy(gameObject);
    }
}
