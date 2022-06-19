using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public Collider2D leftPaddle;
    public Collider2D rightPaddle;
    public float magnitude;

    public int spawnDuration;
    private float timer;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision = ball){
            if(ball.GetComponent<BallController>().paddle){
                rightPaddle.GetComponent<PaddleController>().ActivetePUPaddleSpeedUp(magnitude);
            }else{
            leftPaddle.GetComponent<PaddleController>().ActivetePUPaddleSpeedUp(magnitude);
            }
            manager.RemovePowerUp(gameObject);
        }
    }

    //durasi spawn power up
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer > spawnDuration)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
