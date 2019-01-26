using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

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

    private float bounciness;
    public float Bounciness {
        get {
            return bounciness;
        }
        set {
            bounciness = value;
        }
    }

    private Vector2 desirableVelocity;
    private Vector2 moveVelocity;
    public Vector2 MoveVelocity {
        get { return moveVelocity; }
    }

    private float gravity;
    private float horizontalSpeed;
    public float HorizontalSpeed {
        get { return horizontalSpeed; }
        set { horizontalSpeed = value; }
    }

    private float lookingDirection;
    public float LookingDirection {
        get { return lookingDirection; }
    }

    private bool isGrounded;
    private const float extendedGroundedTime = .2f;
    private float currentExtendedGroundedTime;

    private Rigidbody2D rigidbody;
    private PlayerPowerUp playerPowerUp;

    void Awake () {
        rigidbody = GetComponent<Rigidbody2D> ();
        playerPowerUp = GetComponent<PlayerPowerUp>();
        gravity = -Physics2D.gravity.y;
    }

    void Update () {
        if(Mathf.Abs(moveVelocity.x) > 1f) lookingDirection = Mathf.Sign(moveVelocity.x);

        currentExtendedGroundedTime -= Time.deltaTime;

        desirableVelocity.x = horizontalSpeed * moveSpeed;

        moveVelocity.x = Mathf.MoveTowards (moveVelocity.x, desirableVelocity.x, acceleration * Time.deltaTime);

        bool lastGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle (groundCheck.position, .25f, 1 << LayerMask.NameToLayer ("Ground")) != null;

        if(lastGrounded != isGrounded) {
            
            if(isGrounded)
            {
                if(bounciness <= 0f)
                {
                    moveVelocity.y = 0f;
                }
                else
                {
                    moveVelocity.y *= -bounciness;
                    if(moveVelocity.y <= 1f) moveVelocity.y = 0f;
                }
            }
            else
            {

                currentExtendedGroundedTime = extendedGroundedTime;

            }
        }
    }

    public void Jump()
    {

        if(playerPowerUp.CurrentPowerUp is BootPowerUp) {
            Kick();
        }
        else if(isGrounded || currentExtendedGroundedTime > 0)
        {
            currentExtendedGroundedTime = 0;
            moveVelocity.y = Mathf.Sqrt (jumpHeight * gravity * 2f);
        }

    }

    void Kick()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position + (LookingDirection * Vector3.right * 2f), Vector2.one, 0f, 1 << LayerMask.NameToLayer("Kickable"));
        if(collider)
        {
            Kickable kickable = collider.GetComponent<Kickable>();
            if(kickable)
            {
                CameraShaker.Instance.ShakeOnce(3f, 5f, .1f, .2f);
                kickable.Kick(LookingDirection * Vector2.right * 20f);
            }
        }
    }

    void FixedUpdate ()
    {
        rigidbody.velocity = moveVelocity;
        if (!isGrounded)
        {
            moveVelocity.y -= gravity * Time.fixedDeltaTime;
        }
    }
}