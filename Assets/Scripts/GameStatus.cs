using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] public int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI finalScoreText;

    internal void GameOverScoreSetting()
    {
        scoreText.text = string.Empty;
        levelText.text = string.Empty;
    }

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField]
    private bool autoPlayEnabled;
    public bool AutoPlayEnabled
    {
        get { return autoPlayEnabled; }
        set { autoPlayEnabled = value; }
    }

    private void Awake()
    {
        foreach (var gameStatus in FindObjectsOfType<GameStatus>())
        {
            gameStatus.levelText.text = levelText.text = $"LEVEL {SceneManager.GetActiveScene().buildIndex}";
        }
        if (FindObjectsOfType<GameStatus>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddStatsWhenBlockDestoryed(int points)
    {
        currentScore += points;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
