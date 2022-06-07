// unityengine script


using UnityEngine;
using System.Collections;

public class Diamond : Collectible
{
    public override void Collect()
    {
        Debug.Log("Diamond collected");
    }
}
