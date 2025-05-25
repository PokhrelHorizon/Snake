using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreTMP, bestTMP;

    private int score;
    //initialize best if never played before
    private void Start()
    {
        if(!PlayerPrefs.HasKey("bestscore"))
        {
            PlayerPrefs.SetInt("bestscore", 0);
            PlayerPrefs.Save();
        }
        bestTMP.text = PlayerPrefs.GetInt("bestscore").ToString(); //shows best score from game start
    }

    public void UpdateScore()
    {
        score++;
        if(PlayerPrefs.GetInt("bestscore") < score)
        {
            PlayerPrefs.SetInt("bestscore", score);
            PlayerPrefs.Save();
        }

        scoreTMP.text = score.ToString();
        bestTMP.text = PlayerPrefs.GetInt("bestscore").ToString();
    }
}
