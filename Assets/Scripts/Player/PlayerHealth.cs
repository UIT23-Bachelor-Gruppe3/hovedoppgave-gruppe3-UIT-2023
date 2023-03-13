using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UnityEvent onPlayerDeath;
    [SerializeField] private FloatVariable HP;
    [SerializeField] private FloatVariable lightDamageTaken;
    [SerializeField] private bool ResetHP;
    [SerializeField] private FloatReference StartingHP;
    
    private float timer = 0;
    private readonly float TIME_TO_DAMAGE = 1;

    private void Start()
    {
        if (ResetHP)
        HP.SetValue(StartingHP);
    }
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            timer = TIME_TO_DAMAGE;
        }
    }

    /// <summary> 
    /// The longer the object colliders are touching
    /// more damage is given.
    /// </summary>
    /// <param name="collision">Who or what is dealing damage</param>
    void OnCollisionStay2D(Collision2D collision)
   {
        timer += Time.deltaTime; //deltatime is the time passed since previous frame

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ApplyDamage();
        }

    }

    private void ApplyDamage()
    {
        if (timer >= TIME_TO_DAMAGE)
        {
            HP.ApplyChange(-lightDamageTaken.Value);
            timer = 0; //reset             
            if (HP.Value <= 0)
            {
                Debug.Log("DEAD!");
                onPlayerDeath.Invoke();
            }
        }
    }
}
