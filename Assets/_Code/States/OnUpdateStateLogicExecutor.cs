﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Logic.States
{
    public class OnUpdateStateLogicExecutor : StateLogicExecutor
    {
        private IEnumerable<IOnUpdateLogic> _logic = null;
        
        public override void ClearLogicToExecute()
        {
        }

        public override void SetLogicToExecute(IState state)
        {
            _logic = state.Logic.OfType<IOnUpdateLogic>();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            foreach (var onUpdateLogic in _logic) 
                onUpdateLogic.OnUpdate(deltaTime);
        }
    }
}