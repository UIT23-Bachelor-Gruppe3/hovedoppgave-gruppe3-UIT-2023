using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerBehaviour : NetworkBehaviour
{
    public ScriptableStats playerStats; //referene to Scriptable Object
    private float horizontalInput;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().color = playerStats.playerColor;
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
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * (playerStats.moveSpeed * Time.fixedDeltaTime);
        transform.position += (Vector3)movement;

    }
}