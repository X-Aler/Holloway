using Assets.Game.Scripts.UI;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] private const float INTERACT_DISTANCE = 10;
    public event Action<Transform> OnInteractableChanged;
    private Camera playerCamera;
    private PlayerControls playerControls;
    private IInteractable currentInteractable;

    [Inject]
    public void Construct(PlayerControls controls)
    {
        playerCamera = Camera.main;

        playerControls = controls;

        playerControls.Player.Interact.performed += Interact;

        FindInteractable(this.GetCancellationTokenOnDestroy()).Forget();
    }

    private void OnDestroy()
    {
        if (playerControls != null)
            playerControls.Player.Interact.performed -= Interact;
    }

    private async UniTask FindInteractable(CancellationToken token)
    {
        while (true)
        {
            if (token.IsCancellationRequested) return;

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

            await UniTask.NextFrame(token);
        }
    }

    private void Interact(InputAction.CallbackContext context) => currentInteractable?.Interact();

}
