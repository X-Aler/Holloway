using Assets.Game.Scripts.Models;
using Assets.Game.Scripts.UI;
using System;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ManualController manualController;
    [SerializeField] private GameTimeManager gameTimeManager;
    [SerializeField] private GameTimeUIHandler gameTimeUIHandler;
    [SerializeField] private InteractableManager interactableManager;
    [SerializeField] private InteractableUIHandler interactableUIHandler;
    [SerializeField] private NPCSpawner npcSpawner;
    [SerializeField] private PointStorage pointStorage;

    private PlayerControls controls;
    private void Awake()
    {
        CursorController.Lock();

        controls = new PlayerControls();

        player.Initialize(controls);
        manualController.Initialize(controls);

        interactableManager.Initialize(controls);
        interactableUIHandler.Initialize(interactableManager, controls);

        gameTimeManager.Initialzie();
        gameTimeUIHandler.Initialzie(gameTimeManager);

        npcSpawner.Initialize(gameTimeManager, pointStorage, player);

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
