using System.Collections.Generic;
using UnityEngine;

namespace Logic.States
{
    public class State : MonoBehaviour, IState
    {
        [SerializeField] private StateLogic[] m_logic = null;
        public  IEnumerable<IStateLogic> Logic => m_logic;

        public void Enter()
        {
            foreach (var stateLogic in Logic) 
                stateLogic.Activate();
        }

        public void Exit()
        {
            foreach (var stateLogic in Logic) 
                stateLogic.Deactivate();
        }
    }
}