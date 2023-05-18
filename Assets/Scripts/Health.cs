using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private GameObject _deathVFX;

    public void DealdDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if(!_deathVFX) { return; }

        GameObject deathVFXObject = Instantiate(_deathVFX, transform.position, transform.rotation);

        Destroy(deathVFXObject, 1f);
    }
}
