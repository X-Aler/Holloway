using System;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private ManualController manualController;
    [SerializeField] private GameTimeManager gameTimeManager;
    [SerializeField] private GameTimeUIHandler gameTimeUIHandler;

    private PlayerControls controls;
    private void Awake()
    {
        CursorController.Lock();

        controls = new PlayerControls();

        movement.Initialize(controls);
        manualController.Initialize(controls);

        gameTimeManager.Initialzie();
        gameTimeUIHandler.Initialzie(gameTimeManager);

        gameTimeManager.StartShift();
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
