using System;
using UnityEngine;

namespace Weapons
{
    public class ClipWeaponAtomLogic : WeaponAtomLogicBase, IWeaponConstraint, IWeaponBehaviour, IClip
    {
        [SerializeField] private int _count = 30;
        public int Count => _count;

        [SerializeField] private int _counter = 0;
        public int Counter => _counter;

        public event Action OnClipEmpty;

        private void Awake()
        {
            Reload();
        }

        public void Perform()
        {
            
            if(_counter-- == 0)
                OnClipEmpty?.Invoke();
        }

        public void Reload() => _counter = _count;

        public bool Validate() => _counter > 0;
    }
}