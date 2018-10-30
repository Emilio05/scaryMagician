    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo : MonoBehaviour {


    private ControlJugador jugador;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        jugador = GetComponent<ControlJugador>();
        rb = GetComponent<Rigidbody>();
	}
	
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "plataforma")
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
            jugador.transform.parent = other.transform;
            jugador.tocandoSuelo = true;
        }
                
    }
	void OnCollisionStay(Collision other)
    {

        if (other.gameObject.tag == "suelo")
        { 
            jugador.tocandoSuelo = true;
        }
        
    }

    void OnCollisionExit(Collision other)
    {

        if (other.gameObject.tag == "suelo")
        {
            jugador.transform.parent = null;
            jugador.tocandoSuelo = false;

        }
        if (other.gameObject.tag == "plataforma")
        {
            jugador.tocandoSuelo = false;

        }
    }
}
