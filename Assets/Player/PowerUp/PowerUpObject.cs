using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpObject : MonoBehaviour
{

    [SerializeField]
    private PowerUp powerUp;

    void Start()
    {
        if(powerUp) Construct(powerUp);
    }

    public void Construct(PowerUp pw)
    {
        powerUp = pw;
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = powerUp.Sprite;
    }

    public PowerUp GetPowerUp(GameObject go) {
        powerUp.Apply(go);
        Destroy(this.gameObject);
        return powerUp;
    }

}