using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGilberto : MonoBehaviour
{
    public static AudioManagerGilberto aMGilberto { get; private set; }

    public AudioClip[] clip;

    public List<AudioSource> aSource = new List<AudioSource>();


    public void Start()
    {
        for (int i = 0; i < clip.Length; i++)
        {
            aSource.Add(new AudioSource());
            aSource[i] = gameObject.AddComponent<AudioSource>();
            aSource[i].clip = clip[i];
            aSource[i].playOnAwake = false;
        }
    }

    public void PlaySound(int s)
    {
        aSource[s].PlayOneShot(clip[s]);
    }
}
