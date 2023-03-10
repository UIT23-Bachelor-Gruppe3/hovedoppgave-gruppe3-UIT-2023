using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Variables;

public class PlayerBehaviour : NetworkBehaviour
{
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
        mainCamera = Camera.main;
    }

    public override void OnNetworkSpawn()
    {
        //if (IsLocalPlayer == true)
        //    playerCamera.SetActive(true);
        //else
        //    playerCamera.SetActive(false);
    }

    private void LateUpdate()
    {
        if(IsLocalPlayer)
        {
            Vector3 pos = transform.position;
            pos.z = -10;
            mainCamera.transform.position = pos;
        }
    }

    void Update()
    {
        if (!IsOwner) return;
       
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * (playerSpeed * Time.fixedDeltaTime);
        transform.position += (Vector3)movement;

    }
}