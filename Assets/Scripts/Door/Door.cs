using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Dropdown("DoorTypes")]
    private string doorType;

    private List<string> DoorTypes
    {
        get
        {
            return new List<string>() { "Start", "Finish" };
        }
    }

    [SerializeField]
    private Animator animator;

    [SerializeField]
    [AnimatorParam("animator")]
    private string open;

    [SerializeField]
    [AnimatorParam("animator")]
    private string close;

    bool wantsToGoNextLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger (open);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (doorType == "Finish") wantsToGoNextLevel = true;
        animator.SetTrigger (close);
    }

    // Called from animator event
    public void DoorClosed()
    {
        if (doorType == "Finish" && wantsToGoNextLevel)
            SceneLoader.Instance.LoadNextLevel();
    }
}
