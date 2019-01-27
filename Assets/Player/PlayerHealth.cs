using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using UnityEngine.SceneManagement;

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
        if(playerPowerUp.Holder.CurrentPowerUp) {
            //aqui vai o ifzão pra deixar o capacete
            if(playerPowerUp.Holder.CurrentPowerUp is HelmetPowerUp)
            {
                HelmetPowerUp helmet = (HelmetPowerUp)playerPowerUp.Holder.CurrentPowerUp;
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
                
                CameraShaker.Instance.ShakeOnce(10f, 10f, .1f, .2f);
                playerPowerUp.Drop(new Vector2(
                    Random.Range(-5f, 5f),
                    Random.Range(0f, 5f)
                ));

            }
        }
        else
        {
            // this.gameObject.SetActive(false);
            playerPowerUp.Remove();
            Scene LoadLevel = SceneManager.GetActiveScene();
            SceneManager.LoadScene(LoadLevel.buildIndex);
            // Destroy(this.gameObject);
        }
    }
}
