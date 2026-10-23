using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Systems.Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float rotationSpeed = 5f;
        private CharacterController characterController;
        private GravityController gravityController;
        public float MovementSpeed => movementSpeed;
        public bool IsMoving { get; private set; }

        public void Initialize()
        {
            characterController = GetComponent<CharacterController>();

            if (TryGetComponent<GravityController>(out var gController))
            {
                gravityController = gController;

                gravityController.Initialize(characterController);
            }
        }

        public void Move(Vector3 direction)
        {
            direction.y = 0;

            IsMoving = direction.sqrMagnitude > 0.01f;

            ApplyMove(direction);
        } 

        private void ApplyMove(Vector3 move)
        {
            var horizontalMove = Vector3.zero;

            if (IsMoving)
            {
                horizontalMove = move.normalized * movementSpeed;

                RotateTowards(horizontalMove);
            }

            var vecticalMove = Vector3.zero;

            if (gravityController != null)
                vecticalMove.y = gravityController.Velocity;

            var finalMove = horizontalMove + vecticalMove;

            characterController.Move(finalMove * Time.deltaTime);
        }


        public void SetSpeed(float newSpeed) => movementSpeed = newSpeed;

        private void RotateTowards(Vector3 direction)
        {
            direction.y = 0;

            if (direction.sqrMagnitude < 0.01f)
            {
                return;
            }

            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                transform.rotation = targetRotation;
            }
        }
    }
}
