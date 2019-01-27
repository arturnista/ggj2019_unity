using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField]
    private PlayerInputSchema[] inputSchemas;

    private PlayerPowerUp playerPowerUp;
    private PlayerMovement playerMovement;
    
    void Start()
    {
        playerPowerUp = GetComponent<PlayerPowerUp>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {

        foreach(PlayerInputSchema schema in inputSchemas) {
            if(schema.Axis.Length > 0) playerMovement.HorizontalSpeed = Input.GetAxisRaw(schema.Axis);
            if(Input.GetKeyDown(schema.Jump)) playerMovement.Jump();

            if(Input.GetKeyDown(schema.Pickup)) playerPowerUp.PickUpAction();
        }

    }

}
