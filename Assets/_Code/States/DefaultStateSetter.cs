using UnityEngine;

namespace Logic.States
{
    public class DefaultStateSetter : MonoBehaviour
    {
        [SerializeField] private StateManager _stateManager = null;
        [SerializeField] private State _defaultState = null;

        private void Start()
        {
            _stateManager.EnterState(_defaultState);
        }
    }
}