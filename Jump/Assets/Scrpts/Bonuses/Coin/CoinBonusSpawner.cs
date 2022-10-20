using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBonusSpawner : IBonusSpawner
{
    private void Start()
    {
        StartCoroutine(SpawnBonus<CoinBonus>());
    }
}
