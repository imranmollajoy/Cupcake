using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public void ChangeAnimationState(Animator animator, string state)
    {
        animator.Play (state);
    }
}
