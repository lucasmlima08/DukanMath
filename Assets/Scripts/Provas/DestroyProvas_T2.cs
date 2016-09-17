using UnityEngine;
using System.Collections;

public class DestroyProvas_T2 : MonoBehaviour
{
    public GameObject objectTop;
    public Rigidbody rigidBody;

    private GameObject player;
    private Score score;

    private Vector3 positionNotCollider;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        player = GameObject.Find("Personagem");
        score = player.GetComponent<Score>();
    }

    void Update()
    {
        rigidBody.isKinematic = true;
    }
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Personagem")
        {
            score.destroyObject_T2();

            Destroy(objectTop);
        }
    }
}