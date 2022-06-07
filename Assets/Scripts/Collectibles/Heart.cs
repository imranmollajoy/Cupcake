using UnityEngine;

public class Heart : Collectible
{
    public override void Collect()
    {
        Debug.Log("Heart collected");
    }
}