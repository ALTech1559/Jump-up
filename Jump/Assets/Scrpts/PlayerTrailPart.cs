using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailPart : MonoBehaviour
{
    [SerializeField] private float scaleChanging;
    [SerializeField] private float scalePause;

    private void Start()
    {
        StartCoroutine(Scale());
    }

    private IEnumerator Scale()
    {
        while (true)
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(transform.localScale.x - scaleChanging, transform.localScale.y - scaleChanging);
            }
            yield return new WaitForSeconds(scalePause);
        }
    }
}
