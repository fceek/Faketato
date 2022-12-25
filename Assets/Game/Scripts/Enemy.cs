using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 10.0f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float stopDistance;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
        var position = transform.position;
        Vector3 direction = _playerTransform.position - position;
        if (direction.magnitude <= stopDistance) return;
        
        direction = direction.normalized;

        transform.position = position + direction * (moveSpeed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            _playerTransform.GetComponent<Character>().TakeDamage(damage);
            return;
        }

        if (col.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(col.GetComponent<Projectile>().GetDamage());
            Destroy(col.gameObject);
        }
    }

    private void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
