using UnityEngine;
using System.Collections;

public class DestroyProvas_T1 : MonoBehaviour
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
            GameObject player = GameObject.Find("Personagem");
            Score score = player.GetComponent<Score>();

            score.destroyObject_T1();

            Destroy(objectTop);
        }
    }
}