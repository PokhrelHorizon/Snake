using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    private void Start()
    {
        //send toggle default value to playerprefs
        PlayerPrefs.SetInt("togglewalls", 0);
        PlayerPrefs.Save();
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnToggleToggled(bool toggle)
    {
        if(toggle ==false)
        {
            PlayerPrefs.SetInt("togglewalls", 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("togglewalls", 0);
            PlayerPrefs.Save();
        }
    }
}

