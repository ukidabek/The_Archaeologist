using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public class HandlePullStateLogic : SwitchStateCondition
    {
        [SerializeField] protected StarterAssetsInputs _input = null;
        [SerializeField] private bool _pullStatus = true;
        public override bool Condition => _pullStatus == _input.pull;
        
        public override void Activate()
        {
            _input.pull = false;
        }
    }
}