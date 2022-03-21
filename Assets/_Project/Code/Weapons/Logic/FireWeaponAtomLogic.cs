using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class FireWeaponAtomLogic : WeaponAtomLogicBase, IWeaponConstraint, IWeaponBehaviour
    {
        [SerializeField] private int _numberOfShots = 30;
        [SerializeField] private float _timeInterval = 60f;
        
        private WaitForSeconds _waitForSeconds = null;
        private WaitUntil _waitUntil = null;
        private bool _wait = false;

        private IEnumerator _coroutine = null;
        
        private void Awake()
        {
            _waitUntil = new WaitUntil(() => _wait);
            InitializeWait();

            _coroutine = BlockFiore_CO();
            StartCoroutine(_coroutine);
        }

        private void InitializeWait()
        {
            _waitForSeconds = new WaitForSeconds(_timeInterval / _numberOfShots);
        }

        public bool Validate() => !_wait;

        public void Perform()
        {
            _wait = true;
        }

        private IEnumerator BlockFiore_CO()
        {
            while (true)
            {
                yield return _waitUntil;
                yield return _waitForSeconds;
                _wait = false;
            }
        }

        private void OnValidate() => InitializeWait();
    }
}