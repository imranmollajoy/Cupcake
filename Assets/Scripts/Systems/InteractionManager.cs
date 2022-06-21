using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance;

    public Action InteractPressed;

    private PlayerInputActions controls;

    [SerializeField]
    private GameObject interactionButton;

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

    void Start()
    {
        // set the interaction button of ui manager to this interaction button
        UIManager.Instance.InteractButton = interactionButton;
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
