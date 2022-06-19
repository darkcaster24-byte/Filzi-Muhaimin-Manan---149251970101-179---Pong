using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public int magnitude;

    public int spawnDuration=15;
    private float timer;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision = ball){
            ball.GetComponent<BallController>().ActivatePUSpeedUp(magnitude);
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
