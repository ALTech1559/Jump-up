using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    [SerializeField] private GameObject trail;
    [SerializeField] private float destroyTime;
    [SerializeField] private float pauseTime;

    private void Start()
    {
        StartCoroutine(SpawnTrailParts());
    }

    private IEnumerator SpawnTrailParts()
    {
        while (true)
        {
            GameObject trailPart = Instantiate(trail, transform.position, Quaternion.identity);
            Destroy(trailPart, destroyTime);
            yield return new WaitForSeconds(pauseTime);   
        }
    }
}
