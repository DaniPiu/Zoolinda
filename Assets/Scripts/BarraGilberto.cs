using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraGilberto : MonoBehaviour
{
    public Image lifebar;
    public Image redBar;

    public int vidaMax;
    int vidaAtual;

    public AudioClip coxinha;
    public AudioClip apanhar;

    AudioSource audio;

    public float Contador;

    private Rigidbody2D rigid;

    public int Nivel;

    void Awake()
    {
        vidaAtual = vidaMax;
    }

    void Start()
    {
        Contador = 1f;
        audio = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Contador += Time.deltaTime;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Inimigo" && PlayerAçoes.Imortal() == false && Contador >= 1f)
        {
            audio.PlayOneShot(apanhar);
            SetHealth(-1);
            Contador = 0f;
        }

        if (col.gameObject.tag == "InimigoBola" && PlayerAçoes.Imortal() == false && Contador >= 1f)
        {
            audio.PlayOneShot(apanhar);
            SetHealth(-2);
            Contador = 0f;
        }

        if (vidaAtual <= 0)
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAçoes>().enabled = false;
            Destroy(this.gameObject, 1.1f);
            StartCoroutine("Morreu");
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Projetil" && PlayerAçoes.Imortal() == false)
        {
            audio.PlayOneShot(apanhar);
            SetHealth(-2);
        }

        if (coll.gameObject.tag == "BossMenor" && PlayerAçoes.Imortal() == false)
        {
            audio.PlayOneShot(apanhar);
            SetHealth(-3);
        }

        if (coll.gameObject.tag == "Claymore" && PlayerAçoes.Imortal() == false)
        {
            audio.PlayOneShot(apanhar);
            SetHealth(-4);
        }

        if (coll.gameObject.tag == "Coxinha")
        {
            audio.PlayOneShot(coxinha);
            Destroy(coll.gameObject);

            if (vidaAtual < vidaMax)
            {
                SetHealth(4);
            }
        }

        if (coll.gameObject.tag == "Buraco")
        {
            SetHealth(-10);
        }

        if (vidaAtual <= 0)
        {
            Destroy(this.gameObject, 1.1f);
            StartCoroutine("Morreu");
        }
    }

    IEnumerator Morreu()
    {
        yield return new WaitForSeconds(0.5f);

        switch (Nivel)
        {
            case 1:
                {
                    SceneManager.LoadScene("GameOver");
                    break;
                }
            case 2:
                {
                    SceneManager.LoadScene("GameOver2");
                    break;
                }
            case 3:
                {
                    SceneManager.LoadScene("GameOver3");
                    break;
                }
            case 4:
                {
                    SceneManager.LoadScene("GameOver4");
                    break;
                }
            case 5:
                {
                    SceneManager.LoadScene("GameOver5");
                    break;
                }
        }
    }
}
