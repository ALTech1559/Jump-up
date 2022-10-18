using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] private float gravityScale;
    
    private void Update()
    {
        Vector2 moveDirection = new Vector2(0, gravityScale * Time.deltaTime);
        transform.Translate(moveDirection);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DeathBlock>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
