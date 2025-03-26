using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBull5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("des", 1.7f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-0.05f, -0.03f, 1) * Time.deltaTime * 100f);
    }
    void des()
    {
        Destroy(gameObject);
    }
}
