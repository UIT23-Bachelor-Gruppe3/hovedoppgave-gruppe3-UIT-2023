using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Target found: " + collision.name);
        if (!target)
            target = collision.transform;
    }
}
