using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBonus : MonoBehaviour, IBonus
{
    [SerializeField] private float destroyPause;
    [SerializeField] private int jumpsCount;
    [SerializeField] private ParticleSystem effect;
    public event EventHandler destroyMyself;

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

    internal int GetJumpsCount
    {
        get
        {
            return jumpsCount;
        }
    }
}
