using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jogador;

    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, jogador.position, 0.1f);
    }
}
