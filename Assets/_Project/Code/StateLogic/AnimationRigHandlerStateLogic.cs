using System;
using UnityEngine;

namespace Code.StateLogic
{
    public class AnimationRigHandlerStateLogic : Logic.States.StateLogic
    {
        [Serializable]
        public class RigHandlerSettingsPair
        {
            [SerializeField] private RigHandler _handler = null;
            public RigHandler Handler => _handler;

            [SerializeField] private TransitionSettings _settings;
            public TransitionSettings Settings => _settings;
        }
        
        [SerializeField] private RigHandlerSettingsPair[] _handlerSettingsPairs = null; 
        
        public override void Activate()
        {
            foreach (var handlerSettingsPair in _handlerSettingsPairs)
            {
                var handler = handlerSettingsPair.Handler;
                handler.Settings = handlerSettingsPair.Settings;
                handler.Activate();
            }
        }
        
        public override void Deactivate()
        {
            foreach (var handlerSettingsPair in _handlerSettingsPairs)
            {
                var handler = handlerSettingsPair.Handler;
                handler.Settings = handlerSettingsPair.Settings;
                handler.Deactivate();
            }
        }
    }
}