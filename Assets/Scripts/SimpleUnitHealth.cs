using UnityEngine;
using Variables;
using UnityEngine.Events;

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
    //CapsuleCollider2D enemyColl;
   // CapsuleCollider2D playerColl;

    private void Start()
    {
        if (ResetHP)
        HP.SetValue(StartingHP);

        damage = enemy.GetComponent<DamageDealer>();

        //enemyColl = enemy.GetComponent<CapsuleCollider2D>();
        //playerColl = GetComponent<CapsuleCollider2D>();

        //InvokeRepeating(nameof(DealDamage), startDelay, damageInterval);
        Invoke(nameof(DealDamage), startDelay);

    }

    private void DealDamage()
    {
        var heading = enemy.transform.position - transform.position;
        var distance = heading.magnitude;
        if (heading.sqrMagnitude < strikeDistance * strikeDistance)
        {
            Debug.Log($"distance: {distance}");
        }


        var dist = Vector2.Distance(transform.position, enemy.transform.position) ;
        ;

        if (dist < strikeDistance)
        //playerColl.IsTouching(enemyColl);
        {
            if (damage != null)
                HP.ApplyChange(-damage.DamageAmount);
        }

        if (HP.Value < 0)
        {
            Debug.Log("DEAD!");
            onPlayerDeath.Invoke();
        }
        Invoke(nameof(DealDamage), startDelay);
    }
}
