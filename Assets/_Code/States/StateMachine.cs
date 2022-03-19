using System;
using System.Collections.Generic;

namespace Logic.States
{
    public class StateMachine : IStateMachine
    {
        public event Action OnStateChange; 
        
        private readonly IEnumerable<IStateLogicExecutor> _stateLogicExecutor = null;
        public IState CurrentState { get; private set; }

        public StateMachine(IEnumerable<IStateLogicExecutor> stateLogicExecutor)
        {
            _stateLogicExecutor = stateLogicExecutor;
        }

        public void EnterState(IState statToEnter)
        {
            if(CurrentState == statToEnter) return;
            
            foreach (var stateLogicExecutor in _stateLogicExecutor) 
                stateLogicExecutor.ClearLogicToExecute();

            CurrentState?.Exit();
            CurrentState = statToEnter;
            
            foreach (var stateLogicExecutor in _stateLogicExecutor) 
                stateLogicExecutor.SetLogicToExecute(CurrentState);
            
            CurrentState?.Enter();
            OnStateChange?.Invoke();
        }
    }
}