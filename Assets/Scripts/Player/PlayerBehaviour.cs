using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerBehaviour : NetworkBehaviour
{
    Rigidbody2D rb2d;
    private float horizontalInput;
    private float verticalInput;
    // Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        // velocity = new Vector2(horizontalInput, verticalInput) * (250 * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        // Vector2 movement = new Vector2(horizontalInput, verticalInput) * (4 * Time.fixedDeltaTime);
        // transform.position += (Vector3)movement;
        rb2d.velocity = new Vector2(horizontalInput, verticalInput) * (250 * Time.fixedDeltaTime);
        // rb2d.velocity = velocity;
    }
}