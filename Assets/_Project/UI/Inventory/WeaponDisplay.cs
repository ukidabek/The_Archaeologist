using TMPro;
using UnityEngine;
using Weapons;

public class WeaponDisplay : MonoBehaviour
{
   [SerializeField] private TMP_Text _weaponName = null;

   public void Initialize(Weapon weapon)
   {
      _weaponName.text = weapon == null ? "Empty" : weapon.name;
   }
}
