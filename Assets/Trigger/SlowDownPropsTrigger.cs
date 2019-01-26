using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownPropsTrigger : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D rigid = collider.GetComponent<Rigidbody2D>();
        rigid.velocity = rigid.velocity * 0.4f;
    }
}
