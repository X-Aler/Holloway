using Assets.Game.Scripts.Core.CommandCore;
using Assets.Game.Scripts.Core.FSM;
using Assets.Game.Scripts.Core.FSM.States;
using Assets.Game.Scripts.Models;
using Assets.Game.Scripts.Systems.Controllers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Assets.Game.Scripts.Gameplay.NPC
{
    [RequireComponent(typeof(NPCMovementController))]
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

        private bool initialized = false;

        public void Initialize(PointStorage pointStorage, GameTimeManager manager)
        {
            MovementController = GetComponent<NPCMovementController>();

            MovementController.Initialize();

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
