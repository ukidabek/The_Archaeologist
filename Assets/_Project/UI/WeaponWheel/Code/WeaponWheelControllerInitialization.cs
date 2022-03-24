using UnityEngine;

namespace UI.WeaponWheel.Code
{
    public partial class WeaponWheelController
    {
        [SerializeField] private WeaponWheelSegment _segmentButton = null;

        [ContextMenu("Initialize")]
        public void InitializeWheel()
        {
            if (Application.isPlaying == true) return;

            if (_buttons == null || _buttons.Length != _segmentsCount)
            {
                if (_buttons != null)
                {
                    var count = _buttons.Length;
                    for (int i = 0; i < count; i++)
                    {
                        if (_buttons[i] == null)
                            continue;
                        DestroyImmediate(_buttons[i]);
                    }
                }

                _buttons = new WeaponWheelSegment[_segmentsCount];
            }

            var angle = 360f / _segmentsCount;

            var startAngle = _startAngle;
            for (int i = 0; i < _segmentsCount; i++)
            {
                var radians = startAngle * Mathf.Deg2Rad;
                var x = Mathf.Sin(radians) * _radius;
                var y = Mathf.Cos(radians) * _radius;
                startAngle += angle;

                WeaponWheelSegment instance = null;
                if (_buttons[i] == null)
                {
                    instance = _buttons[i] = Instantiate(_segmentButton, this.transform, false);
                }
                else
                {
                    instance = _buttons[i];
                }

                instance.Index = i;
                var rectTransform = instance.transform as RectTransform;
                rectTransform.anchoredPosition = new Vector3(x, y, 0);
            }
        }
    }
}