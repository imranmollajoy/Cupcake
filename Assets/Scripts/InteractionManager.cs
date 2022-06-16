using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[DefaultExecutionOrder(-80)]
public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    public Action InteractPressed;

    private PlayerInputActions controls;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        controls = new PlayerInputActions();
    }

    void OnEnable()
    {
        // Enable input actions
        controls.UI.Enable();
    }

    void OnDisable()
    {
        // Disable input actions
        controls.UI.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (controls.UI.Interact.triggered)
        {
            InteractPressed?.Invoke();
        }
    }
}
