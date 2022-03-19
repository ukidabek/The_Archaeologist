﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Logic.States
{
    public interface ISwitchStateCondition
    {
        bool Condition { get; }
        void Activate();
        void Deactivate();
    }
    
    public abstract class SwitchStateCondition : MonoBehaviour, ISwitchStateCondition
    {
        public abstract bool Condition { get; }
        public virtual void Activate() {}
        public virtual void Deactivate() {}
    }
    
    public class SwitchStateLogic : StateLogic, IOnUpdateLogic
    {
        private enum ConditionMode
        {
            All, Any
        }

        [SerializeField] private ConditionMode _mode = ConditionMode.All;
        [SerializeField] private GameObject _stateMachineObject = null;

        private IStateMachine _stateMachine = null;
        
        [SerializeField] private State _stateToEnter = null;
        private IState StateToEnter => _stateToEnter;

        [SerializeField] private Object[] _conditionsObjects = null;
        private IEnumerable<ISwitchStateCondition> _stateConditions = null;

        private bool Condition
        {
            get
            {
                switch (_mode)
                {
                    case ConditionMode.All:
                        return _stateConditions.All(condition => condition.Condition);
                    case ConditionMode.Any:
                         return _stateConditions.Any(condition => condition.Condition);
                    default:
                        return false;
                }
            }
        }

        private void Awake()
        {
            _stateMachine = _stateMachineObject.GetComponent<IStateMachine>();
            _stateConditions = _conditionsObjects.OfType<ISwitchStateCondition>();
        }

        public override void Activate()
        {
            foreach (var switchStateCondition in _stateConditions) 
                switchStateCondition.Activate();
        }

        public override void Deactivate()
        {
            foreach (var switchStateCondition in _stateConditions)
                switchStateCondition.Deactivate();
        }

        public virtual void OnUpdate(float deltaTime)
        {
            if (Condition && _stateMachine.CurrentState != StateToEnter) 
                _stateMachine.EnterState(StateToEnter);
        }
    }
}