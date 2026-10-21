using Assets.Game.Scripts.Core;
using Assets.Game.Scripts.Models;
using Assets.Game.Scripts.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Player player;
    [SerializeField] private ManualController manualController;
    [SerializeField] private GameTimeManager gameTimeManager;
    [SerializeField] private GameTimeUIHandler gameTimeUIHandler;
    [SerializeField] private InteractableManager interactableManager;
    [SerializeField] private InteractableUIHandler interactableUIHandler;
    [SerializeField] private NPCSpawner npcSpawner;
    [SerializeField] private PointStorage pointStorage;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<PlayerControls>(Lifetime.Singleton);

        builder.RegisterComponent(player);
        builder.RegisterComponent(manualController);
        builder.RegisterComponent(gameTimeManager);
        builder.RegisterComponent(gameTimeUIHandler);
        builder.RegisterComponent(interactableManager);
        builder.RegisterComponent(interactableUIHandler);
        builder.RegisterComponent(pointStorage);
        builder.RegisterComponent(npcSpawner);
 
        builder.RegisterEntryPoint<GameEntryPoint>();
    }
}
