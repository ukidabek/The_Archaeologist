using UnityEngine;

namespace Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private float _distance = 10f;

        [SerializeField] private Damage _damage;
        
        private Vector3 _startPosition = Vector3.zero;
        
        
        private void OnEnable()
        {
            _startPosition = transform.position;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = transform.forward * _speed;
        }

        private void Update()
        {
            var distance = Vector3.Distance(_startPosition, transform.position);
            if (distance >= _distance) 
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.gameObject.GetComponent<IDamageable>();
            damageable?.DealDamage(_damage);
            Destroy(gameObject);
        }
    }
}