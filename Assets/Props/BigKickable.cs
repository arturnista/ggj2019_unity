using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigKickable : Kickable
{

    public override void Kick(Vector2 force)
    {
        Collider2D[] colls = Physics2D.OverlapBoxAll(transform.position + Vector3.up, new Vector2(7f, 4f), 0f, 1 << LayerMask.NameToLayer("Props"));
        foreach(Collider2D coll in colls) {
            if(coll.gameObject == this.gameObject) continue;

            Rigidbody2D rigid = coll.GetComponent<Rigidbody2D>();
            if(rigid) rigid.velocity = -force;
        }
        
    }
    
}
