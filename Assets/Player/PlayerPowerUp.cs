using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{

    [SerializeField]
    private PowerUpHolder holder;
    public PowerUpHolder Holder {
        get { return holder; }
    }

    private SpriteRenderer powerUpSpriteRenderer;
    private PlayerSound playerSound;

    void Awake()
    {
        playerSound = GetComponent<PlayerSound>();

        powerUpSpriteRenderer = transform.Find("PowerUpSprite").GetComponent<SpriteRenderer>();
        powerUpSpriteRenderer.gameObject.SetActive(false);

        if(Holder.CurrentPowerUp)
        {
            PickUpPower(Holder.CurrentPowerUp);
            Holder.CurrentPowerUp.Apply(this.gameObject);
        }
    }

    public void PickUpAction()
    {
        if(!Holder.CurrentPowerUp) PickUp();
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
                PickUpPower(pickup.GetPowerUp(this.gameObject));
            }
        }
    }

    void PickUpPower(PowerUp power)
    {
        Holder.CurrentPowerUp = power;
        powerUpSpriteRenderer.gameObject.SetActive(true);
        powerUpSpriteRenderer.sprite = Holder.CurrentPowerUp.Sprite;
    }

    public void Drop()
    {
        Drop(Vector2.zero);    
    } 

    public void Drop(Vector2 baseVelocity) 
    {
        playerSound.PlayDropPowerUp();
        powerUpSpriteRenderer.gameObject.SetActive(false);
        Holder.CurrentPowerUp.Remove(this.gameObject, baseVelocity);
        Holder.CurrentPowerUp = null;
    }

}
