using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle;
    Vector2 paddleToBallVector;
    public bool BallLocked { get; private set; }
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float collisionPush = -0.5f;

    Rigidbody2D rigidbody2D;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        BallLocked = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BallLocked)
        {
            LockBallToPaddle();
        }
        LaunchOnMouseClick();
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && BallLocked)
        {
            rigidbody2D.velocity = new Vector2(xPush, yPush);
            BallLocked = false;
        }
    }

    private void LockBallToPaddle()
    {
        var paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!BallLocked)
        {
            audioSource.Play();
            rigidbody2D.velocity += new Vector2(Random.Range(0f, collisionPush), Random.Range(0f,collisionPush));
        }
    }
}
