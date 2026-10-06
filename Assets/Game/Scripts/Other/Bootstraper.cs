using System;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;

    private PlayerControls controls;
    private void Awake()
    {
        CursorController.Lock();

        controls = new PlayerControls();

        movement.Initialize(controls);
    }

    private void OnEnable()
    {
        controls?.Enable();
    }

    private void OnDisable()
    {
        controls?.Disable();
    }
}
