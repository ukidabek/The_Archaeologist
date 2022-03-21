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

        [SerializeField] private WeaponDescriptor _ammunitionType = null;
        public WeaponDescriptor AmmunitionType => _ammunitionType;
        public event Action<int> OnCounterChange;

        private void Awake()
        {
            Reload();
        }

        public void Perform()
        {
             _counter--;
             OnCounterChange?.Invoke(_counter);
        }

        public void Reload(int amount = -1)
        {
            _counter = amount < 0 ? _count : amount;
            OnCounterChange?.Invoke(_counter);
        }

        public bool Validate() => _counter > 0;
    }
}