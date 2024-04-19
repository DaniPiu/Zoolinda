using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamanduaAnim : MonoBehaviour
{
    private const int TamanduaIdle = 0;
    private const int TamanduaAtaque = 1;
    private const int TamanduaMorte = 2;
    Animator anima;
    Rigidbody2D rigid;

    bool bloqueio = false;

    public int InimigoVida;

    public AudioClip apanhar;
    public AudioClip fogo;

    AudioSource audio;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (bloqueio == false)
        {
            Atirar();
            StartCoroutine("Cooldown");
        }
    }

    void Atirar()
    {
        bloqueio = true;
        //audio.PlayOneShot(fogo);
        anima.SetInteger("state", TamanduaAtaque);
        StartCoroutine("Trocar");
    }

    /*void Morte()
    {
        anima.SetInteger("state", PalhacoMorte);
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ataque")
        {
            audio.PlayOneShot(apanhar);
            InimigoVida--;
        }

        if (col.gameObject.tag == "Pisa")
        {
            audio.PlayOneShot(apanhar);
            InimigoVida--;
        }

        if (InimigoVida == 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<BoxCollider2D>().enabled = false;
            anima.SetInteger("state", TamanduaMorte);
            Destroy(this.gameObject, 0.7f);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2.5f);
        bloqueio = false;
    }

    IEnumerator Trocar()
    {
        yield return new WaitForSeconds(0.3f);
        anima.SetInteger("state", TamanduaIdle);
    }

    /*IEnumerator Retorno()
    {
        yield return new WaitForSeconds(0.5f);
        anima.SetInteger("state", TamanduaIdle);
    }*/
}