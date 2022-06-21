using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject downButton;

    [SerializeField]
    private TMPro.TextMeshProUGUI diamondText;

    void Start()
    {
        // set the down button of ui manager to this down button
        UIManager.Instance.DownButton = downButton;

        // set the diamond text of ui manager to this diamond text
        UIManager.Instance.DiamondText = diamondText;
    }
}
