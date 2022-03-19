using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public class HandleAimStateLogic : SwitchStateCondition
    {
        [SerializeField] protected StarterAssetsInputs _input = null;
        [SerializeField] private bool _aimStatus = true;
        public override bool Condition => _aimStatus == _input.aim;
    }
}