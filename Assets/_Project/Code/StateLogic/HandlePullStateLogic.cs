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
        
        public override void Activate()
        {
            _input.pull = false;
        }
    }
}