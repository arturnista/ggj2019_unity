using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullAttack : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 5f;
    
    private PlayerMovement playerMovement;
    private Vector3 targetPosition;

    private Rigidbody2D rigidbody;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        targetPosition = playerMovement.transform.position;
    }
    
    void Update()
    {
        Vector3 attackDirection = Vector3.Normalize(transform.position - targetPosition);
        float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 90f); 

        rigidbody.velocity = transform.up * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
    }

}
