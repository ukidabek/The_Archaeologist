using UnityEngine;

namespace Weapons
{
    public class ProjectileSpawnWeaponAtomLogic : RangeAttackWeaponAtomLogic, IWeaponBehaviour
    {
        [SerializeField] private Projectile _projectilePrefab = null;
        
        public void Perform()
        {
            var projectileInstance = Instantiate(_projectilePrefab);
            var projectileTransform = projectileInstance.transform;

            projectileTransform.position = _origin.position;
            projectileTransform.rotation = _origin.rotation;
            
            projectileInstance.gameObject.SetActive(true);
        }
    }
}