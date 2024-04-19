using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverGato : MonoBehaviour
{
    public float Distancia;
    public float Altura;

    private Rigidbody2D rigid;
    private Animator anim;
    private BoxCollider2D bx;
    private bool isRight = false;
    private bool Atacando = false;

    private float Contador = 0f;
    private float Cooldown = 0f;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public bool Gilberto = false;
    public bool Geraldo = false;
    public Transform Detectar;
    public Transform Costas;
    public LayerMask Cainho;

    public GameObject excla;

    public AudioClip atk;

    AudioSource audio;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bx = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Contador += Time.deltaTime;
        Cooldown += Time.deltaTime;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Gilberto = Physics2D.Linecast(Detectar.position, transform.position, Cainho);
        Geraldo = Physics2D.Linecast(Costas.position, transform.position, Cainho);
        Pulo();
        Hitbox();

        if (Gilberto == true && Cooldown >= 2f)
        {
            StartCoroutine("Aviso");
        }

        if (Geraldo == true && Cooldown >= 2f)
        {
            StartCoroutine("AvisoCosta");
        }
    }

    void Pulo()
    {
        if(Contador >= 6f && isRight == false && isGrounded == true && Atacando == false)
        {
            anim.SetBool("jump", true);
            rigid.velocity = rigid.transform.TransformDirection(Distancia, Altura, 0f);
            Contador = 0f;
            StartCoroutine("DelayVira");
        }

        if (Contador >= 6f && isRight == true && isGrounded == true && Atacando == false)
        {
            anim.SetBool("jump", true);
            rigid.velocity = rigid.transform.TransformDirection(-Distancia, Altura, 0f);
            Contador = 0f;
            StartCoroutine("DelayVira");
        }
    }

    void Hitbox()
    {
        if (isGrounded == false)
        {
            bx.enabled = false;
        }
        else
        {
            bx.enabled = true;
        }
    }

    void Flip()
    {
        if (isGrounded == true)
        {
            isRight = !isRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
    }

    public void Atacar()
    {
        if (isGrounded == true)
        {
            anim.SetBool("attack", true);
            Cooldown = 0f;
        }
    }

    public void Atacar2()
    {
        if (isGrounded == true)
        {
            anim.SetBool("attack2", true);
        }
    }

    public void SomAtaque()
    {
        audio.PlayOneShot(atk);
    }

    public void Baixa()
    {
        anim.SetBool("attack", false);
        anim.SetBool("attack2", false);
        Atacando = false;
    }

    IEnumerator Aviso()
    {
        Atacando = true;
        excla.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        excla.SetActive(false);
        Atacar();
    }

    IEnumerator AvisoCosta()
    {
        Atacando = true;
        excla.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        excla.SetActive(false);
        Atacar2();
    }

    IEnumerator DelayVira()
    {
        yield return new WaitForSeconds(2.5f);
        anim.SetBool("jump", false);
        Flip();
    }
}
