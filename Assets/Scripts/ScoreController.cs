using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreTMP;

    private int score;

    public void UpdateScore()
    {
        score++;
        scoreTMP.text = score.ToString();
    }
}
