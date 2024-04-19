using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    public GameObject escudim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Projetil")
        {
            escudim.SetActive(false);
        }

        if (col.gameObject.tag == "Inimigo")
        {
            escudim.SetActive(false);
        }
    }
}
