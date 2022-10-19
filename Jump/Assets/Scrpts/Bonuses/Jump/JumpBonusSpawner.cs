using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JumpBonusSpawner : IBonusSpawner
{
    private void Start()
    {
        StartCoroutine(SpawnBonus<JumpBonus>());
    }
}
