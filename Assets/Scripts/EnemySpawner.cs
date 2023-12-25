using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Transform player;
    public float spawnDistance;
    public float marginDistance;
    public float spawnRate;

    private void Start()
    {
        player = GameManager.Instance.player.transform;
        StartCoroutine(monsterSpawnCoroutine());
    }

    private IEnumerator monsterSpawnCoroutine()
    {
        while (true)
        {
            Vector2 randomUnitVector = Random.insideUnitCircle;
            Vector2 randomPos = (Vector2)player.position + randomUnitVector * Random.Range(marginDistance, spawnDistance);
            int randomIndex = Random.Range(0, Data.Instance.enemyPrefabs.Length);
            GameObject enemyPrefab = Data.Instance.enemyPrefabs[randomIndex].gameObject;
            Data.Instance.poolDictionary[PoolType.Enemy] = enemyPrefab;
            Enemy generatedEnemy = PoolManager.Instance.GenerateObject(PoolType.Enemy).GetComponent<Enemy>();
            generatedEnemy.transform.position = randomPos;
            generatedEnemy.rotation.up = -randomUnitVector;
            generatedEnemy.gameObject.SetActive(true);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
