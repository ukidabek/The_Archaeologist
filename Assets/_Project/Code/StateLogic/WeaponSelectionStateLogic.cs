using Logic.States;
using UnityEngine;
using Weapons;

namespace Code.StateLogic
{
    public class WeaponSelectionStateLogic : Logic.States.StateLogic, IOnUpdateLogic
    {
        [SerializeField] private WeaponManagerModel _weaponManagerModel = null;

        private bool _visibleStatus = false;
        private CursorLockMode _lockState = CursorLockMode.None;
        public override void Activate()
        {
            _visibleStatus = Cursor.visible;
            _lockState = Cursor.lockState;
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            _weaponManagerModel.ShowUI(true);
        }

        public override void Deactivate()
        {
            _weaponManagerModel.ShowUI(false);

            var manager = _weaponManagerModel.ManagerInstance;
            var index = _weaponManagerModel.SelectedWeaponIndex;
            manager.Equip(index);
            
            Cursor.visible = _visibleStatus;
            Cursor.lockState = _lockState;
        }

        public void OnUpdate(float deltaTime)
        {
            
        }
    }
}