using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class CoinBonus : MonoBehaviour, IBonus
{
    [SerializeField] private int mininumScoreBonus;
    [SerializeField] private int maximumScoreBonus;
    [SerializeField] private float destroyPause;
    [SerializeField] private ParticleSystem effect;
    public event EventHandler destroyMyself;

    private int coinsCount;

    private void Start()
    {
        coinsCount = Random.Range(mininumScoreBonus, maximumScoreBonus);
    }

    event EventHandler IBonus.destroyMyself
    {
        add
        {
            destroyMyself += value;
        }

        remove
        {
            destroyMyself -= value;
        }
    }

    internal void DeleteMyself()
    {
        destroyMyself.Invoke(this, null);
        effect.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(this.gameObject, destroyPause);
    }

    internal int GetCoinsCount
    {
        get
        {
            return coinsCount;
        }
    }
}
