using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUp/Create HelmetPowerUp")]
public class HelmetPowerUp : PowerUp
{
    public int MaxLife = 3;
    private int life;

    void OnEnable()
    {
        ResetLife();
    }

    // Start is called before the first frame update
    public override void Apply(GameObject gameObject)
    {
        
    }

    public override void Remove(GameObject gameObject, Vector2 baseVelocity)
    {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();
        DropPowerUp(gameObject.transform.position, baseVelocity + playerMovement.MoveVelocity);
    }

    void ResetLife()
    {
        life = MaxLife;
    }

    public bool DealDamage()
    {
        life--;
        //acionar particula pra mostrar q bateu e fazer som quando a gente for botar som
        if(life <= 0)
        {
            ResetLife();
            return true;
        }

        return false;
    }
}
