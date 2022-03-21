using Logic.ObjectMap;
using UnityEngine;

namespace Weapons
{
    public abstract class RangeAttackWeaponAtomLogic : WeaponAtomLogicBase
    {
        [SerializeField] private Key _originKey = null;
        [SerializeField] protected Transform _origin = null;

        public override void SetUser(GameObject _user)
        {
           var dictionary = _user.GetComponent<ObjectDictionary>();
           if (dictionary == null) return;

           _origin = dictionary.TryGetValue<Transform>(_originKey);
        }
    }
}