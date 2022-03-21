using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Weapons;

public class WeaponStatusDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _parent = null;
    [SerializeField] private WeaponEvent _weaponSwitchEvent = null;

    [SerializeField] private TMP_Text _clipCount = null;
    [SerializeField] private TMP_Text _ammunitionCount = null;

    [SerializeField] private AmmunitionStorage[] _ammunitionStorages = null;

    private IClip _currentClip = null;
    private AmmunitionStorage _currentAmmunitionStorage = null;
    private void Awake()
    {
        if(_weaponSwitchEvent == null) return;
        
        _weaponSwitchEvent.Subscribe(OnWeaponSwitchCallback);
    }

    private void OnWeaponSwitchCallback(Weapon obj)
    {
        if (obj == null)
        {
            _parent.SetActive(false);
        }
        else
        {
            var clip = obj.GetWeaponAtomicLogic<IClip>();
            if(clip == null) return;

            if (_currentClip != null) 
                _currentClip.OnCounterChange -= UpdateClipDisplay;

            _currentClip = clip;
            _currentClip.OnCounterChange += UpdateClipDisplay;
            
            if (_currentAmmunitionStorage != null)
                _currentAmmunitionStorage.OnCountChange -= UpdateStorageDisplay;
            
            _currentAmmunitionStorage = _ammunitionStorages.First(
                storage => storage.AmmunitionType == _currentClip.AmmunitionType);
            _currentAmmunitionStorage.OnCountChange += UpdateStorageDisplay;
            
            UpdateClipDisplay(_currentClip.Count);
            UpdateStorageDisplay(_currentAmmunitionStorage.Count);
            
            _parent.SetActive(true);
        }
    }

    private void UpdateStorageDisplay(int obj)
    {
        if (_currentAmmunitionStorage.Infinite)
            _ammunitionCount.text = "infinite";
        else
            _ammunitionCount.text = $"{obj}";

    }

    private void UpdateClipDisplay(int obj) => _clipCount.text = $"{obj}";
}
