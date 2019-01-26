using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullSpawner : MonoBehaviour
{

    [SerializeField]
    private float spawnDelay;
    [SerializeField]
    private GameObject seagullPrefab;

    private PlayerMovement playerMovement;


    void Awake()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        StartCoroutine(Respawn());
    }

    void Update()
    {
        
    }

    IEnumerator Respawn() {
        
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);

            Vector2 cameraSize = Utils.Instance.GetCameraSize();

            Vector3 spawnPosition = new Vector3(Random.Range(-cameraSize.x, cameraSize.x), playerMovement.transform.position.y + cameraSize.y);
            Instantiate(seagullPrefab, spawnPosition, Quaternion.identity);
        }

    }
}
