using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoarInimigo : MonoBehaviour
{
    public Transform player;
    public int speed;

    private bool facingRight = false;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, Mathf.Abs(speed) * Time.deltaTime);

        if (transform.position.x - player.position.x < 0 && facingRight == false)
        {
            Flip();
        }

        if (transform.position.x - player.position.x > 0 && facingRight == true)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
