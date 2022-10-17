using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBonus : MonoBehaviour
{
    [SerializeField] private int jumpsCount;
    internal delegate void DestroyMyselfHandler();
    internal event DestroyMyselfHandler destroyMyself;

    internal void DeleteMyself()
    {
        destroyMyself.Invoke();
        Destroy(this.gameObject);
    }

    internal int GetJumpsCount
    {
        get
        {
            return jumpsCount;
        }
    }
}
