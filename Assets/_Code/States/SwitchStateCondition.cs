using UnityEngine;

namespace Logic.States
{
    public abstract class SwitchStateCondition : MonoBehaviour, ISwitchStateCondition
    {
        public abstract bool Condition { get; }
        public virtual void Activate() {}
        public virtual void Deactivate() {}
    }
}