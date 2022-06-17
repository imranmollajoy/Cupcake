using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementUnlocked : MonoBehaviour
{
    private Animator animator;

    [SerializeField]
    private TextMeshProUGUI achievementText;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowAchievement(
        int id = 0,
        string achievementText = "Wow cool you achieved something congrats!"
    )
    {
        animator.SetTrigger("Show");
        this.achievementText.text = achievementText;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
