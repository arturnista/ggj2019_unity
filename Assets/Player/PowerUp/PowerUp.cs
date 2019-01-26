using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : ScriptableObject
{

    public Sprite Sprite;
    public GameObject Prefab;

    public void DropPowerUp(Vector3 pos, Vector3 baseVelocity)
    {
        GameObject gameObject = Instantiate(Prefab, pos + Vector3.up, Quaternion.identity) as GameObject;
        PowerUpObject obj = gameObject.GetComponent<PowerUpObject>();
        obj.Construct(this);

        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(
            baseVelocity.x + ( Mathf.Sign(baseVelocity.x) * 10f ), 
            baseVelocity.y + ( Mathf.Sign(baseVelocity.y) * 5f )
        );
    }

    public abstract void Apply(GameObject effect);
    public abstract void Remove(GameObject effect);
}