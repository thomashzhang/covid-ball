using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int breakableBlocks;

    int sceneIndex;
    SceneLoader sceneLoader;
    public void CountBreakableBlocks()
    {
        breakableBlocks += 1;
    }

    public void BlockDestroyed()
    {
        breakableBlocks -= 1;
        if (breakableBlocks <= 0 && sceneIndex == 5)
        {
            sceneLoader.LoadWinScreen();
        }
        else if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
}
