using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour {

    public GameObject seguir;
    public Vector3 posMinCamara, posMaxPos;
    public float tiempoSuavizado;
    public GameObject player;       //Public variable to store a reference to the player game object 
    private Vector3 velocidad;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = Mathf.SmoothDamp(transform.position.x, seguir.transform.position.x, ref velocidad.x, tiempoSuavizado);
        float posY = Mathf.SmoothDamp(transform.position.y, seguir.transform.position.y, ref velocidad.y, tiempoSuavizado);

        transform.position = new Vector3(Mathf.Clamp(posX, posMinCamara.x, posMaxPos.x), Mathf.Clamp(posY, posMinCamara.y, posMaxPos.y), transform.position.z);

	}
}
