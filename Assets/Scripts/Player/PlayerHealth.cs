using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public ScriptableStats playerStats;
    public UnityEvent damage;
    public UnityEvent onPlayerDeath;

    [SerializeField]
    GameObject enemy;

    private Collider2D playerCollider, enemyCollider;

    private void Start()
    {
        //Check that the first GameObject exists in the Inspector and fetch the Collider
        if (gameObject != null)
            playerCollider = gameObject.GetComponent<Collider2D>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        if (enemy != null)
            enemyCollider = enemy.GetComponent<Collider2D>();
    }

    public void TakeDamage(float damage)
    {
        playerStats.health -= damage;
        Debug.Log("Current health " + playerStats.health);
        if (playerStats.health < 0)
        {
            Debug.Log("DEAD!");
            onPlayerDeath.Invoke();
        }
    }

}