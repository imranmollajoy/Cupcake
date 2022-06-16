using UnityEngine;

public class Heart : Collectible
{
    public override void Collect()
    {
        LevelInfoManager.Data.LevelInfo.Hearts++;
    }
}
