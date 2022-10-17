using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravityScale;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maximumJumpHeight;
    [SerializeField] private int startJumpsCount;

    [SerializeField] private int currentJumpsCount = 0;
    private float yForce = 0;
    private float startJumpPositionY = 0;
    private float lastClickTime = 0;

    private void Start()
    {
        currentJumpsCount = startJumpsCount;
        yForce = gravityScale;
    }

    private void Update()
    {
        float x = speed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (Math.Abs(Time.time - lastClickTime) <= 0.5f)
            {
                Jump();
            }

            lastClickTime = Time.time;
        }

        if (Input.GetMouseButton(0))
        {

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition);
            if (mousePosition.x < 0)
            {
                x *= -1;
            }

        }
        else
        {
            x = 0;
        }

        if(transform.position.y - startJumpPositionY >= maximumJumpHeight)
        {
            yForce = gravityScale;
        }

        Vector2 moveDirection = new Vector2(x, yForce * Time.deltaTime);
        transform.Translate(moveDirection);
    }

    private void Jump()
    {
        if (currentJumpsCount > 0)
        {
            currentJumpsCount--;
            yForce = jumpForce;
            startJumpPositionY = transform.position.y;
        }
    }

    internal int CurrentJumpsCount
    {
        get
        {
            return currentJumpsCount;
        }

        set
        {
            currentJumpsCount = value;
        }
    }
}
