using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSkull : MonoBehaviour {

    public GameObject balaFuego;
    public Vector3 velocidadBala = new Vector3(10f, 0, 0);
    public Vector3 aceleracionBala = new Vector3(-1f, 0, 0);

    Vector3 deltaPos;

    bool puedeDisparar = true;
    public Vector3 offset = new Vector3(-3.5f, 0.1f);
    public float coolDown = 1f;

    public float Timer = 1.5f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Timer -= Time.deltaTime;
        
        //if (Timer <= 0)
        //{
            //GameObject go = (GameObject)Instantiate(balaFuego, transform.position - offset, Quaternion.identity);
            //go.GetComponent<Rigidbody>().velocity = new Vector3(-velocidadBala.x, velocidadBala.y);
            //deltaPos = new Vector3(velocidadBala.x *  Time.deltaTime +
            //aceleracionBala.x * Mathf.Pow(Time.deltaTime, 2) / 2), _entidadPelota.VelocidadInicial.y * Time.deltaTime + (_entidadPelota.Aceleracion.y * Mathf.Pow(Time.deltaTime, 2) / 2));

            //gameObject.transform.Translate(deltaPos);
            //scriptCaracter.Posicion = gameObject.transform.position;
            //_entidadPelota.VelocidadInicial += _entidadPelota.Aceleracion * Time.deltaTime;

        //    Timer = 1.5f;
        //}
    }

    void FixedUpdate()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            GameObject go = (GameObject)Instantiate(balaFuego, transform.position + offset, Quaternion.identity);
        deltaPos = new Vector3(velocidadBala.x * Time.deltaTime +
         (aceleracionBala.x * Mathf.Pow(Time.deltaTime, 2) / 2), velocidadBala.y * 
         Time.deltaTime + (aceleracionBala.y * Mathf.Pow(Time.deltaTime, 2) / 2));
        go.transform.Translate(deltaPos);
        velocidadBala += aceleracionBala * Time.deltaTime;
        Timer = 1.5f;
        }


    }
}
