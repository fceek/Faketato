using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private float _speed;
    private float _damage;

    private bool _working = false;

    public void Launch(Transform target, float speed, float damage)
    {
        _target = target;
        _speed = speed;
        _damage = damage;

        _working = true;
    }
    
    void Update()
    {
        if (!_working) return;

        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 position = transform.position;
        Vector3 direction = (_target.position - position).normalized;

        transform.position = position + direction * (_speed * Time.deltaTime);
    }

    public float GetDamage()
    {
        return _damage;
    }
}
