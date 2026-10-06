using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private CharacterController controller;
    private PlayerControls playerControls;
    private Transform cameraTransform;
    private bool initialized = false;

    public void Initialize(PlayerControls controls)
    {
        playerControls = controls;

        controller = GetComponent<CharacterController>();

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

        var camForward = GetCameraVector(cameraTransform.forward);
        var camRight = GetCameraVector(cameraTransform.right);

        var moveVector = camRight * value.x + camForward * value.y;

        controller.Move(moveVector * speed * Time.deltaTime);
    }

    private Vector3 GetCameraVector(Vector3 camVector)
    {
        camVector.y = 0;

        camVector.Normalize();

        return camVector;
    }
}
