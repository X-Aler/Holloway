using Assets.Game.Scripts.Systems.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Game.Scripts.Models
{
    public class Client : MonoBehaviour
    {
        [SerializeField] private Transform handPostiion;
        private MovementController movementController;
        private Vector3 targetPosition;
        private bool isMoving = false;

        private GameObject phoneObject;

        private Action onMoved;

        public void Initialize(GameObject phone)
        {
            movementController = GetComponent<MovementController>();

            phoneObject = phone;
        }

        public void Update()
        {
            if (!isMoving) return;

            var direction = targetPosition - transform.position;
            direction.y = 0;

            if (direction.sqrMagnitude <= 1f)
            {
                StopMove();
                return;
            }

            transform.forward = direction;
            movementController.Move(direction);
        }

        public void MoveTo(Vector3 position, Action onMoveEnd)
        {
            onMoved = onMoveEnd;
            targetPosition = position;
            isMoving = true;
        }
        public void StopMove()
        {
            isMoving = false;
            movementController.Move(Vector3.zero);
            onMoved?.Invoke();
        } 
        public void ShowPhone() 
        {
            var phoneObj = Instantiate(phoneObject, handPostiion.transform);

            phoneObject.transform.localPosition = Vector3.zero;
            phoneObject.transform.localRotation = Quaternion.identity;
        }
    }
}
