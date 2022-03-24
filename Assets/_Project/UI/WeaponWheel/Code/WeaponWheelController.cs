using System;
using UnityEngine;
using UnityEngine.EventSystems;
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

        [SerializeField] private int _weaponIndex = 0;
        protected override void Awake()
        {
            base.Awake();
            foreach (var weaponWheelSegment in _buttons)
            {
                weaponWheelSegment.OnPointerEnterCallback.AddListener(i =>
                {
                    _weaponIndex = i;
                });        
            }
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
            //
            // var ed = new PointerEventData(EventSystem.current)
            // {
            //     pointerEnter = _buttons[1].gameObject
            // };
            //
            // foreach (var weaponWheelSegment in _buttons)
            // {
            //     weaponWheelSegment.OnPointerEnter(ed);
            // }
            //
        }
    }
}
