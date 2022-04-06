using System.Linq;
using Logic.States;
using UnityEngine;

public class TargetOutOfRangeAICondition : SwitchStateCondition
{
    [SerializeField] private TargetDetectAIStateLogic _targetDetectAIStateLogic = null;
    [SerializeField] private float _minimalDistance = 5;
    public override bool Condition
    {
        get
        {
            var conditionA = !_targetDetectAIStateLogic.Targets.Any();
            var conditionB =
                Vector3.Distance(transform.position, _targetDetectAIStateLogic.Targets[0].transform.position) >
                _minimalDistance;
            
            return conditionA || conditionB;
        }
    }
}