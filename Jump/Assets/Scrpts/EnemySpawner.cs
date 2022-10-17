using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private Transform LeftPoint;
    [SerializeField] private Transform RightPoint;
    [Header("Pause in seconds")]
    [SerializeField] private float pause;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(pause);
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(Enemy);
        enemy.transform.parent = this.transform;
        enemy.transform.position = new Vector3(Random.Range(LeftPoint.position.x, RightPoint.position.x), LeftPoint.position.y, 1); 
    }
}
