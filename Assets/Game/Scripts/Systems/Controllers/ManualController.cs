using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManualController : MonoBehaviour
{
    [SerializeField] private GameObject Manual;
    private PlayerControls playerControls;
    private bool isOpen = false;

    private void Awake()
    {
        Manual.SetActive(isOpen);
    }

    public void Initialize(PlayerControls controls)
    {
        playerControls = controls;

        playerControls.Player.Manual.performed += ChangeManualState;
    }

    private void ChangeManualState(InputAction.CallbackContext context) => ChangeState();

    private void ChangeState()
    {
        isOpen = !isOpen;

        Manual.SetActive(isOpen);
    }

}
