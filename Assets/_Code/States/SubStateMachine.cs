using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Logic.States
{
    public class SubStateMachine : StateLogic, IStateMachine, IOnUpdateLogic, IOnFixUpdateLogic, IOnLateUpdateLogic
    {
        [SerializeField] private State _currentState = null;
        public IState CurrentState => _currentState;
        
        private IEnumerable<IOnUpdateLogic> _currentStateOnUpdateLogic = null;
        private IEnumerable<IOnFixUpdateLogic> _currentStateOnFixUpdateLogic = null;
        private IEnumerable<IOnLateUpdateLogic> _currentStateOnLateUpdateLogic = null;
      
        private IEnumerable<T> Cast<T>(IState state) => state.Logic.OfType<T>();
        
        public void EnterState(IState statToEnter)
        {
            _currentState?.Exit();
            if (statToEnter is State state)
                _currentState = state;
            
            var logic = statToEnter.Logic;
            _currentStateOnUpdateLogic = logic.OfType<IOnUpdateLogic>();
            _currentStateOnFixUpdateLogic = logic.OfType<IOnFixUpdateLogic>();
            _currentStateOnLateUpdateLogic = logic.OfType<IOnLateUpdateLogic>();
            
            _currentState?.Enter();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var onUpdateLogic in _currentStateOnUpdateLogic) 
                onUpdateLogic.OnUpdate(deltaTime);
        }

        public void OnFixUpdate(float deltaTime)
        {
            foreach (var onUpdateLogic in _currentStateOnFixUpdateLogic) 
                onUpdateLogic.OnFixUpdate(deltaTime);
        }

        public void OnLateUpdate(float deltaTime)
        {
            foreach (var onUpdateLogic in _currentStateOnLateUpdateLogic) 
                onUpdateLogic.OnLateUpdate(deltaTime);
        }
    }
}