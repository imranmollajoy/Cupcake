using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public abstract void Die();
    public abstract void DealtDamage();
    public abstract void TookDamage();
    [SerializeField]
    private int health = 1000;
    [SerializeField]
    private int maxHealth = 1000;
    [SerializeField]
    private int damage = 100;
    
    // Start is called before the first frame update
    void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        TookDamage();
        if (health <= 0)
        {
            Die();
        }
    } 

    public void DealDamage(Entity entity)
    {   
        DealtDamage();
        entity.TakeDamage(damage);
    }  
}
