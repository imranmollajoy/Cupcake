using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEntity : Entity
{
   public override void Die()
   {
       Destroy(gameObject);
   }
   public override void TookDamage()
   {
       Debug.Log("took damage");
   }
   public override void DealDamage(Entity entity)
   {
       entity.TakeDamage(Damage);
   }
}
