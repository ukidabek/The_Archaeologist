using Logic.States;
using UnityEngine;
using UnityEngine.AI;
using Weapons;

public class AttackAIStateLogic : StateLogic, IOnUpdateLogic
{
    [SerializeField] private Transform _transform = null;
    [SerializeField] private TargetDetectAIStateLogic _targetDetectAIStateLogic = null;
    [SerializeField] private WeaponManager _weaponManager = null;
    [SerializeField] private NavMeshAgent _navMeshAgent = null;

    private Transform _targetTransform = null;
    
    public override void Activate()
    {
        _navMeshAgent.isStopped = true;
        _targetTransform = _targetDetectAIStateLogic.Targets[0].transform;
    }

    public void OnUpdate(float deltaTime)
    {
        _transform.LookAt(_targetTransform);
        _weaponManager.UseWeapon();
    }
}
