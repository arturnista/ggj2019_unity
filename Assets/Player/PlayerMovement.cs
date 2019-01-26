﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private PlayerInputSchema inputSchema;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpHeight;
    public float JumpHeight {
        get {
            return jumpHeight;
        }
        set {
            jumpHeight = value;
        }
    }
    [SerializeField]
    private Transform groundCheck;

    private Vector2 desirableVelocity;
    private Vector2 moveVelocity;
    private Vector2 velocity;

    private float gravity;

    private bool isGrounded;

    private Rigidbody2D rigidbody;

    void Awake () {
        rigidbody = GetComponent<Rigidbody2D> ();
        gravity = -Physics2D.gravity.y;
    }

    void Update () {

        float horizontal = Input.GetAxisRaw(inputSchema.Axis);

        desirableVelocity.x = horizontal * moveSpeed;

        moveVelocity.x = Mathf.MoveTowards (velocity.x, desirableVelocity.x, acceleration);

        isGrounded = Physics2D.OverlapCircle (groundCheck.position, .25f, 1 << LayerMask.NameToLayer ("Ground")) != null;
        if (isGrounded) {
            moveVelocity.y = 0f;
            if (Input.GetKeyDown (inputSchema.Jump)) moveVelocity.y = Mathf.Sqrt (jumpHeight * gravity * 2f);
        } else {
            moveVelocity.y -= gravity * Time.deltaTime;
        }

        if (Input.GetKeyDown(inputSchema.Pickup)) Debug.Log("pickup");

    }

    void LateUpdate () {
        rigidbody.velocity = moveVelocity;
    }
}