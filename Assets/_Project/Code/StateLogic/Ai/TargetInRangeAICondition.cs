using System.Linq;
using Logic.States;
using UnityEngine;

public class TargetInRangeAICondition : SwitchStateCondition
{
    [SerializeField] private TargetDetectAIStateLogic _targetDetectAIStateLogic = null;
    public override bool Condition => _targetDetectAIStateLogic.Targets.Any();
}