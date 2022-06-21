using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Transform player;

    public Transform Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }

    [SerializeField]
    private Checkpoint[] checkpoints;

    private Transform currentCheckpoint;

    public Transform CurrentCheckpoint
    {
        get
        {
            return currentCheckpoint;
        }
        set
        {
            currentCheckpoint = value;
        }
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        LevelInfoManager.Data.checkpointSystem = this;
        CurrentCheckpoint = checkpoints[0].transform;
    }

    void OnValidate()
    {
        // get all transforms in children and assign them to checkpoints except this
        // transform
        checkpoints = GetComponentsInChildren<Checkpoint>();

        // change the name of checkpoints to corresponding index
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].name = "Checkpoint " + i;
        }
    }
}
