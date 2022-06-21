using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // create singelton
    public static UIManager Instance;

    private GameObject downButton;

    public GameObject DownButton
    {
        get
        {
            return downButton;
        }
        set
        {
            downButton = value;
        }
    }

    private GameObject interactButton;

    public GameObject InteractButton
    {
        get
        {
            return interactButton;
        }
        set
        {
            interactButton = value;
        }
    }

    private TextMeshProUGUI diamondText;

    public TextMeshProUGUI DiamondText
    {
        get
        {
            return diamondText;
        }
        set
        {
            diamondText = value;
        }
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy (gameObject);
        }
    }

    public void UpdateDiamondCounter(int diamond)
    {
        // update diamond counter
        diamondText.text = diamond.ToString();
    }

    public void ShowInteractButton(bool show)
    {
        // show interact button
        interactButton.SetActive (show);
    }
}
