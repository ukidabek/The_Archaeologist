using UnityEngine;

namespace Logic.States
{
    public abstract class StateLogicExecutor : MonoBehaviour
    {
        public abstract void ClearLogicToExecute();
        public abstract void SetLogicToExecute(State state);
    }
}