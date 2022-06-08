using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public abstract void Die();
    public abstract void DealDamage(Entity entity);
    public abstract void TookDamage();
    private int health = 1000;
    [SerializeField]
    private int maxHealth = 1000;
    [SerializeField]
    private int damage = 100;
    public int Damage
    {
        get { return damage; }
    }
    
    // Start is called before the first frame update
    public void Awake()
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
}
