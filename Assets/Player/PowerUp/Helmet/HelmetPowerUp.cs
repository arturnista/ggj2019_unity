using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Create HelmetPowerUp")]
public class HelmetPowerUp : PowerUp
{
    public int life;

    // Start is called before the first frame update
    public override void Apply(GameObject gameObject)
    {
        Lifes = life;   
    }

    public override void Remove(GameObject gameObject)
    {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        DropPowerUp(gameObject.transform.position, playerMovement.MoveVelocity);
    }
}
