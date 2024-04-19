using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float empurra;

    private Rigidbody2D rigid;
    private Animator anim;
    private AudioSource audio;

    [SerializeField] private Joystick controle;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float moveInput;

    private bool facingRight = true;

    private float Contador = 0.8f;
    private float tempoAtaque = 0.8f;

    public GameObject vidaInimigo;
    public GameObject chefeInimigo;

    public AudioClip pulo;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Anda();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        Contador += Time.deltaTime;

        if (Contador >= tempoAtaque && isGrounded == true)
        {
            anim.SetBool("jump", false);
            Contador = 0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Pula();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void Anda()
    {
        moveInput = Input.GetAxis("Horizontal");
        moveInput = controle.Horizontal;

        rigid.velocity = new Vector2(moveInput * speed, rigid.velocity.y);

        if (moveInput > 0 && isGrounded == true)
        {
            anim.SetBool("walk", true);
        }

        if (moveInput < 0 && isGrounded == true)
        {
            anim.SetBool("walk", true);
        }

        if (moveInput == 0 && isGrounded == true)
        {
            anim.SetBool("walk", false);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    public void Pula()
    {
        if (isGrounded == true)
        {
            rigid.velocity = Vector2.up * jumpForce;
            anim.SetBool("jump", true);
            audio.PlayOneShot(pulo);
        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataforma")
            this.transform.parent = col.transform;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Plataforma")
            this.transform.parent = null;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Bosses")
        {
            vidaInimigo.SetActive(true);
            chefeInimigo.SetActive(true);
        }
    }
}