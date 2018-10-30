using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour {

    public float velocidadMaxima = 1f;
    public float velocidad = 1f;
    public bool inicioVolteado = false ;
    public bool powerUp2 = false;
    private Rigidbody rb;
    private SpriteRenderer spr;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        spr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    { 

       if(spr.flipX == false && !inicioVolteado)
        {   
            rb.AddForce(Vector3.left * -velocidad);
            float limiteVelocidad = Mathf.Clamp(rb.velocity.x, -velocidadMaxima, velocidadMaxima);
            rb.velocity = new Vector3(-velocidad, rb.velocity.y);

            
            if (velocidad == -1f && transform.position.x >= 12.684f && transform.position.x <= 12.685f)
            {
                spr.flipX = false;
                velocidad = 1f;
            }
            else if (velocidad == 1f && transform.position.x >= -5.327f && transform.position.x <= -5.326f)
            {
                spr.flipX = true;
                velocidad = -1f;
            }
        }
       else
        {
            inicioVolteado = true;
            rb.AddForce(Vector3.left * velocidad);
            float limiteVelocidad = Mathf.Clamp(rb.velocity.x, -velocidadMaxima, velocidadMaxima);
            rb.velocity = new Vector3(velocidad, rb.velocity.y);

            if (velocidad == 1f && transform.position.x >= 12.684f && transform.position.x <= 12.685f)
            {
                spr.flipX = false;
                velocidad = -1f;

            }
            else if (velocidad == -1f && transform.position.x <= -7.625f && transform.position.x >= -7.624f)
            {
                spr.flipX = true;
                velocidad = 1f;
            }
        }
        

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (powerUp2)
            {
                Destroy(gameObject);
            }

           float yOffset = 0.80f;
           if(transform.position.y + yOffset < other.transform.position.y)
            {
                other.gameObject.SendMessage("SaltoEnemigo");
                Destroy(gameObject);
            }
            else
            {
                if(!powerUp2)
                other.gameObject.SendMessage("DanoEnemigo", transform.position.x);
                GameObject.Find("Scripts Globales").GetComponent<ControlJuego>().QuitarVida();

            }

        }

        if(other.gameObject.name == "Platafroma1x1(Clone)")
        {
            if(velocidad == 1f)
            {
                spr.flipX = false;
                velocidad = -1f;
            }
            else if (velocidad == -1f)
            {
                spr.flipX = true;
                velocidad = 1f;
            }
        }
    }

    public void ActivarPowerUp()
    {
        powerUp2 = true;
    }
}
