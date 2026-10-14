using System;
using System.Text;
using UnityEngine;

namespace Assets.Game.Scripts.Utils.Camera
{
    public static class MovementMath
    {
        public static Vector3 Flatten(Vector3 vector)
        {
            vector.y = 0;

            return vector;
        }

        public static Vector3 GetCameraDirection(Vector2 input, Transform cameraTransform)
        {
            var camForward = Flatten(cameraTransform.forward);
            var camRight = Flatten(cameraTransform.right);

            var moveVector = camRight * input.x + camForward * input.y;

            return moveVector;
        }
    }
}
