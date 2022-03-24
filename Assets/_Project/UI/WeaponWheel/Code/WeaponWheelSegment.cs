using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.WeaponWheel.Code
{
    public class WeaponWheelSegment : Selectable
    {
        [SerializeField] private TMP_Text _text = null;
        public String Text
        {
            get => _text.text;
            set => _text.text = value;
        }

        [SerializeField] private int _index = 0;
        public int Index
        {
            get => _index;
            set => _index = value;
        }

        public UnityEvent<int> OnPointerEnterCallback = new UnityEvent<int>();

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            OnPointerEnterCallback.Invoke(Index);
        }
    }
}