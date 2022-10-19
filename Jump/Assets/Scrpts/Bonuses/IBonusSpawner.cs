using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public abstract class IBonusSpawner : MonoBehaviour
{
    [SerializeField] private int maximumSpawnRadius;
    [SerializeField] private int minimumSpawnRadius;
    [SerializeField] private GameObject bonus;
    [SerializeField] private float spawnPause;
    [SerializeField] private int maximumBonusesCount;

    [SerializeField] private int currentBonusesCount = 0;

    internal virtual IEnumerator SpawnBonus<T>() where T : IBonus
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnPause);
            if (currentBonusesCount < maximumBonusesCount)
            {
                float x = 0;
                float y = 0;

                if (GameController.GetPlayerPosition.y >= 0)
                {
                    y = GameController.GetPlayerPosition.y + Random.Range(-maximumSpawnRadius, -minimumSpawnRadius);
                }
                else
                {
                    y = GameController.GetPlayerPosition.y + Random.Range(minimumSpawnRadius, maximumSpawnRadius);
                }

                if (GameController.GetPlayerPosition.x >= 0)
                {
                    x = GameController.GetPlayerPosition.x + Random.Range(-maximumSpawnRadius, -minimumSpawnRadius);
                }
                else
                {
                    x = GameController.GetPlayerPosition.x + Random.Range(minimumSpawnRadius, maximumSpawnRadius);
                }

                Vector2 spawnPosition = new Vector2(x, y);
                GameObject newBonusObject = Instantiate(bonus);
                newBonusObject.GetComponent<T>().destroyMyself += DestroyMyself;
                newBonusObject.transform.position = spawnPosition;
                currentBonusesCount++;
            }
        }
    }

    internal virtual void DestroyMyself(object sender, EventArgs e)
    {
        currentBonusesCount--;
    }
}
