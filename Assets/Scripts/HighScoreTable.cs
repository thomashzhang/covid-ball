using TMPro;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScore;
    private void Start()
    {
        var oldHighScore = PlayerPrefs.GetInt("HighScore");
        var score = FindObjectOfType<GameStatus>().currentScore;
        if (score > oldHighScore)
        {
            oldHighScore = score;
            PlayerPrefs.SetInt("HighScore", score);
        }
        highScore.text = oldHighScore.ToString();
    }
}
