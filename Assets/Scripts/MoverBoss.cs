using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBoss : MonoBehaviour
{
    //Andando pra direita?
    private bool moveRight = false;
    //Virar
    private bool facingRight = false;

    //Velocidade da caminhada
    public float velocidadeBoss;
    //Velocidade de verdade
    private float velocidade;

    public float BossVida;

    //Ir para a esquerda
    public Transform pontoA;
    //Ir para a direita
    public Transform pontoB;

    //Hitbox do ataque
    public GameObject arma;
    //Aviso
    public GameObject excla;

    private Rigidbody2D rigid;
    private Animator anim;

    private float Contador = 2f;

    public bool Gilberto = false;
    public bool Geraldo = false;
    public Transform Detectar;
    public Transform Costas;
    public LayerMask Cainho;

    public AudioClip atk;

    AudioSource audio;


    void Start()
    {
        velocidade = velocidadeBoss;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        Gilberto = Physics2D.Linecast(Detectar.position, transform.position, Cainho);
        Geraldo = Physics2D.Linecast(Costas.position, transform.position, Cainho);
        Contador += Time.deltaTime;
        
        if (Gilberto == true && Contador > 2f)
        {
            velocidade = 0f;
            anim.SetBool("idle", true);
            StartCoroutine("Aviso");
        }

        if (Geraldo == true)
        {
            Flip();
            moveRight = !moveRight;
        }

        if (transform.position.x < pontoA.position.x && moveRight == false)
        {
            Flip();
            moveRight = true;
        }
        if (transform.position.x > pontoB.position.x && moveRight == true)
        {
            Flip();
            moveRight = false;
        }

        if (moveRight)
            transform.position = new Vector2(transform.position.x + velocidade * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - velocidade * Time.deltaTime, transform.position.y);
    }

    public void Atacar()
    {
        anim.SetBool("idle", false);
        Contador = 0f;
    }

    public void Baixa()
    {
        anim.SetBool("attack", false);
        velocidade = velocidadeBoss;
    }

    public void SomAtaque()
    {
        audio.PlayOneShot(atk);
    }

    IEnumerator Aviso()
    {
        excla.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        excla.SetActive(false);
        Atacar();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}