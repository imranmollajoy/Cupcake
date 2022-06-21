using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    [Header("Panels")]
    public GameObject levelSelectionPanel;

    public GameObject optionsPanel;

    public GameObject creditsPanel;

    [Header("Animators")]
    public Animator panelAnimator;

    private string desiredPanel;

    private GameObject openedPanel;

    // triggered by panelCanvas
    public void PanelOpened()
    {
        if (desiredPanel == "LevelSelection")
        {
            levelSelectionPanel.SetActive(true);
            openedPanel = levelSelectionPanel;
        }
        else if (desiredPanel == "Options")
        {
            optionsPanel.SetActive(true);
            openedPanel = optionsPanel;
        }
        else if (desiredPanel == "Credits")
        {
            creditsPanel.SetActive(true);
            openedPanel = creditsPanel;
        }
    }

    public void OpenPanel(string panelName)
    {
        desiredPanel = panelName;
        panelAnimator.SetTrigger("Open");
    }

    public void ClosePanel()
    {
        openedPanel.SetActive(false);
        panelAnimator.SetTrigger("Close");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string levelID)
    {
        SceneLoader.Instance.LoadScene("Level" + levelID);
    }
}
