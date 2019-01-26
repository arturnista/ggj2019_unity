using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{

    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private float moveSpeed = 2f;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        moveSpeed *= Random.Range(0.9f, 1.1f);
        transform.localScale = transform.localScale * Random.Range(0.7f, 1.3f);
    }

    void Update()
    {
        transform.Translate(moveSpeed * -transform.right * Time.deltaTime);
    }
}
