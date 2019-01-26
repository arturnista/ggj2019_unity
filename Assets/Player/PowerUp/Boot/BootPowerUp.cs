using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName="PowerUp/Create BootPowerUp")]
public class BootPowerUp : PowerUp
{
    
    public override void Apply(GameObject gameObject) {
        
    }

    public override void Remove(GameObject gameObject) {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        DropPowerUp(gameObject.transform.position, playerMovement.MoveVelocity);
    }
}