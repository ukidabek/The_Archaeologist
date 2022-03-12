using UnityEngine;

namespace Logic.States
{
    public class State : MonoBehaviour
    {
        [SerializeField] private StateLogic[] m_logic = null;
        public StateLogic[] Logic => m_logic;

        public void Enter()
        {
            foreach (var stateLogic in m_logic) 
                stateLogic.Activate();
        }

        public void Exit()
        {
            foreach (var stateLogic in m_logic) 
                stateLogic.Deactivate();
        }
    }
}