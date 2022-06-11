using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Entity
{
    [SerializeField]
    private Animator animator;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public override void Die()
    {
        Destroy (gameObject);
    }

    public override void TookDamage()
    {
        if (!Died) return;
        animator.SetTrigger("Hit");
    }

    public override void DealDamage(Entity entity)
    {
        return;
    }
}
