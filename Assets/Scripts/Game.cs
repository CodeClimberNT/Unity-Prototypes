using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    Ball ball;

    [SerializeField]
    Paddle topPaddle, bottomPaddle;

    [SerializeField]
    Vector2 arenaExtents = new Vector2(10f, 10f);

    void Awake() => ball.StartNewGame();

    void Update()
    {
        topPaddle.Move(ball.Position.x, arenaExtents.x);
        bottomPaddle.Move(ball.Position.x, arenaExtents.x);
        ball.Move();
        BounceYIfNeeded();
        BounceXIfNeeded();
        ball.UpdateVisualization();
    }

    void BounceYIfNeeded()
    {
        float yExtents = arenaExtents.y - ball.Extents;
        if (ball.Position.y < -yExtents)
        {
            ball.BounceY(-yExtents);
        }
        else if (ball.Position.y > yExtents)
        {
            ball.BounceY(yExtents);
        }
    }

    void BounceXIfNeeded()
    {
        float xExtents = arenaExtents.x - ball.Extents;
        if (ball.Position.x < -xExtents)
        {
            ball.BounceX(-xExtents);
        }
        else if (ball.Position.x > xExtents)
        {
            ball.BounceX(xExtents);
        }
    }
}
