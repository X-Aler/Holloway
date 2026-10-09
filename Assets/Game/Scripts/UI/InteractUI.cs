using Assets.Game.Scripts.Models;
using TMPro;
using UnityEngine;

public class InteractUI : MonoBehaviour, ISetupable
{
    [SerializeField] private TMP_Text interactKeyText;

    private Camera playerCamera;

    public void Setup(string[] args)
    {
        interactKeyText.text = args[0];

        playerCamera = Camera.main;

        Canvas canvas = GetComponent<Canvas>();

        if (canvas != null)
            canvas.worldCamera = playerCamera;
    }

    private void LateUpdate()
    {
        if (playerCamera == null)
            return;

        transform.forward = playerCamera.transform.forward;
    }
}