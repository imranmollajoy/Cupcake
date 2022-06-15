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

    // Start is called before the first frame update
    void Start()
    {
        if (doorType == "Start")
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
