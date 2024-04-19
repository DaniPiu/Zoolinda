using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public int InimigoVida;

    public AudioClip apanharBoss;

    AudioSource audio;

    private Animator anim;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ataque")
        {
            InimigoVida--;
            audio.PlayOneShot(apanharBoss);
        }
        if (InimigoVida == 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<BoxCollider2D>().enabled = false;
            anim.SetBool("death", true);
            Destroy(this.gameObject, 0.7f);
        }
    }
}
