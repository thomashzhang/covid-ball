using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScreen()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(0);
    }

    public void BackToStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadHelpScreen()
    {
        SceneManager.LoadScene("Help");
    }
    public void LoadWinScreen()
    {
        SceneManager.LoadScene("You Won");
        FindObjectOfType<GameStatus>().GameOverScoreSetting();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
