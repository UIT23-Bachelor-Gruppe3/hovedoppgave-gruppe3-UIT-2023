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
    private readonly float startDelay = 0.5f;
    private readonly float strikeDistance = 2;
    DamageDealer damage;
    private float timer = 0;
    private readonly float timeToDamage = 1;
    //CapsuleCollider2D enemyColl;
    //CapsuleCollider2D playerColl;

    private void Start()
    {
        if (ResetHP)
        HP.SetValue(StartingHP);

        damage = enemy.GetComponent<DamageDealer>();

        //InvokeRepeating(nameof(DealDamage), startDelay, damageInterval);
        //Invoke(nameof(DealDamage), startDelay);

    }

    //private void DealDamage()
    //{
    //    var heading = enemy.transform.position - transform.position;
    //    var distance = heading.magnitude;
    //    if (heading.sqrMagnitude < strikeDistance * strikeDistance)
    //    {
    //        Debug.Log($"distance: {distance}");
    //    }


    //    var dist = Vector2.Distance(transform.position, enemy.transform.position) ;
    //    ;

    //    if (dist < strikeDistance)
    //    //playerColl.IsTouching(enemyColl);
    //    {
    //        if (damage != null)
    //            HP.ApplyChange(-damage.DamageAmount);
    //    }

    //    if (HP.Value < 0)
    //    {
    //        Debug.Log("DEAD!");
    //        onPlayerDeath.Invoke();
    //    }
    //    Invoke(nameof(DealDamage), startDelay);
    //}


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
            }
        }
        
    }

    IEnumerator CountdownToDamage()
    {
        Debug.Log($" Waiting...");
        yield return new WaitForSeconds(1f);
    }
}
