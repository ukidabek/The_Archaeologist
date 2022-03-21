using UnityEngine;

namespace Code.StateLogic
{
    public class EnableDisableMonoBehaviourStateLogic : Logic.States.StateLogic
    {
        [SerializeField] private MonoBehaviour _component = null;

        public override void Activate()
        {
            _component.enabled = true;
        }

        public override void Deactivate()
        {
            _component.enabled = false;
        }
    }
}