using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Collider2D))]
public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact();

    public abstract void PlayerEntered();

    public abstract void PlayerExited();

    private bool isInteractable = true;

    public bool IsInteractable
    {
        get
        {
            return isInteractable;
        }
        set
        {
            isInteractable = value;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.ShowInteractButton (isInteractable);
            PlayerEntered();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && isInteractable)
        {
            UIManager.Instance.ShowInteractButton(false);
            PlayerExited();
        }
    }
}
