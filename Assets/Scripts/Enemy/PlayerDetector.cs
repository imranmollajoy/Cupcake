using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField]
    private float _detectionRange = 10f;

    [SerializeField]
    private LayerMask _playerLayer;

    // Update is called once per frame
    void Update()
    {
        Collider2D player =
            Physics2D
                .OverlapCircle(transform.position,
                _detectionRange,
                _playerLayer);

        if (player != null)
        {
            CheckIfLeftOrRight (player);
        }
    }

    void CheckIfLeftOrRight(Collider2D player)
    {
        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void OnGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _detectionRange);
    }
}
