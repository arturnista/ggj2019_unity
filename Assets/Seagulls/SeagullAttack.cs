using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullAttack : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 5f;
    
    private PlayerMovement playerMovement;
    private Vector3 targetPosition;
    private Quaternion desirableRotation;
    private bool isAttacking;

    private float rotationSpeed;

    private Rigidbody2D rigidbody;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        targetPosition = playerMovement.transform.position;
        transform.rotation = ComputeRotation();

        rotationSpeed = 10f;

        isAttacking = true;
    }
    
    void Update()
    {
        if(isAttacking)
        {

            targetPosition = playerMovement.transform.position;
            desirableRotation = ComputeRotation(); 

            if(transform.position.y <= playerMovement.transform.position.y) {
                rotationSpeed = 50f;
                targetPosition = new Vector3(transform.position.x + (Mathf.Sign(rigidbody.velocity.x) * 30f), 50f);
                desirableRotation = ComputeRotation(); 
                isAttacking = false;
            }
            
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desirableRotation, rotationSpeed * Time.deltaTime);
        rigidbody.velocity = transform.up * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
        if(playerHealth)
        {
            playerHealth.DealDamage();
        }
    }

    Quaternion ComputeRotation()
    {

        Vector3 attackDirection = Vector3.Normalize(transform.position - targetPosition);
        float angle = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, angle + 90f); 

    }

}
