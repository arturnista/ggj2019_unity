using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="Create SpringPowerUp")]
public class SpringPowerUp : PowerUp
{
    
    public int jumpIncrease;

    public override void Apply(GameObject gameObject) {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerMovement.JumpHeight += jumpIncrease;
    }

    public override void Remove(GameObject gameObject) {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        playerMovement.JumpHeight -= jumpIncrease;
        DropPowerUp(gameObject.transform.position);
    }
}