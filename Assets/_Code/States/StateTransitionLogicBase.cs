using System;
using UnityEngine;

namespace Logic.States
{
    public abstract class StateTransitionLogicBase : MonoBehaviour, IStateTransition
    {
        public abstract void Cancel();

        public abstract void Perform(IState from, IState to);
    }
}