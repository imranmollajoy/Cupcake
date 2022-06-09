using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class EnemyEntity : Entity
{
    [SerializeField]
    private float delayBetweenAttack = 1f;

    [SerializeField]
    private float attackDelay = 1f;

    private bool canAttack = true;

    [SerializeField]
    private LayerMask attackMask;

    [SerializeField]
    private float attackRange = 1f;

    [SerializeField]
    private Animator animator;

    const string IDLE = "Idle";

    const string ATTACK = "Attack";

    const string DIE = "Die";

    const string HIT = "Hit";

    public override void Die()
    {
        animator.Play (DIE);
        Destroy(gameObject, 1f);
    }

    public override void TookDamage()
    {
        canAttack = false;
        animator.Play (HIT);
    }

    public override void DealDamage(Entity entity)
    {
        entity.TakeDamage (Damage);
        StopCoroutine(Attack(entity));
    }

    void Update()
    {
        Collider2D[] colliders =
            Physics2D
                .OverlapCircleAll(transform.position, attackRange, attackMask);

        foreach (Collider2D collider in colliders)
        {
            Entity entity = collider.GetComponent<Entity>();
            if (entity != null && canAttack)
            {
                StopCoroutine(Cooldown());
                animator.Play (ATTACK);
                StartCoroutine(Attack(entity));
                StartCoroutine(Cooldown());
            }
        }
    }

    IEnumerator Cooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(delayBetweenAttack);
        canAttack = true;
    }

    IEnumerator Attack(Entity entity)
    {
        yield return new WaitForSeconds(attackDelay);
        DealDamage (entity);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
