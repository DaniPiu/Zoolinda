using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaRedondo : MonoBehaviour
{
    public int InimigoVida;
    Animator anim;

    public AudioClip apanhar;

    AudioSource audio;

    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ataque")
        {
            InimigoVida--;
            audio.PlayOneShot(apanhar);
        }
        if (InimigoVida == 0)
        {
            anim.SetBool("death", true);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<CircleCollider2D>().enabled = false;
            Destroy(this.gameObject, 0.7f);
        }
    }
}