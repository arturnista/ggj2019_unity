using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{

    private PowerUp currentPowerUp;
    public PowerUp CurrentPowerUp {
        get { return currentPowerUp; }
    }

    private SpriteRenderer powerUpSpriteRenderer;
    private PlayerSound playerSound;

    void Awake()
    {
        playerSound = GetComponent<PlayerSound>();

        powerUpSpriteRenderer = transform.Find("PowerUpSprite").GetComponent<SpriteRenderer>();
        powerUpSpriteRenderer.gameObject.SetActive(false);
    }

    public void PickUpAction()
    {
        if(!currentPowerUp) PickUp();
        else Drop();
    }

    void PickUp() 
    {
        Collider2D coll = Physics2D.OverlapBox(transform.position, new Vector2(2f, 2f), 0f, 1 << LayerMask.NameToLayer("PowerUp"));
        if(coll)
        {
            PowerUpObject pickup = coll.GetComponent<PowerUpObject>();            
            if(pickup)
            {
                playerSound.PlayPickupPowerUp();
                currentPowerUp = pickup.GetPowerUp(this.gameObject);
                powerUpSpriteRenderer.gameObject.SetActive(true);
                powerUpSpriteRenderer.sprite = currentPowerUp.Sprite;
            }
        }
    }

    public void Drop()
    {
        Drop(Vector2.zero);    
    } 

    public void Drop(Vector2 baseVelocity) 
    {
        playerSound.PlayDropPowerUp();
        powerUpSpriteRenderer.gameObject.SetActive(false);
        currentPowerUp.Remove(this.gameObject, baseVelocity);
        currentPowerUp = null;
    }

}
