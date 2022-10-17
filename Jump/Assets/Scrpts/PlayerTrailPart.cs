using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailPart : MonoBehaviour
{
    [SerializeField] private float scaleChanging;
    private void Update()
    {
        if (transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(transform.localScale.x - scaleChanging, transform.localScale.y - scaleChanging);
        }
      
    }
}
