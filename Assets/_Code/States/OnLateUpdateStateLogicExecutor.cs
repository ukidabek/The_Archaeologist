﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Logic.States
{
    public class OnLateUpdateStateLogicExecutor : StateLogicExecutor
    {
        private IEnumerable<IOnLateUpdateLogic> _logic = null;
        
        public override void ClearLogicToExecute()
        {
        }

        public override void SetLogicToExecute(IState state)
        {
            _logic = state.Logic.OfType<IOnLateUpdateLogic>();
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            foreach (var onUpdateLogic in _logic) 
                onUpdateLogic.OnLateUpdate(deltaTime);
        }
    }
}