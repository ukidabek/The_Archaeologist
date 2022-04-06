using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class RoamAIStateLogic : Logic.States.StateLogic
{
    [SerializeField] private NavMeshAgent _meshAgent = null;
    [SerializeField] private float _minRange = 3;
    [SerializeField] private float _maxRange = 5;
    [SerializeField] private float _interval = 100; 
    
    private WaitForSeconds _waitYield = null;
    private IEnumerator _coroutine = null;
    
    private void Awake()
    {
        _waitYield = new WaitForSeconds(_interval);
    }

    public override void Activate()
    {
        _meshAgent.isStopped = false;
        _coroutine = RoamCoroutine();
        StartCoroutine(_coroutine);
    }

    public override void Deactivate()
    {
        if(_coroutine == null) return;
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator RoamCoroutine()
    {
        while (true)
        {
            var point = Random.insideUnitCircle;
            var range = Random.Range(_minRange, _maxRange);
            point *= range;

            var newPosition = transform.position + new Vector3(point.x, 0f, point.y);

            _meshAgent.destination = newPosition;
            
            yield return _waitYield;
        }
    }
}
