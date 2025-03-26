using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class gameoverB : MonoBehaviour
{
    Button button;

    public void OnClickButton()
    {
        Invoke("dd", 1f);
    }

    void dd()
    {
        SceneManager.LoadScene("stage1");
    }
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("stage1");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("cut");
        }
    }
}

