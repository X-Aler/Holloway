using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Systems.Controllers
{
    [RequireComponent(typeof(CharacterController))]
    public class GravityController : MonoBehaviour
    {
        [SerializeField] private float gravity = -9.81f;
        private CharacterController characterController;
        private float velocity;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            ApplyGravity();
        }

        private void ApplyGravity()
        {
            if (characterController.isGrounded && velocity > 0)
                velocity = -1f;
            else
                velocity += gravity * Time.deltaTime;

            var move = new Vector3(0, velocity, 0);

            characterController.Move(move * Time.deltaTime);
        }
    }
}
