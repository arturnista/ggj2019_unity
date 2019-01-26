using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpHeight;

    private Rigidbody2D rigidbody;

    void Awake () {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update () {

    }
}