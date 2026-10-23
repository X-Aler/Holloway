using Assets.Game.Scripts.Systems.Controllers;
using Assets.Game.Scripts.Utils.Camera;
using UnityEngine;
using VContainer;

public class Player : MonoBehaviour
{
    private PlayerMovementController movementController;
    private PlayerControls playerControls;
    private Transform cameraTransform;
    private bool initialized = false;

    [Inject]
    public void Construct(PlayerControls controls)
    {
        playerControls = controls;

        movementController = GetComponent<PlayerMovementController>();

        movementController.Initialize();

        cameraTransform = Camera.main.transform;

        initialized = true;
    }

    private void Update()
    {
        if (!initialized) return;

        ApplyMovement();
    }

    private void ApplyMovement()
    {
        var value = playerControls.Player.Move.ReadValue<Vector2>();

        var direction = MovementMath.GetCameraDirection(value, cameraTransform);

        movementController.Move(direction);
    }
}
