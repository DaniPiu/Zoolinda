using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPreguiça : MonoBehaviour
{
    private Animator anim;

    AudioSource audio;

    private float Contador = 0f;

    public AudioClip atk;

    public GameObject Spear;


    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Contador += Time.deltaTime;

        if (Contador >= 2f)
        {
            anim.SetBool("attack", true);
            Contador = 0f;
        }
    }

    public void Baixa()
    {
        anim.SetBool("attack", false);
    }

    public void SomAtaque()
    {
        audio.PlayOneShot(atk);
    }

    public void Desativa()
    {
        Spear.SetActive(false);
    }
}
