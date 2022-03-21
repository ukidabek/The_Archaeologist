using UnityEngine;

namespace Logic.States
{
    public abstract class FromToTransitionLogicBase : StateTransitionLogicBase
    {
        [SerializeField] private Object _fromStateObject = null;
        [SerializeField] private Object _toStateObject = null;

        private IState _fromState = null;
        private IState _toState = null;
        
        protected virtual void Awake()
        {
            _fromState = _fromStateObject as IState;
            _toState = _toStateObject as IState;

        }

        public override void Perform(IState @from, IState to)
        {
            if (@from == _fromState && to == _toState)
            {
                Perform();
            }
        }

        protected abstract void Perform();
    }
}