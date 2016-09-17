using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rigidBody;

    private Vector3 positionNotCollider;

    private bool statusCollider;
    private int disparosCollider;

    public int recuoDeColisao = 30;

    void Start()
    {
        Debug.Log("Iniciou a Classe de Colisao!");
        rigidBody = GetComponent<Rigidbody>();
        statusCollider = false;
        disparosCollider = 0;
        
    }

    void Update()
    {
        rigidBody.isKinematic = true;

        // Se colidiu, ativa recuo de colisão.
        if (statusCollider == true/* && disparosCollider <= 2*/)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(0.0f, 0.0f, -recuoDeColisao);
            } else
            {
                transform.Translate(0.0f, 0.0f, recuoDeColisao);
            }
            statusCollider = false;
        }
    }

    int acm = 0;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "LabirintoParedes")
        {
            Debug.Log("Colidiu com as paredes! " + acm);
            statusCollider = true;
            disparosCollider++;

            acm++;
        }
        else
        {
            statusCollider = false;
        }

        /*if (col.gameObject.name == "LabirintoChao")
        {
            Debug.Log("Colidiu com o chão!");
            //rb.isKinematic = true;
        }*/

        //rb.isKinematic = true;
        //rb.isKinematic = false;
        //rb.detectCollisions = false;
    }
}