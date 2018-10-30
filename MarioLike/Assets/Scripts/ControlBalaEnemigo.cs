using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBalaEnemigo : MonoBehaviour {

    public Rigidbody rb;
    public Vector3 velocidad;

    // Use this for initialization
    void Start () {

        Destroy(this.gameObject, 15);
        rb = GetComponent<Rigidbody>();
        velocidad = rb.velocity;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Scripts Globales").GetComponent<ControlJuego>().QuitarVida();
            other.transform.position = new Vector3(-6f, 1f, 0);
            StartCoroutine(GameObject.Find("ZonaMuertaDer").GetComponent<ControlZonaMuerta>().DesactivarZonaMuerta());
            Destroy(gameObject);
        }

    }

}
