using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralUIController : MonoBehaviour
{
    //reference main script
    [SerializeField] private GameController GCS;

    //reference Game over UI and pause UI
    [SerializeField] private GameObject gameOverUI, pauseUI;

    //reference audio
    [SerializeField] private AudioSource gameOverAudio;

    //triggers when pause button pressed
    public void OnGamePause()
    {
        GCS.gameIsPaused = true;

        //disable movement input during pause
        GCS.playerMovement.Movement.Disable();

        //freeze time
        Time.timeScale = 0f;

        //activate pauseUI
        pauseUI.SetActive(true);
    }

    public void OnGameResume()
    {
        //enable movement input during resume
        GCS.playerMovement.Movement.Enable();

        GCS.gameIsPaused = false;

        //disable pauseUI
        pauseUI.SetActive(false);

        //unfreeze time
        Time.timeScale = 1f;

    }


    public void DoGameOver()
    {
        //play game over sound
        gameOverAudio.Play();

        //freeze game
        Time.timeScale = 0f;

        //activate gameoverUI
        gameOverUI.SetActive(true);
    }

    public void RestartButtonBehavior()
    {
        //disable input action
        GCS.playerMovement.Disable();

        //unfreeze game
        Time.timeScale = 1f;

        //restart scene
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenuButtonBehavior()
    {
        //disable input action
        GCS.playerMovement.Disable();

        //unfreeze game
        Time.timeScale = 1f;

        //change scene
        SceneManager.LoadScene("Menu");
    }
}
