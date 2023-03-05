using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    private readonly float speed = 1f;

    private void FixedUpdate()
    {
        if (target)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized;
            transform.Translate(speed * Time.fixedDeltaTime * moveDirection);
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            target = collision.transform;
    }
}
