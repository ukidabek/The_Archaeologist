using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class MuzzleFlashWeaponAtomLogic : WeaponAtomLogicBase, IWeaponBehaviour
    {
        [SerializeField] private Light _light = null;

        private readonly WaitForSeconds _waitForSeconds = new WaitForSeconds(.1f);
        
        private void Awake()
        {
            _light.enabled = false;
        }

        private IEnumerator X()
        {
            _light.enabled = true;
            yield return _waitForSeconds;
            _light.enabled = false;
        }
        
        public void Perform() => StartCoroutine(X());
    }
}