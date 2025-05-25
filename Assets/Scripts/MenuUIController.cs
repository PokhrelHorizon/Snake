using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}

