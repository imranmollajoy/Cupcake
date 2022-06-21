using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfoManager : MonoBehaviour
{
    // make singleton
    public static LevelInfoManager Data;

    public LevelInfo LevelInfo;

    [HideInInspector]
    public CheckpointSystem checkpointSystem;

    void Awake()
    {
        if (Data == null)
            Data = this;
        else
            Destroy(gameObject);
    }

    public void Died()
    {
        StartCoroutine(ChangePosOfPlayer());
    }

    IEnumerator ChangePosOfPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        checkpointSystem.Player.position =
            checkpointSystem.CurrentCheckpoint.position;
    }
}

[System.Serializable]
public class LevelInfo
{
    private int level;

    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }

    private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    private int time;

    public int Time
    {
        get
        {
            return time;
        }
        set
        {
            time = value;
        }
    }

    private int diamonds;

    public int Diamonds
    {
        get
        {
            return diamonds;
        }
        set
        {
            diamonds = value;
            UIManager.Instance.UpdateDiamondCounter (diamonds);
        }
    }

    private int hearts = 3;

    public int Hearts
    {
        get
        {
            return hearts;
        }
        set
        {
            hearts = value;
        }
    }
}
