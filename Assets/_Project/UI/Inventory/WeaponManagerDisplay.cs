using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class WeaponManagerDisplay : MonoBehaviour
{
    [SerializeField] private WeaponManagerModel _weaponManagerModel = null;
    [SerializeField] private Transform _parent = null;

    [SerializeField] private List<WeaponDisplay> _weaponDisplays = new List<WeaponDisplay>();
   
    private void OnEnable()
    {
        var slots = _weaponManagerModel.ManagerInstance.Slots;

        var weponsDisplay = _weaponDisplays.GetEnumerator();
        foreach (var weaponSlot in slots)
        {
            if(weponsDisplay.MoveNext() == false) return;
            var weaponDisplay = weponsDisplay.Current;
            weaponDisplay.Initialize(weaponSlot);
        }
    }
}
