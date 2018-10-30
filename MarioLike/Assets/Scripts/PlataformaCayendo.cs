using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCayendo : MonoBehaviour {

    public float fallDelay = 1f;
    public float respawnDelay = 5f;

    private Rigidbody rb;
    private BoxCollider bc;
    private Vector3 posInicial;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update () {
		
	}
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            Invoke("Respawn", fallDelay + respawnDelay);

        }
    }

    void Fall()
    {
        rb.isKinematic = false;
        bc.isTrigger = true;
    }

    void Respawn()
    {
        transform.position = posInicial;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        bc.isTrigger = false;
        
    }
}
