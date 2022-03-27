using UnityEngine.Events;

namespace Code.StateLogic
{
    public class EventTriggerStateLogic : Logic.States.StateLogic
    {
        public UnityEvent OnActivateCallBack = new UnityEvent();
        public UnityEvent OnDeactivateCallBack = new UnityEvent();

        public override void Activate() => OnActivateCallBack.Invoke();

        public override void Deactivate() => OnDeactivateCallBack.Invoke();
    }
}