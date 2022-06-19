using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rig;
    public Vector2 resetPosition;

    public float speedUp;
    public int speedUpDuration;
    private int speedUpCount=0;
    private float timer;
    public bool paddle;

    // Start is called before the first frame update
    void Start()
    {
        rig= GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(speedUpCount>0)
        {
            timer+=Time.deltaTime;
            if(timer > speedUpDuration)
            {
                rig.velocity/=speedUp;
                speedUpCount-=1;
                timer-=speedUpDuration;
            }
        }
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        speedUp=magnitude;
        rig.velocity *= magnitude;
        speedUpCount +=1;
        timer=0;
    }

    //menyimpan interaksi terakhir antara bola dengan padel
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="rightPaddle")
        {
            paddle=true;            
        }
        if(collision.gameObject.tag=="leftPaddle")
        {
            paddle=false;            
        }
    }
}
