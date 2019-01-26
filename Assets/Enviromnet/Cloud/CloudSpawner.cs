using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject cloud;

    private PlayerMovement playerMovement;

    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        StartCoroutine(CreateCloud());
    }

    IEnumerator CreateCloud()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);

            Vector3 cameraSize = Utils.Instance.GetCameraSize();
            Vector3 pos = new Vector3(
                playerMovement.transform.position.x + cameraSize.x * 2f,
                cameraSize.y * Random.Range(.5f, 2f)
            );
            Instantiate(cloud, pos, Quaternion.identity);
        }
    }

}
