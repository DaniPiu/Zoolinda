using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAçoes : MonoBehaviour
{
    public GameObject arma;
    public GameObject escudo;

    private float Contador = 0.8f;
    private float tempoAtaque = 0.8f;
    private float Temporizador = 0.8f;
    private float tempoDefesa = 0.8f;

    public bool ataqueAtivo = false;
    public static bool defesaAtiva = false;

    private Rigidbody2D rigid;
    private Animator anim;

    public AudioClip soco;
    public AudioClip escud;

    AudioSource audio;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Contador += Time.deltaTime;
        Temporizador += Time.deltaTime;
        if (Input.GetKeyDown("c"))
        {
            Ataca();
        }

        if (Input.GetKeyDown("v"))
        {
            Defende();
        }
        
    }

    public void Ataca()
    {
        if (Contador >= tempoAtaque && defesaAtiva == false)
        {
            anim.SetBool("punch", true);
            ataqueAtivo = true;
            StartCoroutine("Baixa");
            Contador = 0f;
        }
    }

    public void Defende()
    {
        if (Temporizador >= tempoDefesa && ataqueAtivo == false)
        {
            defesaAtiva = true;
            escudo.SetActive(true);
            audio.PlayOneShot(escud);
            StartCoroutine("Dispersa");
            Temporizador = 0f;
        }
    }

    public void SomSoco()
    {
        audio.PlayOneShot(soco);
    }

    public static bool Imortal()
    {
        if(defesaAtiva == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Baixa()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("punch", false);
        arma.SetActive(false);
        ataqueAtivo = false;
    }

    IEnumerator Dispersa()
    {
        yield return new WaitForSeconds(0.5f);
        escudo.SetActive(false);
        defesaAtiva = false;
    }
}
