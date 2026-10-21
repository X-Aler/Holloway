using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class ManualController : MonoBehaviour
{
    [SerializeField] private GameObject Manual;
    private PlayerControls playerControls;
    private bool isOpen = false;

    private void Awake()
    {
        Manual.SetActive(isOpen);
    }

    [Inject]
    public void Construct(PlayerControls controls)
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
