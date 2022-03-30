using Logic.Items;
using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "WeaponItem", menuName = "Equipment/Items/WeaponItem")]
    public class WeaponItem : ItemWitchPrefab, IEquipment
    {
        public bool IsEquipped { get; set; }
    }
}