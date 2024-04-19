using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraBoss : MonoBehaviour
{
    public Image lifebar;
    public Image redBar;

    public int vidaMax;
    int vidaAtual;

    private Animator anim;

    public AudioClip apanharBoss;

    AudioSource audio;

    public int tipo;

    public GameObject Porta;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        vidaAtual = vidaMax;
    }


    void Update()
    {

    }

    public void SetHealth(int amount)
    {
        vidaAtual = Mathf.Clamp(vidaAtual + amount, 0, vidaMax);

        Vector3 lifebarScale = lifebar.rectTransform.localScale;
        lifebarScale.x = (float)vidaAtual / vidaMax;
        lifebar.rectTransform.localScale = lifebarScale;
        StartCoroutine(DecreasingRedBar(lifebarScale));
    }

    IEnumerator DecreasingRedBar(Vector3 newScale)
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 redBarScale = redBar.transform.localScale;

        while (redBar.transform.localScale.x > newScale.x)
        {
            redBarScale.x -= Time.deltaTime * 0.25f;
            redBar.transform.localScale = redBarScale;

            yield return null;
        }

        redBar.transform.localScale = newScale;
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Ataque")
        {
            SetHealth(-1);
            audio.PlayOneShot(apanharBoss);
        }

        if (col.gameObject.tag == "Garantia")
        {
            SetHealth(-5);
            audio.PlayOneShot(apanharBoss);
        }

        switch (tipo)
        {
            case 0:
                {
                    if (vidaAtual == 0)
                    {
                        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                        GetComponent<BoxCollider2D>().enabled = false;
                        GetComponent<MoverBoss>().enabled = false;
                        anim.SetBool("death", true);
                        Destroy(this.gameObject, 1.3f);
                        Porta.SetActive(true);
                    }
                    break;
                }
            case 1:
                {
                    if (vidaAtual == 0)
                    {
                        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                        GetComponent<BoxCollider2D>().enabled = false;
                        anim.SetBool("death", true);
                        Destroy(this.gameObject, 1.3f);
                        Porta.SetActive(true);
                    }
                    break;
                }
            case 2:
                {
                    if (vidaAtual == 0)
                    {
                        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                        GetComponent<BoxCollider2D>().enabled = false;
                        GetComponent<MoverGato>().enabled = false;
                        anim.SetBool("death", true);
                        Destroy(this.gameObject, 1.3f);
                        Porta.SetActive(true);
                    }
                    break;
                }
        }

    }
}
