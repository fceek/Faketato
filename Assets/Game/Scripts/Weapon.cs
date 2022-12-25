using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float damage;

    [SerializeField] private float attackInterval;
    [SerializeField] private Projectile projectile;

    private Coroutine _attackCoroutine;
    private WaitForSeconds _interval;

    private Character _player;

    private void Start()
    {
        _player = FindObjectOfType<Character>();
        _interval = new WaitForSeconds(attackInterval);
        _attackCoroutine = StartCoroutine(SpawnProjectile());
    }

    private IEnumerator SpawnProjectile()
    {
        while (true)
        {
            yield return _interval;
            Transform nearest = _player.GetNearestEnemy();
            if (nearest == null) continue;
            var newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            newProjectile.Launch(nearest, projectileSpeed, damage);
        }
    }
}
