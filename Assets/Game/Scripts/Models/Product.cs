using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Models
{
    public class Product : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform interactPosition;
        public Transform UIPosition => interactPosition;
        public void Interact()
        {
            Debug.Log("Взаимодействие!");
        }
    }
}
