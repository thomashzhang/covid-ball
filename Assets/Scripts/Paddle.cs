using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameStatus gameStatus;
    Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStatus.AutoPlayEnabled && !ball.BallLocked)
        {
            transform.position = new Vector2(Mathf.Clamp(ball.transform.position.x, minX, maxX), transform.position.y);
        }
        else
        {
            var x = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            var paddlePos = new Vector2(Mathf.Clamp(x, minX, maxX), transform.position.y);
            transform.position = paddlePos;
        }
    }
}
