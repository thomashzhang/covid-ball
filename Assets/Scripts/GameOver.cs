using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore.text = FindObjectOfType<GameStatus>().currentScore.ToString();
    }
}
