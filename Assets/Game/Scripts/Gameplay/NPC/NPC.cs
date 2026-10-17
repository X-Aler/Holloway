using Assets.Game.Scripts.Core.FSM;
using Assets.Game.Scripts.Systems.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.Gameplay.NPC
{
    public class NPC : MonoBehaviour
    {
        [SerializeField] private NPCData data;
        [SerializeField] private Transform handPosition;
        private StateMachine stateMachine;
        public Transform HandPosition => handPosition;
        public MovementController MovementController { get; private set; }
        private List<IState> states;
        private int stateIndex = 0;

        public void Initialize(List<IState> states)
        {
            MovementController = GetComponent<MovementController>();

            MovementController.Initialize();

            stateMachine = new StateMachine();

            this.states = states;

            stateMachine.Initialize(states[stateIndex]);
        }

        public void Update()
        {
            stateMachine.CurrentState.Update();
        }

        public void GetToNextState()
        {
            stateIndex++;

            stateMachine.ChangeState(states[stateIndex]);
        }
    }
}
