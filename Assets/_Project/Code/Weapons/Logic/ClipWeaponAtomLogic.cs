using System;
using Logic.ObjectMap;
using UnityEngine;
using Utilities.General;

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

        [SerializeField] private Key _userAnimatorKey = null;
        [SerializeField] private AnimatorParameterDefinition _userAnimatorParameter = null;

        [SerializeField] private Animator _userAnimator = null;

        public override void SetUser(GameObject _user)
        {
            var dictionary = _user.GetComponent<ObjectDictionary>();
            _userAnimator = dictionary.TryGetValue<Animator>(_userAnimatorKey);
        }

        public void Perform()
        {
             _counter--;
             OnCounterChange?.Invoke(_counter);
        }

        public void Reload(int amount = -1)
        {
            _counter = amount < 0 ? _count : amount;
            _userAnimatorParameter.SetTrigger(_userAnimator);
            OnCounterChange?.Invoke(_counter);
        }

        public bool Validate() => _counter > 0;
    }
}