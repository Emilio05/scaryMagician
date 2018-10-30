using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMeteorito : MonoBehaviour {

    private float v = 0.0f;
    private Vector3 pos;
    private float g = 9.8f;

    public bool powerUp2 = false;
   
    // Use this for initialization
    void Start () {

        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        float up = 0.0f;  // Upward force

        up = 8.0f;  // Apply some upward force
       

        float t = Time.deltaTime;
        float delta = v * t + (up - g) * t * t * 0.5f;
        v = v + (up - g) * t;

        pos.y += delta;

        if (pos.y < 0.0f)
        {
            pos.y = 0.0f;
            v = -v * .8f;
        }
        transform.position = pos;

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !powerUp2)
        {
            GameObject.Find("Scripts Globales").GetComponent<ControlJuego>().QuitarVida();
            other.transform.position = new Vector3(-6f, 1f, 0);
            StartCoroutine(GameObject.Find("ZonaMuertaDer").GetComponent<ControlZonaMuerta>().DesactivarZonaMuerta());
           // gameObject.GetComponent<AudioSource>().Play();
        }
        else if(other.gameObject.CompareTag("Player") && powerUp2)
        {
            Destroy(gameObject);
        }
    }
}
