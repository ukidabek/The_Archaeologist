using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Weapons
{
    [Serializable] public class OnHitCallback : UnityEvent<float, GameObject> { }

    public class HitInvoker : MonoBehaviour
    {
        [SerializeField] private  float _damage = 10;
        public float Damage { get => _damage; set => _damage = value; }

        [Space]
        public OnHitCallback OnHit = new OnHitCallback();

        private void OnTriggerEnter(Collider other)
        {
            IDamageable hit = other.gameObject.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.DealDamage(_damage);
                OnHit.Invoke(_damage, other.gameObject);
            }
        }
    }
}