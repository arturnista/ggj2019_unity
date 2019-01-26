using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

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

    private float gravity;
    private float horizontalSpeed;
    public float HorizontalSpeed {
        get { return horizontalSpeed; }
        set { horizontalSpeed = value; }
    }

    private bool isGrounded;

    private Rigidbody2D rigidbody;

    void Awake () {
        rigidbody = GetComponent<Rigidbody2D> ();
        gravity = -Physics2D.gravity.y;
    }

    void Update () {

        desirableVelocity.x = horizontalSpeed * moveSpeed;

        moveVelocity.x = Mathf.MoveTowards (moveVelocity.x, desirableVelocity.x, acceleration * Time.deltaTime);

        bool lastGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle (groundCheck.position, .25f, 1 << LayerMask.NameToLayer ("Ground")) != null;

        if(lastGrounded != isGrounded && isGrounded) moveVelocity.y = 0f;
    }

    public void Jump() {
        if(!isGrounded) return;
        moveVelocity.y = Mathf.Sqrt (jumpHeight * gravity * 2f);
    }

    void FixedUpdate () {
        rigidbody.velocity = moveVelocity;
        if (!isGrounded) {
            moveVelocity.y -= gravity * Time.fixedDeltaTime;
        }
    }
}