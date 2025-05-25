using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreTMP, bestTMP;

    private int score;

    //initialize best score if never played before and display best score from the start
    private void Start()
    {
        if(!PlayerPrefs.HasKey("best"))
        {
            PlayerPrefs.SetInt("best", 0);
            PlayerPrefs.Save();
        }

        bestTMP.text = PlayerPrefs.GetInt("best").ToString();
    }

    public void UpdateScore()
    {
        score++;

        if(PlayerPrefs.GetInt("best") < score)
        {
            PlayerPrefs.SetInt("best", score);
            PlayerPrefs.Save();
        }

        scoreTMP.text = score.ToString();
        bestTMP.text = PlayerPrefs.GetInt("best").ToString();
    }
}
