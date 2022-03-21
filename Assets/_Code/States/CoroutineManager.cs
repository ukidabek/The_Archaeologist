using System.Collections;
using UnityEngine;

namespace Logic.States
{
    public class CoroutineManager
    {
        private readonly MonoBehaviour _coroutineRunnerMonoBehaviour;
        private IEnumerator _coroutine;

        public CoroutineManager(MonoBehaviour coroutineRunnerMonoBehaviour)
        {
            _coroutineRunnerMonoBehaviour = coroutineRunnerMonoBehaviour;
        }

        private void ManageCoroutine(IEnumerator enumerator)
        {
            Stop();
            _coroutine = enumerator;
            _coroutineRunnerMonoBehaviour.StartCoroutine(_coroutine);
        }

        public void Stop()
        {
            if (_coroutine != null)
                _coroutineRunnerMonoBehaviour.StopCoroutine(_coroutine);
        }

        public void Run(IEnumerator enumerator)
        {
            ManageCoroutine(enumerator);
        }
        
        public void ReRun()
        {
            if (_coroutine != null)
                ManageCoroutine(_coroutine);
        }
    }
}