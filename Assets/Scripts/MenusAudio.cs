using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusAudio : MonoBehaviour
{
    public static MenusAudio mAudio;

    public AudioSource som;

    void Awake()
    {
        if (mAudio == null)
        {
            mAudio = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        som = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        som.Play();
    }
}
