using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Collectible : MonoBehaviour
{
    public abstract void Collect();
    [SerializeField]
    private Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
            animator.SetTrigger("Hit");
            Destroy(gameObject, 0.5f);
        }
    }

    void Awake(){
        if(!animator)
        {
            animator = GetComponent<Animator>();
        }

        // set offset of the animator randomly
        animator.SetFloat("Offset", Random.Range(0f, 1f)); 
    }
}
