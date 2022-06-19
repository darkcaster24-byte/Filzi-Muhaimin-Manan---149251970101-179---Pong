using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSizeUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public Collider2D leftPaddle;
    public Collider2D rightPaddle;

    public int spawnDuration=15;
    private float timer;
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision = ball){
            if(ball.GetComponent<BallController>().paddle)
            {
                rightPaddle.GetComponent<PaddleController>().ActivatePUPaddleSizeUp();
            }else{
                leftPaddle.GetComponent<PaddleController>().ActivatePUPaddleSizeUp();
            }
            manager.RemovePowerUp(gameObject);
        }
    }

    //Durasi spawn power up
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer > spawnDuration)
        {
            manager.RemovePowerUp(gameObject);
        }
    }
}
