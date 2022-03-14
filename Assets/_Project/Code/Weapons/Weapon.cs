using System;
using UnityEngine;

namespace Weapons
{
    public class Weapon : MonoBehaviour
    {
        [Serializable]
        public class HandSpot
        {
            [SerializeField] private HumanBodyBones _humanBone = HumanBodyBones.LeftHand;
            public HumanBodyBones HumanBone => _humanBone;

            [SerializeField] private Transform _slotTransform = null;
            public Transform SlotTransform => _slotTransform;
        }

        [SerializeField] private HandSpot[] _handSpots = null;

        public HandSpot[] HandSpots => _handSpots;

        [SerializeField] private WeaponDescriptor[] _descriptors;
        public WeaponDescriptor[] Descriptors => _descriptors;

        public void Use()
        {

           
        }
    }
}
