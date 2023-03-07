using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Variables;

public class PlayerBehaviour : NetworkBehaviour
{
    [SerializeField] FloatVariable speed;
    public FloatReference playerSpeed;
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        speed.SetValue(playerSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * (playerSpeed * Time.fixedDeltaTime);
        transform.position += (Vector3)movement;

    }
}