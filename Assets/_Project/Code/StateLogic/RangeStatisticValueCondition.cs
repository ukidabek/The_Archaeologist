using Logic.States;
using Logic.Statistics;
using UnityEngine;

namespace Code.StateLogic
{
    public class RangeStatisticValueCondition : SwitchStateCondition
    {
        public enum Mode { Less, Grate, LessOrEqual, GrateOrEqual }

        [SerializeField] private Mode _mode = Mode.LessOrEqual;
        [SerializeField] private RangeStatistic _statistic = null;
        [SerializeField] private float _targetValue = 10f;
        
        public override bool Condition
        {
            get
            {
                switch (_mode)
                {
                    case Mode.Less:
                        return _targetValue > _statistic.CurrentValue;
                    case Mode.Grate:
                        return _targetValue < _statistic.CurrentValue;
                    case Mode.LessOrEqual:
                        return _targetValue >= _statistic.CurrentValue;
                    case Mode.GrateOrEqual:
                        return _targetValue <= _statistic.CurrentValue;
                    default:
                        return false;
                }
            }
        }
    }
}