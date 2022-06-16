using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // create singelton
    public static UIManager Instance;

    [SerializeField]
    private GameObject downButton;

    public GameObject DownButton
    {
        get
        {
            return downButton;
        }
    }

    [SerializeField]
    private GameObject interactButton;

    public GameObject InteractButton
    {
        get
        {
            return interactButton;
        }
    }

    [SerializeField]
    private TextMeshProUGUI diamondText;

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
