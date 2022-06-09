using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int rightScore;
    public int leftScore;
    public int maxScore;
    public BallController ball;
    
    public void AddRightScore(int increment)
    {
        ball.ResetBall();
        rightScore += increment;
        if(rightScore>=maxScore)
        {
            GameOver();
        }
    }

    public void AddLeftScore(int increment)
    {
        ball.ResetBall();
        leftScore += increment;
        if(leftScore>=maxScore)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
