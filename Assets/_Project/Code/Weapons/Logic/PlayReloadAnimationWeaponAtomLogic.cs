using UnityEngine;

namespace Weapons
{
    public class PlayReloadAnimationWeaponAtomLogic : PlayAnimationWeaponAtomLogic
    {
        [SerializeField] private ClipWeaponAtomLogic _clip = null;

        public override void Perform()
        {
            if (_clip.Counter == 0)
                base.Perform();
        }
    }
}