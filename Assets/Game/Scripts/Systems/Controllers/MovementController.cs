using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Systems.Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float rotationSpeed = 5f;
        [SerializeField] private float distanceOffset = 0.1f;
        private CharacterController characterController;
        private GravityController gravityController;
        public float MovementSpeed => movementSpeed;
        public bool IsMoving { get; private set; }
        public event Action OnReached;

        public void Initialize()
        {
            characterController = GetComponent<CharacterController>();

            if (TryGetComponent<GravityController>(out var gController))

            gravityController = gController;

            gravityController.Initialize(characterController);
        }

        public void MoveTo(Vector3 point)
        {
            var direction = (point - transform.position);

            Move(direction);
        }

        public void Move(Vector3 direction) => ApplyMove(direction);

        private void ApplyMove(Vector3 move)
        {
            var horizontalMove = Vector3.zero;

            move.y = 0;

            IsMoving = !HasReachedDestination(move);

            if (IsMoving)
            {
                horizontalMove = move.normalized * movementSpeed;

                var targetRotation = Quaternion.LookRotation(horizontalMove);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            var vecticalMove = Vector3.zero;

            if (gravityController != null)
                vecticalMove.y = gravityController.Velocity;

            var finalMove = horizontalMove + vecticalMove;

            characterController.Move(finalMove * Time.deltaTime);
        }

        private bool HasReachedDestination(Vector3 move)
        {
            if (move == Vector3.zero) return true;

            var isReached = false;

            if (move.sqrMagnitude < distanceOffset * distanceOffset)
            {
                isReached = true;
                OnReached?.Invoke();
            }

            return isReached;
        }

        public void SetSpeed(float newSpeed) => movementSpeed = newSpeed;
    }
}
