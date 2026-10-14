using Assets.Game.Scripts.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] private const float INTERACT_DISTANCE = 10;
    public event Action<Transform> OnInteractableChanged;
    private Camera playerCamera;
    private PlayerControls playerControls;
    private IInteractable currentInteractable;
    private Coroutine findInteractableCoroutine;
   
    public void Initialize(PlayerControls controls)
    {
        playerCamera = Camera.main;

        playerControls = controls;

        findInteractableCoroutine = StartCoroutine(FindInteractable());

        playerControls.Player.Interact.performed += Interact;
    }

    private void OnDestroy()
    {
        if (playerControls != null)
            playerControls.Player.Interact.performed -= Interact;

        if (findInteractableCoroutine != null)
            StopCoroutine(findInteractableCoroutine);
    }

    private IEnumerator FindInteractable()
    {
        while (true)
        {
            IInteractable foundInteractable = null;
            Transform foundTransform = null;

            Ray rayOrigin = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            if (Physics.Raycast(rayOrigin, out var hit, INTERACT_DISTANCE))
            {
                if (hit.transform.TryGetComponent<IInteractable>(out var interactable))
                {
                    foundInteractable = interactable;
                    foundTransform = hit.transform;
                }
            }

            if (currentInteractable != foundInteractable)
            {
                currentInteractable = foundInteractable;

                OnInteractableChanged?.Invoke(foundTransform);
            }

            yield return null;
        }
    }

    private void Interact(InputAction.CallbackContext context) => currentInteractable?.Interact();

}
