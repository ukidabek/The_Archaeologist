using System;
using UnityEngine;

namespace Logic.States
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] private State m_currentState = null;
        public State CurrentState => m_currentState;

        [SerializeField] private StateLogicExecutor m_logicExecutor;
        
        public void EnterState(State statToEnter)
        {
            if(m_currentState == statToEnter) return;
            
            m_logicExecutor.ClearLogicToExecute();
            
            m_currentState?.Exit();
            m_currentState = statToEnter;
            m_currentState?.Enter();
            
            m_logicExecutor.SetLogicToExecute(m_currentState);
        }
    }
}
