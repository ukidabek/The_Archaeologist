using Logic.Statistics;
using UnityEngine;
using Weapons;

public class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] private StatisticManager _statisticManager = null;
    [SerializeField] private StatisticId _healthStatisticID = null;
    
    private RangeStatistic _rangeStatistic = null;
    
    private void Awake()
    {
        _rangeStatistic = _statisticManager.GetStatistic<RangeStatistic>(new[] {_healthStatisticID});
    }

    public void DealDamage(IDamage damage)
    {
        _rangeStatistic.CurrentValue -= damage.Amount;
    }
}
