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
            playerPowerUp.Drop();
        }
        else
        {
            this.gameObject.SetActive(false);
            // Destroy(this.gameObject);
        }
    }
}
