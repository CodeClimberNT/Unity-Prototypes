using TMPro;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    int score;

    [SerializeField]
    TextMeshPro scoreText;

    [SerializeField]
    float
        extents = 4f,
        speed = 10f;

    [SerializeField]
    bool isAI;

    public void Move(float target, float arenaExtents)
    {
        Vector3 p = transform.localPosition;
        p.x = isAI ? AdjustByAI(p.x, target) : AdjustByPlayer(p.x);
        float limit = arenaExtents - extents;
        p.x = Mathf.Clamp(p.x, -limit, limit);
        transform.localPosition = p;
    }

    public bool HitBall(float ballX, float ballExtents, out float hitFactor)
    {
        hitFactor =
            (ballX - transform.localPosition.x) /
            (extents + ballExtents);

        return -1f <= hitFactor && hitFactor <= 1f;
    }

    public void StartNewGame()
    {
        SetScore(0);
    }

    public bool ScorePoint(int pointsToWin)
    {
        SetScore(score + 1);
        return score >= pointsToWin;
    }

    void SetScore(int newScore)
    {
        score = newScore;
        scoreText.SetText($"{newScore}");
    }

    float AdjustByAI(float x, float target)
    {
        if (x < target)
        {
            return Mathf.Min(x + speed * Time.deltaTime, target);
        }
        return Mathf.Max(x - speed * Time.deltaTime, target);
    }

    float AdjustByPlayer(float x)
    {
        bool goRight = Input.GetKey(KeyCode.RightArrow);
        bool goLeft = Input.GetKey(KeyCode.LeftArrow);
        if (goRight && !goLeft)
        {
            return x + speed * Time.deltaTime;
        }
        else if (goLeft && !goRight)
        {
            return x - speed * Time.deltaTime;
        }
        return x;
    }
}
