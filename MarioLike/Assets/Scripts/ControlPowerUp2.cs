using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPowerUp2 : MonoBehaviour {


    private SpriteRenderer spr;
    private Rigidbody rb;
    public float tiempoInvencible = 5f;
    public GameObject bala;
    public GameObject momia;
    public GameObject spider;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        spr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if (other.CompareTag("Player"))
        {
            bala.GetComponent<Collider>().enabled = false;
            spider.GetComponent<ControlMeteorito>().powerUp2 = true;

            foreach(GameObject enemigo in GameObject.FindGameObjectsWithTag("momia"))
            {
                enemigo.GetComponent<ControlEnemigo>().ActivarPowerUp();
            }
            other.GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(SafeMode());
        }
    }

    IEnumerator SafeMode()
    {
        yield return new WaitForSeconds(tiempoInvencible);

        GameObject.Find("Protagonista").GetComponent<SpriteRenderer>().color = Color.white;
        bala.GetComponent<Collider>().enabled = true;
        momia.GetComponent<ControlEnemigo>().powerUp2 = false;
        spider.GetComponent<ControlMeteorito>().powerUp2 = false;

        Destroy(gameObject);

    }

}
