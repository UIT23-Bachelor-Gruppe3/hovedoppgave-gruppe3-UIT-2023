using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookat; //the thing the camera is pointing at
    public float boundX = 0.15f;
    public float boundY = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Move the camera after the player has moved to avoid jitter.
    void LateUpdate()//called after update and fixedUpdate
    {
        Vector3 delta = Vector3.zero; //difference between this and next frame   

        //check if we're inside the bounds of the x axis
        float deltaX = lookat.position.x - transform.position.x;
       

        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < lookat.position.x )
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }

        //check if we're inside the bounds of the x axis
        float deltaY = lookat.position.y - transform.position.y;

        if (deltaY > boundY || deltaY < -boundX)
        {
            if (transform.position.y < lookat.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y,0); //No transform.position2D

    }
}
