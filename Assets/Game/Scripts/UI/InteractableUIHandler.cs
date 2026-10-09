using Assets.Game.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Game.Scripts.UI
{
    public class InteractableUIHandler : MonoBehaviour
    {
        [SerializeField] private GameObject interactPrefab;
        private PlayerControls playerControls;
        private GameObject ui;

        public void Initialize(InteractableManager manager, PlayerControls controls)
        {
            manager.OnInteractableChanged += CreateUI;

            playerControls = controls;
        }

        public void CreateUI(Transform interactObject)
        {
            DestroyUI();

            if (interactObject == null) return;

            ui = Instantiate(interactPrefab);

            var setupable = ui.GetComponent<ISetupable>();

            var interactKey = playerControls.Player.Interact.GetBindingDisplayString();
            setupable.Setup(new string[1] {interactKey});

            var interactable = interactObject.GetComponent<IInteractable>();

            ui.transform.position = interactable.UIPosition.position;
        }

        public void DestroyUI()
        {
            if (ui == null) return;

            Destroy(ui);
            ui = null;
        }
    }
}
