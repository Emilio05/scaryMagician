using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour {

    public Rigidbody rb;
    public GameObject explosion;
    public Vector3 velocidad;


	// Use this for initialization
	void Start () {

        Destroy(this.gameObject, 5);
        rb = GetComponent<Rigidbody>();
        velocidad = rb.velocity;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(rb.velocity.y < velocidad.y)
        {
            rb.velocity = velocidad;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "momia" || other.collider.tag == "spider")
        {
            Destroy(other.gameObject);
            Explotar();
        }

        rb.velocity = new Vector3(velocidad.x, -velocidad.y);


        if (other.contacts[0].normal.x != 0)
        {
            Explotar();
        }
    }

    void Explotar()
    {
        Instantiate(explosion, transform.position, Quaternion.identity); 
        Destroy(this.gameObject);
    }
}
