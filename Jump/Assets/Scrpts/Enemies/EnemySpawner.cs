using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies lists")]
    [SerializeField] private List<GameObject> EasyEnemies;
    [SerializeField] private List<GameObject> MediumEnemies;
    [SerializeField] private List<GameObject> HardEnemies;
    [Header("Spawn limits")]
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
        GameObject enemy = null;

        switch (GameController.GameMode)
        {
            case GameController.HardMode.Easy:
                enemy = Instantiate(EasyEnemies[Random.Range(0, EasyEnemies.Count)]);
                break;

            case GameController.HardMode.Medium:
                enemy = Instantiate(EasyEnemies[Random.Range(0, MediumEnemies.Count)]);
                break;

            case GameController.HardMode.Hard:
                enemy = Instantiate(EasyEnemies[Random.Range(0, HardEnemies.Count)]);
                break;
        }
         
        enemy.transform.parent = this.transform;
        enemy.transform.position = new Vector3(Random.Range(LeftPoint.position.x, RightPoint.position.x), LeftPoint.position.y, 1); 
    }
}
