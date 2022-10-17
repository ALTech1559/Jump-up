using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravityScale;
    [SerializeField] private float yForceChngingTime;
    [SerializeField] private float jumpForce;
    [SerializeField] private float maximumJumpHeight;
    [SerializeField] private int startJumpsCount;

    [SerializeField] private int currentJumpsCount = 0;
    private float yForce = 0;
    private float startJumpPositionY = 0;

    internal delegate void UpdateJumpsCountHandler(int currentJumpsCount);
    internal event UpdateJumpsCountHandler updateJumpsCount;
    private PlayerTrail trail;

    private void Start()
    {
        currentJumpsCount = startJumpsCount;
        trail = GetComponent<PlayerTrail>();
        yForce = gravityScale;
        UpdateJumpsCountInvoke();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if(transform.position.y - startJumpPositionY >= maximumJumpHeight)
        {
            yForce = Mathf.Lerp(jumpForce, gravityScale, yForceChngingTime);
        }

        Vector2 moveDirection = new Vector2(x, yForce * Time.deltaTime);
        transform.Translate(moveDirection);
    }

    private void Jump()
    {
        if (currentJumpsCount > 0)
        {
            currentJumpsCount--;
            UpdateJumpsCountInvoke();
            yForce = Mathf.Lerp(gravityScale, jumpForce, yForceChngingTime);
            startJumpPositionY = transform.position.y;
        }
    }

    internal void UpdateJumpsCountInvoke()
    {
        updateJumpsCount.Invoke(currentJumpsCount);
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
