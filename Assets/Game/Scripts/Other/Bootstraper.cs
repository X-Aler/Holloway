using Assets.Game.Scripts.UI;
using System;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private ManualController manualController;
    [SerializeField] private GameTimeManager gameTimeManager;
    [SerializeField] private GameTimeUIHandler gameTimeUIHandler;
    [SerializeField] private InteractableManager interactableManager;
    [SerializeField] private InteractableUIHandler interactableUIHandler;

    private PlayerControls controls;
    private void Awake()
    {
        CursorController.Lock();

        controls = new PlayerControls();

        movement.Initialize(controls);
        manualController.Initialize(controls);

        gameTimeManager.Initialzie();
        gameTimeUIHandler.Initialzie(gameTimeManager);

        interactableManager.Initialize(controls);
        interactableUIHandler.Initialize(interactableManager, controls);

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
