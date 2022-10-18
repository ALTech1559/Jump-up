using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBonus : MonoBehaviour
{
    [SerializeField] private float destroyPause;
    [SerializeField] private int jumpsCount;
    [SerializeField] private ParticleSystem effect;
    internal delegate void DestroyMyselfHandler();
    internal event DestroyMyselfHandler destroyMyself;

    internal void DeleteMyself()
    {
        destroyMyself.Invoke();
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
