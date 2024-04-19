using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoracoesInimigos : MonoBehaviour
{
    public GameObject[] hearts;
    private int vida;

    // Start is called before the first frame update
    void Start()
    {
        vida = hearts.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ataque")
        {
            Dano(1);
        }
    }

    public void Dano(int d)
    {
        if (vida >= 1)
        {
            vida -= d;
            Destroy(hearts[vida].gameObject);
        }
    }
}
