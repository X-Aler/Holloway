using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private CharacterController controller;
    private PlayerControls playerControls;
    private bool initialized = false;

    public void Initialize(PlayerControls controls)
    {
        playerControls = controls;

        controller = GetComponent<CharacterController>();

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

        var moveVector = transform.right * value.x + transform.forward * value.y;

        controller.Move(moveVector * speed * Time.deltaTime);
    }
}
