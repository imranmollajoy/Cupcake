using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : Entity
{
   public override void Die()
   {
       Debug.Log("died");
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
