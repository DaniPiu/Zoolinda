using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoarAtivar : MonoBehaviour
{
    public Transform detector;

    public float distancia;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit2D player = Physics2D.Raycast(detector.position, Vector2.left, distancia);

        if (player.collider == true)
        {
            GetComponent<VoarInimigo>().enabled = true;
        }
    }
}
