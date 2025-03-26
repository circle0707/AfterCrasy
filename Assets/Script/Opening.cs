using UnityEngine.SceneManagement;
using UnityEngine;

public class Opening : MonoBehaviour
{
    void Start()
    {
        Invoke("sceneJeon", 120f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("stage1");
        }
    }

    void sceneJeon()
    {
        SceneManager.LoadScene("stage1");
    }
}
