using System;
using Logic.Items;
using TMPro;
using UnityEngine;
using Weapons;

public class WeaponDisplay : MonoBehaviour
{
   [SerializeField] private TMP_Text _weaponName = null;

   [SerializeField] private WeaponSlot _weaponSlot = null;
   
   public void Initialize(WeaponSlot weaponSlot)
   {
      _weaponSlot = weaponSlot;
      _weaponSlot.OnWeaponEquipped.AddListener(OnWeaponEquipped);
      OnWeaponEquipped();
   }

   private void OnWeaponEquipped()
   {
      if (_weaponSlot.Full == false)
      {
         _weaponName.text = "Empty";
         return;
      }

      var itemData = _weaponSlot.StoredWeapon.GetComponent<ItemData>();

      _weaponName.text = itemData != null ? itemData.DisplayName : _weaponSlot.StoredWeapon.name;
   }

   private void OnDisable()
   {
      if(_weaponSlot == null) return;
      _weaponSlot.OnWeaponEquipped.RemoveListener(OnWeaponEquipped);
   }
}
