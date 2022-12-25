using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private Enemy enemyType;

    private Coroutine _spawnCoroutine;
    private WaitForSeconds _interval;
    private void Start()
    {
        _interval = new WaitForSeconds(spawnInterval);
        _spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return _interval;
            Vector3 position = BattleField.Instance.GetRandomPoint();
            Enemy e = Instantiate(enemyType, position, transform.rotation);
            Debug.Log($"Spawned at {position}");
        }
    }
}
