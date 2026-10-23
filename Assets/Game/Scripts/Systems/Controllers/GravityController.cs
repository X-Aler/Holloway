using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Systems.Controllers
{
    public class GravityController : MonoBehaviour
    {
        [SerializeField] private float gravity = -9.81f;
        private float velocity;
        public float Velocity => velocity;
        private bool initialized = false;
        private CharacterController characterController;

        public void Initialize(CharacterController controller)
        {
            characterController = controller;

            initialized = true;
        }

        private void Update()
        {
            if (!initialized) return;

            ApplyGravity();
        }

        private void ApplyGravity()
        {
            if (characterController.isGrounded && velocity < 0)
                velocity = -2f;
            else
                velocity += gravity * Time.deltaTime;
        }
    }
}
