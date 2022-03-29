using UnityEngine;
using Utilities.General;

namespace Code.StateLogic
{
    public class InventoryStateLogic : Logic.States.StateLogic
    {
        [SerializeField] private InventoryModel _inventoryModel = null;
        private readonly CursorStateHandler _cursorStateHandler = new CursorStateHandler();

        public override void Activate()
        {
            _cursorStateHandler.Set(CursorLockMode.None, true);
            _inventoryModel.ShowUI(true);
        }

        public override void Deactivate()
        {
            _cursorStateHandler.Restore();
            _inventoryModel.ShowUI(false);

        }
    }
}