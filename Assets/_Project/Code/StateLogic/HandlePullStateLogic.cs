using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public class HandlePullStateLogic : SwitchStateLogic
    {
        [SerializeField] protected StarterAssetsInputs _input = null;
        [SerializeField] private bool _pullStatus = true;
        protected override bool Condition => _pullStatus == _input.pull;

        private bool _initialState = false;

        private bool _lock = true;
        
        public override void Activate()
        {
            _initialState = _input.pull;
            _lock = true;
        }

        public override void OnUpdate(float deltaTime)
        {
            if (_lock && _initialState == _input.pull)
                return;
            _lock = false;
            base.OnUpdate(deltaTime);
        }
    }
}