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

    bool wantsToGoNextLevel = false;

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
        animator.SetTrigger (open);
    }

    public override void PlayerExited()
    {
        animator.SetTrigger (close);
    }

    public override void Interact()
    {
        animator.SetTrigger (close);
        wantsToGoNextLevel = true;
    }

    public void DoorClosed()
    {
        if (IsInteractable && wantsToGoNextLevel)
            SceneLoader.Instance.LoadNextLevel();
    }
}
