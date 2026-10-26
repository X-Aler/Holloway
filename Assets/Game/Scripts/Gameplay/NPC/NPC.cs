using Assets.Game.Scripts.Core.CommandCore;
using Assets.Game.Scripts.Core.FSM;
using Assets.Game.Scripts.Core.FSM.States;
using Assets.Game.Scripts.Models;
using Assets.Game.Scripts.Systems.Controllers;
using Assets.Game.Scripts.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using VContainer;

namespace Assets.Game.Scripts.Gameplay.NPC
{
    [RequireComponent(typeof(NPCMovementController), typeof(NavMeshAgent))]
    public class NPC : MonoBehaviour
    {
        [SerializeField] private NPCData data;
        [SerializeField] private Transform handPosition;
        [SerializeField] private Slider moodSlider;
        private StateMachine stateMachine;
        public Transform HandPosition => handPosition;
        public Slider MoodSlider => moodSlider;
        public NPCData Data => data;
        public NPCMovementController MovementController { get; private set; }
        public PointStorage PointStorage { get; private set; }
        public GameTimeManager GameTimeManager { get; private set; }
        public CommandsRunner CommandsRunner { get; private set; }
        public AliveState AliveState { get; private set;  }
        public DeadState DeadState { get; private set;  }
        public NavMeshAgent Agent { get; private set; }
        public MoodController MoodController { get; private set; }
        private MoodPresenter moodPresenter;

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

            MoodController = new MoodController(this, data.MoodData);

            var moodUI = new MoodUI(moodSlider);

            moodPresenter = new MoodPresenter(MoodController, moodUI);

            initialized = true;
        }

        public void Update()
        {
            if (!initialized) return;

            stateMachine.CurrentState.Update();
        }

        private void OnDestroy()
        {
            moodPresenter.Dispose();
        }
    }
}
