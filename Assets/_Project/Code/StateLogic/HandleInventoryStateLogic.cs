using Logic.States;
using StarterAssets;
using UnityEngine;

namespace Code.StateLogic
{
    public class HandleInventoryStateLogic : SwitchStateCondition
    {
        [SerializeField] protected StarterAssetsInputs _input = null;
        public override bool Condition
        {
            get
            {
                if (_input.inventory)
                {
                    _input.inventory = false;
                    return true;
                }

                return false;
            }
        }
    }
}