using UnityEngine;
using Weapons;

public class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] private float _health = 100;

    public void DealDamage(IDamage damage)
    {
        _health -= damage.Amount;
        if (_health <= 0)
            Destroy(gameObject);
    }
}
