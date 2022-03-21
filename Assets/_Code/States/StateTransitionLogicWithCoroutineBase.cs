﻿namespace Logic.States
{
    public abstract class StateTransitionLogicWithCoroutineBase : StateTransitionLogicBase
    {
        protected override void Awake()
        {
            base.Awake();
            _manager = new CoroutineManager(this);
        }
        
        public override void Cancel() => _manager.Stop();
    }
}