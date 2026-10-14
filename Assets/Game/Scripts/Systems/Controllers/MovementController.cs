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
        private CharacterController controller;
        public float Speed => speed;

        public void Move(Vector3 direction)
        {
            if (controller == null)
                controller = GetComponent<CharacterController>();

            direction.Normalize();

            controller.Move(direction * speed * Time.deltaTime);
        }

        public void SetSpeed(float newSpeed) => speed = newSpeed;
    }
}
