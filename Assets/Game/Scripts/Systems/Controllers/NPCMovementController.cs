using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Game.Scripts.Systems.Controllers
{
    public class NPCMovementController : MonoBehaviour
    {
        public event Action OnRotated;
        public bool IsMoving => IsAgent && agent.velocity.sqrMagnitude > 0.01f;

        private NavMeshAgent agent;
        private bool IsAgent => (agent != null && agent.isOnNavMesh);

        public void Initialize(NavMeshAgent agent)
        {
            this.agent = agent;
        }

        public void MoveTo(Vector3 point)
        {
            if (!IsAgent) return;

            agent.isStopped = false;

            agent.SetDestination(point);
        } 

        public void Stop()
        {
            if (!IsAgent) return;

            agent.isStopped = true;

            agent.ResetPath();
        }

        public bool HasReachedDestination()
        {
            if (!IsAgent) return false;

            if (agent.pathPending) return false;

            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath)
                {
                    return true;
                }
            }

            return false;
        }

        public void RotateTowards(Vector3 direction)
        {
            direction.y = 0;

            if (direction.sqrMagnitude < 0.01f)
            {
                OnRotated?.Invoke();

                return;
            }

            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, agent.angularSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                transform.rotation = targetRotation;

                OnRotated?.Invoke();
            }
        }
    }
}
