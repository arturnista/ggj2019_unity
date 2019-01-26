using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="PowerUp/Create SpringPowerUp")]
public class SpringPowerUp : PowerUp
{
    
    public int JumpIncrease;
    public float Bounciness = .5f;

    public override void Apply(GameObject gameObject) {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerMovement.JumpHeight += JumpIncrease;
        playerMovement.Bounciness = Bounciness;
    }

    public override void Remove(GameObject gameObject, Vector2 baseVelocity) {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerMovement.JumpHeight -= JumpIncrease;
        playerMovement.Bounciness = 0f;
        DropPowerUp(gameObject.transform.position, playerMovement.MoveVelocity + baseVelocity);
    }
}