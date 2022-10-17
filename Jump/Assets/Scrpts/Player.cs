using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{  
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maximumJumpHeight;
    [SerializeField] private int startJumpsCount;
    [SerializeField] private int currentJumpsCount = 0;
    private Rigidbody2D rigidbody;
    private float yForce = 0;
    private float startJumpPositionY = 0;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        currentJumpsCount = startJumpsCount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentJumpsCount > 0)
        {
            currentJumpsCount--;
            yForce = jumpForce;
        }

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 moveDirection = new Vector2(x, yForce);
        transform.Translate(moveDirection);

        if ()
    }

    internal void RefreshJumpsCount()
    {
        currentJumpsCount = startJumpsCount;
    }
}
