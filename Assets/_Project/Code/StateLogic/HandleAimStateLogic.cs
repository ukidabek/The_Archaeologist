using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public class HandleAimStateLogic : SwitchStateLogic
    {
        [SerializeField] protected StarterAssetsInputs _input = null;
        [SerializeField] private bool _aimStatus = true;
        protected override bool Condition => _aimStatus == _input.aim;
    }
}