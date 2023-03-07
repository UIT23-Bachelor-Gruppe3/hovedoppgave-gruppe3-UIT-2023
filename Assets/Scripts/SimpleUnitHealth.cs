using UnityEngine;
using Variables;
using UnityEngine.Events;
using System.Collections;

public class SimpleUnitHealth : MonoBehaviour
{
    public UnityEvent onPlayerDeath;
    public FloatVariable HP;
    public bool ResetHP;
    public FloatReference StartingHP;
    [SerializeField] GameObject enemy;
    [SerializeField] DamageDealer damage;
    private float timer = 0;
    private readonly float timeToDamage = 1;

    private void Start()
    {
        if (ResetHP)
        HP.SetValue(StartingHP);
        damage = enemy.GetComponent<DamageDealer>();
    }

   void OnCollisionStay2D(Collision2D collision)
   {
        timer += Time.deltaTime; //deltatime is the time passed since previous frame
        //Debug.Log($" {timer}");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //StartCoroutine(CountdownToDamage()); //this did not pause the game
            if (damage != null && timer > timeToDamage)
            {
                HP.ApplyChange(-damage.DamageAmount);
                timer = 0; //reset             
                if (HP.Value < 0)
                {
                    Debug.Log("DEAD!");
                    onPlayerDeath.Invoke();
                }
            }
        }
    }

    IEnumerator CountdownToDamage()
    {
        Debug.Log($" Waiting...");
        yield return new WaitForSeconds(1f);
    }
}
