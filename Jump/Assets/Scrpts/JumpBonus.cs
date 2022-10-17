using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBonus : MonoBehaviour
{
    [SerializeField] private int jumpsCount;

    internal void DeleteMyself()
    {
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
