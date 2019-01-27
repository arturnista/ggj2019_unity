using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSeagullTrigger : MonoBehaviour
{

    public GameObject SeagullSpawner;

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        SeagullSpawner.SetActive(true);
        Destroy(this.gameObject);
    }
}
