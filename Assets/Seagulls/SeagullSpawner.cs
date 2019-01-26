using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullSpawner : MonoBehaviour
{

    [SerializeField]
    private float spawnDelay;
    [SerializeField]
    private GameObject seagullPrefab;


    void Awake()
    {
        StartCoroutine(Respawn());
    }

    void Update()
    {
        
    }

    IEnumerator Respawn() {
        
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);

            Vector3 spawnPosition = new Vector3(Random.Range(-19f, 19f), 10f);
            Instantiate(seagullPrefab, spawnPosition, Quaternion.identity);
        }

    }
}
