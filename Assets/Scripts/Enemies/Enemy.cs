using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rG;
    private Transform target;
    private float speed = 1f;

    private void FixedUpdate()
    {
        if (target)
        {
            // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector2 force = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rG.AddForce(force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!target && collision.TryGetComponent(typeof(PlayerBehaviour), out Component component))
            target = collision.transform;
    }
}
