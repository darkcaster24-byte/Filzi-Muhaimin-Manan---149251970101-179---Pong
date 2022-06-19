using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    private Vector3 sizeChange = new Vector3(0f,1.7f,0f);

    private float baseSpeed;
    private Vector3 baseSize;
    public int PUDuration;
    private bool sizeUpStatus=false;
    private bool speedUpStatus=false;
    private float timerSize;
    private float timerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = speed;//menyimpan kecepatan awal
        rig= GetComponent<Rigidbody2D>();
        baseSize = rig.transform.localScale;//menyimpan ukuran awal
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject(GetInput());

        //durasi power up size paddle
        if(sizeUpStatus)
        {
            timerSize+=Time.deltaTime;
            if(timerSize>PUDuration){
                rig.transform.localScale = baseSize;
                sizeUpStatus=false;
            }
        }

        //durasi power up speed padde
        if(speedUpStatus)
        {
            timerSpeed+=Time.deltaTime;
            if(timerSpeed>PUDuration)
            {
                speed=baseSpeed;
                speedUpStatus=false;
            }
        }
    }

    private Vector2 GetInput()
    {
        if(Input.GetKey(upKey))
        {
            return Vector2.up *speed;
        }
        if(Input.GetKey(downKey))
        {
            return Vector2.down*speed;
        }
        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("TEST : "+ movement);
        rig.velocity=movement;
    }

    //mengaktifkan power up size padel
    public void ActivatePUPaddleSizeUp()
    {
        rig.transform.localScale += sizeChange;
        sizeUpStatus = true;
        timerSize=0;
    }

    //mengaktifkan power up speed padel
    public void ActivetePUPaddleSpeedUp(float magnitude)
    {
        speed *= magnitude;
        speedUpStatus=true;
        timerSpeed=0;
    }
}
