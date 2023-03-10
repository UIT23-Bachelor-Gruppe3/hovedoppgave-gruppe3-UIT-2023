using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Variables;

public class PlayerBehaviour : NetworkBehaviour
{
    private readonly float boundX = 0.35f;
    private readonly float boundY = 0.17f;
    [SerializeField] private FloatVariable speed;
    [SerializeField] private FloatReference playerSpeed;
    private Camera mainCamera;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        speed.SetValue(playerSpeed);
    }

    private void Awake()
    {
        mainCamera = Camera.main; //Locates the Main Camera with the MainCamera tag
    }

    private void LateUpdate()
    {
        if(IsLocalPlayer)
        {
            //Vector3 pos = transform.position;
            //pos.z = -10;
            //mainCamera.transform.position = pos;

            Vector3 delta = Vector3.zero;

            //check if we're inside the bounds of the x axis
            float deltaX = transform.position.x - mainCamera.transform.position.x;


            if (deltaX > boundX || deltaX < -boundX)
            {
                if (mainCamera.transform.position.x < transform.position.x)
                {
                    delta.x = deltaX - boundX;
                }
                else
                {
                    delta.x = deltaX + boundX;
                }
            }

            //check if we're inside the bounds of the x axis
            float deltaY = transform.position.y - mainCamera.transform.position.y;

            if (deltaY > boundY || deltaY < -boundX)
            {
                if (mainCamera.transform.position.y < transform.position.y)
                {
                    delta.y = deltaY - boundY;
                }
                else
                {
                    delta.y = deltaY + boundY;
                }
            }

            mainCamera.transform.position += new Vector3(delta.x, delta.y, 0);
        }
    }

    void Update()
    {
        if (!IsOwner) return;
       
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * (speed.Value * Time.deltaTime);
        transform.position += (Vector3)movement;

    }
}