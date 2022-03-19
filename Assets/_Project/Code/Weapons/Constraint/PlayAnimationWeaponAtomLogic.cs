using Logic.ObjectMap;
using UnityEngine;
using Utilities.General;

namespace Weapons
{
    public class PlayAnimationWeaponAtomLogic : WeaponAtomLogicBase, IWeaponBehaviour
    {
        [SerializeField] private Key _userAnimatorKey = null;
        [SerializeField] private AnimatorParameterDefinition _userAnimatorParameter = null;

        private Animator _userAnimator = null;
        
        public override void SetUser(GameObject _user)
        {
            var dictionary = _user.GetComponent<ObjectDictionary>();
            _userAnimator = dictionary.TryGetValue<Animator>(_userAnimatorKey);
        }

        public virtual void Perform()
        {
            _userAnimatorParameter.SetTrigger(_userAnimator);
        }
    }
}