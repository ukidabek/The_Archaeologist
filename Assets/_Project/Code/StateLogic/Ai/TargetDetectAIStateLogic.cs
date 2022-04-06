using System;
using System.Collections.Generic;
using Logic.States;
using System.Collections.ObjectModel;
using UnityEngine;

public class TargetDetectAIStateLogic : StateLogic, IOnUpdateLogic
{
    [SerializeField] private float _detectionRadius = 10f;
    [SerializeField] private List<AiTarget> _targets = new List<AiTarget>(10);
    public ReadOnlyCollection<AiTarget> Targets = null;
    
    private readonly Collider[] _colliders = new Collider[10];

    private void Awake()
    {
        Targets = new ReadOnlyCollection<AiTarget>(_targets);
    }

    public void OnUpdate(float deltaTime)
    {
        var position = transform.position;
        var targetCount = Physics.OverlapSphereNonAlloc(position, _detectionRadius, _colliders);
        
        if (targetCount == 0) return;
        
        _targets.Clear();
        for (int i = 0; i < targetCount; i++)
        {
            var target  = _colliders[i].GetComponent<AiTarget>();
            if(target == null) continue;
            _targets.Add(target);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
