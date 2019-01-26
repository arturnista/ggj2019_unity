using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                playerPowerUp.CurrentPowerUp.Lifes--;
                //acionar particula pra mostrar q bateu e fazer som quando a gente for botar som
                if(playerPowerUp.CurrentPowerUp.Lifes <=0)
                {
                    playerPowerUp.CurrentPowerUp.Lifes = 3;
                    playerPowerUp.Drop();
                }
            }
            else
            playerPowerUp.Drop();
        }
        else
        {
            this.gameObject.SetActive(false);
            // Destroy(this.gameObject);
        }
    }
}
