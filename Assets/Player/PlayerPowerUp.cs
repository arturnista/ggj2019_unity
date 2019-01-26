using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{

    [SerializeField]
    private PlayerInputSchema inputSchema;

    private PowerUp currentPowerUp;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(inputSchema.Pickup)) {
            if(!currentPowerUp) PickUp();
            else Drop();
        }
    }

    void PickUp() 
    {
        Collider2D coll = Physics2D.OverlapBox(transform.position, new Vector2(2f, 2f), 0f, 1 << LayerMask.NameToLayer("PowerUp"));
        if(coll)
        {
            PowerUpObject pickup = coll.GetComponent<PowerUpObject>();            
            if(pickup)
            {
                currentPowerUp = pickup.GetPowerUp(this.gameObject);
            }
        }
    }

    void Drop() 
    {
        currentPowerUp.Remove(this.gameObject);
        currentPowerUp = null;
    }

}
