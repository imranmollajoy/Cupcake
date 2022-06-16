using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Door : Interactable
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

    // Start is called before the first frame update
    void Start()
    {
        if (doorType == "Start")
        {
            IsInteractable = false;
            animator.SetTrigger (open);
        }
    }

    public override void PlayerEntered()
    {
        return;
    }

    public override void PlayerExited()
    {
        return;
    }

    public override void Interact()
    {
        return;
    }
}
