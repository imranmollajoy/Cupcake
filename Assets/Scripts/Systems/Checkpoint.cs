using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (BoxCollider2D))]
public class Checkpoint : MonoBehaviour
{
    private CheckpointSystem checkpointSystem;

    BoxCollider2D col;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            checkpointSystem.CurrentCheckpoint = this.transform;
        }
    }

    void Awake()
    {
        checkpointSystem = GetComponentInParent<CheckpointSystem>();
        Setup();
    }

    void Setup()
    {
        if (!col)
        {
            col = GetComponent<BoxCollider2D>();
        }
        col.isTrigger = true;

        // set width of col to 0.2f and height ot 10f
        col.size = new Vector2(0.2f, 10f);

        // set offset to 3
        col.offset = new Vector2(0f, 3f);
    }

    void OnValidate()
    {
        Setup();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.2f);
    }
}
