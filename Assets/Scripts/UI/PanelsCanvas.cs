using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsCanvas : MonoBehaviour
{
    MainMenuCanvas menu;

    void Awake()
    {
        menu = GetComponentInParent<MainMenuCanvas>();
    }

    // triggered by  animator Event
    public void PanelOpened()
    {
        menu.PanelOpened();
    }
}
