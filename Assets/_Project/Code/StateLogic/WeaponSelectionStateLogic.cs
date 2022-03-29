using Logic.States;
using UnityEngine;
using Utilities.General;
using Weapons;

namespace Code.StateLogic
{
    public class WeaponSelectionStateLogic : Logic.States.StateLogic
    {
        [SerializeField] private WeaponManagerModel _weaponManagerModel = null;

        private readonly CursorStateHandler _cursorStateHandler = new CursorStateHandler();
        
        private bool _visibleStatus = false;
        private CursorLockMode _lockState = CursorLockMode.None;
        public override void Activate()
        {
            _cursorStateHandler.Set(CursorLockMode.None, true);
            _weaponManagerModel.ShowUI(true);
        }

        public override void Deactivate()
        {
            _weaponManagerModel.ShowUI(false);

            var manager = _weaponManagerModel.ManagerInstance;
            var index = _weaponManagerModel.SelectedWeaponIndex;
            manager.Equip(index);
            
            _cursorStateHandler.Restore();
        }
    }
}