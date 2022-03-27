using UnityEngine;
using Utilities.UI;
using Weapons;

namespace UI.WeaponWheel.Code
{
    public partial class WeaponWheelController : ManagerModelViewBase<WeaponManager, WeaponManagerModel>
    {
        [Space]
        [SerializeField] private int _segmentsCount = 5;
        [SerializeField] private float _startAngle = 0f;
        [SerializeField] private float _radius = 1f;

        [SerializeField] private WeaponWheelSegment[] _buttons = null;
        
        protected override void Awake()
        {
            base.Awake();
            foreach (var weaponWheelSegment in _buttons)
                weaponWheelSegment.OnPointerEnterCallback.AddListener(i => _managerModel.SelectedWeaponIndex = i);
        }

        private void OnEnable()
        {
            var slots = Manager.Slots;
            var segmentsEnumerator = _buttons.GetEnumerator();
            
            foreach (var weaponSlot in slots)
            {
                if (segmentsEnumerator.MoveNext() == false)
                    break;

                var currentSegment = segmentsEnumerator.Current as WeaponWheelSegment;
                if(currentSegment == null)
                    break;

                currentSegment.Text = weaponSlot.StoredWeapon == null ? "Empty" : weaponSlot.StoredWeapon.name;
            }
        }
    }
}
