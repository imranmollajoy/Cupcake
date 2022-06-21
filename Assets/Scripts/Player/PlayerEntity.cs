using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
    PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public override void Die()
    {
        LevelInfoManager.Data.Died();
        playerController.Died();
    }

    public override void TookDamage()
    {
        playerController.TookDamage();
    }

    public override void DealDamage(Entity entity)
    {
        entity.TakeDamage (Damage);
    }
}
