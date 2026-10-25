using Assets.Game.Scripts.Core.CommandCore;
using Assets.Game.Scripts.Core.FSM;
using Assets.Game.Scripts.Core.FSM.States;
using Assets.Game.Scripts.Models;
using Assets.Game.Scripts.Systems.Controllers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace Assets.Game.Scripts.Gameplay.NPC
{
    [RequireComponent(typeof(NPCMovementController), typeof(NavMeshAgent))]
    public class NPC : MonoBehaviour
    {
        [SerializeField] private NPCData data;
        [SerializeField] private Transform handPosition;
        private StateMachine stateMachine;
        public Transform HandPosition => handPosition;
        public NPCMovementController MovementController { get; private set; }
        public PointStorage PointStorage { get; private set; }
        public GameTimeManager GameTimeManager { get; private set; }
        public CommandsRunner CommandsRunner { get; private set; }
        public AliveState AliveState { get; private set;  }
        public DeadState DeadState { get; private set;  }
        public NavMeshAgent Agent { get; private set; }

        private bool initialized = false;

        public void Initialize(PointStorage pointStorage, GameTimeManager manager)
        {
            Agent = GetComponent<NavMeshAgent>();

            MovementController = GetComponent<NPCMovementController>();

            MovementController.Initialize(Agent);

            PointStorage = pointStorage;

            GameTimeManager = manager;

            var commands = data.CommandsPool.Select(c => c.GetCommand(this));

            CommandsRunner = new CommandsRunner(commands);

            stateMachine = new StateMachine();

            AliveState = new AliveState(this, stateMachine);
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
