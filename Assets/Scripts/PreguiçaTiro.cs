using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreguiçaTiro : MonoBehaviour
{
    public Rigidbody2D projectile;

    private float Contador = 0f;


    void Start()
    {
        
    }

    void Update()
    {
        Contador += Time.deltaTime;

        if (Contador >= 2.5f)
        {
            Atirar();
            Contador = 0.5f;
        }
    }

    public void Atirar()
    {
            Rigidbody2D clone;
            clone = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody2D;
            Destroy(clone.gameObject, 3.0f);
    }
}
