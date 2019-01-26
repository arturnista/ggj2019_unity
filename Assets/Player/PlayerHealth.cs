using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerHealth : MonoBehaviour
{
    
    private PlayerPowerUp playerPowerUp;
    
    void Awake()
    {
        playerPowerUp = GetComponent<PlayerPowerUp>();
    }

    void Update()
    {
        
    }

    public void DealDamage()
    {
        if(playerPowerUp.CurrentPowerUp) {
            //aqui vai o ifzão pra deixar o capacete
            if(playerPowerUp.CurrentPowerUp is HelmetPowerUp)
            {
                HelmetPowerUp helmet = (HelmetPowerUp)playerPowerUp.CurrentPowerUp;
                //acionar particula pra mostrar q bateu e fazer som quando a gente for botar som
                if(helmet.DealDamage())
                {
                    playerPowerUp.Drop();
                    CameraShaker.Instance.ShakeOnce(10f, 10f, .1f, .2f);
                }
                else
                {
                    CameraShaker.Instance.ShakeOnce(5f, 10f, .1f, .2f);
                }
            }
            else
            {
                
                playerPowerUp.Drop(new Vector2(
                    Random.Range(-5f, 5f),
                    Random.Range(0f, 5f)
                ));

            }
        }
        else
        {
            this.gameObject.SetActive(false);
            // Destroy(this.gameObject);
        }
    }
}
