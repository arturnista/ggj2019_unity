using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField]
    private PlayerInputSchema inputSchema;

    private PlayerPowerUp playerPowerUp;
    private PlayerMovement playerMovement;
    
    void Start()
    {
        playerPowerUp = GetComponent<PlayerPowerUp>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {

        playerMovement.HorizontalSpeed = Input.GetAxisRaw(inputSchema.Axis);
        if(Input.GetKeyDown(inputSchema.Jump)) playerMovement.Jump();

        if(Input.GetKeyDown(inputSchema.Pickup)) playerPowerUp.PickUpAction();

    }

}
