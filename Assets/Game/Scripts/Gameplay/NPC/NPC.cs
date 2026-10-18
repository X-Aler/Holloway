using Assets.Game.Scripts.Core.CommandCore;
using Assets.Game.Scripts.Core.FSM;
using Assets.Game.Scripts.Core.FSM.States;
using Assets.Game.Scripts.Models;
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
        public CommandsRunner CommandsRunner { get; private set; }
        public AliveState AliveState { get; private set;  }
        public DeadState DeadState { get; private set;  }

        private bool initialized = false;

        public void Initialize(PointStorage pointStorage)
        {
            MovementController = GetComponent<MovementController>();

            MovementController.Initialize();

            CommandsRunner = new CommandsRunner();

            stateMachine = new StateMachine();

            AliveState = new AliveState(this, pointStorage, stateMachine);
            DeadState = new DeadState();

            stateMachine.Initialize(AliveState);

            initialized = true;
        }

        public void Update()
        {
            if (!initialized) return;

            stateMachine.CurrentState.Update();
        }
    }
}
