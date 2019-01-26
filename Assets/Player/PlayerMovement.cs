using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private float stepSize = 0.001f;
    [SerializeField]
    private LayerMask groundLayerMask;
    [SerializeField]
    private LayerMask propsLayerMask;

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
    private PlayerSound playerSound;

    private Vector3 lastPosition;
    private float amountWalked;

    void Awake () {
        playerSound = GetComponent<PlayerSound>();

        rigidbody = GetComponent<Rigidbody2D> ();
        playerPowerUp = GetComponent<PlayerPowerUp>();
        gravity = -Physics2D.gravity.y;
    }

    void Update () {

        //just a button to restart the level for easy test
        if(Input.GetKeyDown(KeyCode.R))
        {
            Scene LoadLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(LoadLevel.buildIndex);
        }

        if(Mathf.Abs(moveVelocity.x) > 1f) lookingDirection = Mathf.Sign(moveVelocity.x);

        currentExtendedGroundedTime -= Time.deltaTime;

        desirableVelocity.x = horizontalSpeed * moveSpeed;

        moveVelocity.x = Mathf.MoveTowards (moveVelocity.x, desirableVelocity.x, acceleration * Time.deltaTime);

        bool lastGrounded = isGrounded;
        isGrounded = Physics2D.OverlapBox (groundCheck.position, new Vector2(.9f, .5f), 0f, groundLayerMask) != null;
        
        if(isGrounded) Step();

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

    void Step()
    {
        amountWalked += Mathf.Abs(lastPosition.magnitude - transform.position.magnitude);
        lastPosition = transform.position;
        if(amountWalked >= stepSize) {
            amountWalked = 0f;
            playerSound.PlayWalk();
        }
    }

    public void Jump()
    {

        if(playerPowerUp.Holder.CurrentPowerUp is BootPowerUp) {
            Kick();
        }
        else if(isGrounded || currentExtendedGroundedTime > 0)
        {
            playerSound.PlayJump();
            currentExtendedGroundedTime = 0;
            moveVelocity.y = Mathf.Sqrt (jumpHeight * gravity * 2f);
        }

    }

    void Kick()
    {
        playerSound.PlayKick();

        Collider2D collider = Physics2D.OverlapBox(transform.position + (LookingDirection * Vector3.right * 2f), Vector2.one, 0f, propsLayerMask);
        if(collider)
        {
            Kickable kickable = collider.GetComponent<Kickable>();
            if(kickable)
            {
                CameraShaker.Instance.ShakeOnce(3f, 5f, .1f, .2f);
                kickable.Kick(LookingDirection * Vector2.right * 5f);
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