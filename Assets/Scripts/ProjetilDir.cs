using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilDir : MonoBehaviour
{
    float speed = 12.0f;
    Rigidbody2D rigid;


    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Defesa")
        {
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
}