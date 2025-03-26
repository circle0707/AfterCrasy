using UnityEngine.SceneManagement;
using UnityEngine;

public class cutVid : MonoBehaviour
{
    void Start()
    {
        Invoke("sceneJeon", 7f);
    }

    private void Update()
    {

    }

    void sceneJeon()
    {
        SceneManager.LoadScene("final boss");
    }
}
