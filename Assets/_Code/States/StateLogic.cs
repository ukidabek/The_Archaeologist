using System;
using UnityEngine;

namespace Logic.States
{
    public abstract class StateLogic : MonoBehaviour, IStateLogic
    {
        public virtual void Activate() {}
        public virtual void Deactivate() {}

        protected void Reset()
        {
            ChangeObjectName();
        }

        [ContextMenu("Change object name")]
        private void ChangeObjectName()
        {
            if (gameObject.GetComponents<StateLogic>().Length > 1) return;
            gameObject.name = GetType().Name;
        }
    }
}