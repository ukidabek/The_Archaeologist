using Logic.ObjectMap;
using UnityEngine;

namespace Weapons
{
    public class OverrideAnimationController : WeaponAtomLogicBase
    {
        [SerializeField] private Key _animatorKey = null;
        [SerializeField] private AnimatorOverrideController _overrideAnimationController = null;
        
        public override void SetUser(GameObject _user)
        {
            var objectDictionary = _user.GetComponent<ObjectDictionary>();
            if(objectDictionary == null) return;

            var animator = objectDictionary.TryGetValue<Animator>(_animatorKey);
            if(animator == null) return;

            animator.runtimeAnimatorController = _overrideAnimationController;
        }
    }
}