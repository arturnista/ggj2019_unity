using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{

    private PowerUp currentPowerUp;

    private SpriteRenderer powerUpSpriteRenderer;

    void Awake()
    {
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
                currentPowerUp = pickup.GetPowerUp(this.gameObject);
                powerUpSpriteRenderer.gameObject.SetActive(true);
                powerUpSpriteRenderer.sprite = currentPowerUp.Sprite;
            }
        }
    }

    void Drop() 
    {
        powerUpSpriteRenderer.gameObject.SetActive(false);
        currentPowerUp.Remove(this.gameObject);
        currentPowerUp = null;
    }

}
