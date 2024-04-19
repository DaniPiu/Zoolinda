using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverInimigos : MonoBehaviour
{
    public float velocidade;
    public float distancia;

    private bool isRight = true;

    public Transform groundCheck;

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distancia);

        if (ground.collider == false)
        {
            if(isRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = true;
            }
        }
    }
}
