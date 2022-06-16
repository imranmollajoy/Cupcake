using System.Collections;
using UnityEngine;

public class Diamond : Collectible
{
    public override void Collect()
    {
        LevelInfoManager.Data.LevelInfo.Diamonds++;
    }
}
