using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JumpBonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject jumpBonus;
    [SerializeField] private float spawnPause;
    [SerializeField] private int maximumBonusesCount;

    private int currentBonusesCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnPause);
            if (currentBonusesCount <= maximumBonusesCount)
            {
                float x = GameController.GetPlayerPosition.x + Random.Range(-3, 3);
                float y = GameController.GetPlayerPosition.y + Random.Range(-3, 3);
                Vector2 spawnPosition = new Vector2(x, y);
                JumpBonus bonus = Instantiate(jumpBonus).GetComponent<JumpBonus>();
                bonus.destroyMyself += () => { currentBonusesCount--; };
                bonus.transform.position = spawnPosition;
                currentBonusesCount++;
            }
        }  
    }
}
