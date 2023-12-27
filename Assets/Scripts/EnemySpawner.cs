using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }
    private Transform player;
    public float spawnDistance;
    public float marginDistance;
    public float spawnAmount;
    public float spawnRate;
    public float curSpawnRate;
    public List<Enemy> enemies = new List<Enemy>();
    private void Awake()
    {
        Instance = this;
    }
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => GameManager.Instance.prepared);
        player = GameManager.Instance.player.transform;
        StartCoroutine(monsterSpawnCoroutine());
        //StartCoroutine(EliteSpawnCoroutine());
    }
    private void Update()
    {
        if (spawnRate >= 0.5)
        {
            spawnRate -= Time.deltaTime / 120;
        }
            spawnAmount = 2 + 6 * Clock.Instance.minutes + 6 * Clock.Instance.seconds / 60;
    }

    private IEnumerator monsterSpawnCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                if (enemies.Count >= 30)
                {
                    break;
                }
                Vector2 randomUnitVector = Random.insideUnitCircle.normalized;
                Vector2 randomPos = (Vector2)player.position + randomUnitVector * Random.Range(marginDistance, spawnDistance);
                int randomIndex = Random.Range(0, Data.Instance.enemyPrefabs.Length);
                GameObject enemyPrefab = Data.Instance.enemyPrefabs[randomIndex].gameObject;
                Data.Instance.poolDictionary[PoolType.Enemy] = enemyPrefab;
                Enemy generatedEnemy = PoolManager.Instance.GenerateObject(PoolType.Enemy).GetComponent<Enemy>();
                generatedEnemy.transform.position = randomPos;
                generatedEnemy.rotation.up = -randomUnitVector;
                generatedEnemy.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private IEnumerator EliteSpawnCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Vector2 randomUnitVector = Random.insideUnitCircle;
                Vector2 randomPos = (Vector2)player.position + randomUnitVector * Random.Range(marginDistance, spawnDistance);
                int randomIndex = Random.Range(0, Data.Instance.enemyPrefabs.Length);
                GameObject enemyPrefab = Data.Instance.enemyPrefabs[randomIndex].gameObject;
                Data.Instance.poolDictionary[PoolType.Enemy] = enemyPrefab;
                Enemy generatedEnemy = PoolManager.Instance.GenerateObject(PoolType.Enemy).GetComponent<Enemy>();
                generatedEnemy.transform.position = randomPos;
                generatedEnemy.rotation.up = -randomUnitVector;
                generatedEnemy.maxHP *= 2;
                generatedEnemy.damage *= 2;
                generatedEnemy.transform.localScale *= 1.5f;
                generatedEnemy.gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(60f);
        }
    }
}
