using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JumpBonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jumpBonus;
    [SerializeField] private float spawnPause;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnPause);
            float x = GameController.GetPlayerPosition.x + Random.Range(-1, 1);
            float y = GameController.GetPlayerPosition.y + Random.Range(-1, 1);
            Vector2 spawnPosition = new Vector2(x, y);
            GameObject bonus = Instantiate(jumpBonus);
            bonus.transform.position = spawnPosition;
        }  
    }
}
