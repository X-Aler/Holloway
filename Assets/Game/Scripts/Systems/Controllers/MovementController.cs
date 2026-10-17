using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Systems.Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float distanceOffset = 0.1f;
        private CharacterController characterController;
        private GravityController gravityController;
        public float Speed => speed;
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
            if (!HasReachedDestination(move)) return;
                
            var vecticalMove = Vector3.zero;

            if (gravityController != null)
                vecticalMove.y = gravityController.Velocity;

            var horizontalMove = Vector3.zero;

            move.y = 0;

            if (move != Vector3.zero)
            {
                horizontalMove = move.normalized * speed;
            }

            var finalMove = horizontalMove + vecticalMove;

            characterController.Move(finalMove * Time.deltaTime);
        }

        private bool HasReachedDestination(Vector3 move)
        {
            IsMoving = true;

            if (move.sqrMagnitude < distanceOffset * distanceOffset)
            {
                IsMoving = false;
                OnReached?.Invoke();
            }

            return IsMoving;
        }

        public void SetSpeed(float newSpeed) => speed = newSpeed;
    }
}
