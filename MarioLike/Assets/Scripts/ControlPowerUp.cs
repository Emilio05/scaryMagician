using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPowerUp : MonoBehaviour {

    public float multiplier = 10f;
    public float duration = 20f;

    public GameObject efectoAtrapar;
    public GameObject controlJugador;
    private GameObject powerUpPadre;
void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controlJugador.GetComponent<ControlJugador>().puedeDisparar = true;
            StartCoroutine(Atrapar(other));

        }
    }

    
    IEnumerator Atrapar(Collider protaginista)
    {

        Instantiate(efectoAtrapar, transform.position, transform.rotation);
        //EntidadProtagonista entidadProtagonisa = protaginista.GetComponent<EntidadProtagonista>();
        //entidadProtagonisa.transform.localScale *= multiplier;
        GameObject.FindGameObjectWithTag("Player").transform.localScale *= multiplier;

        //GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>(). enabled = false;

        yield return new WaitForSeconds(duration);

        gameObject.GetComponentInParent<SpriteRenderer>().enabled = false;
        GameObject.Find("blow(Clone)").GetComponent<MeshRenderer>().enabled = false;
        controlJugador.GetComponent<ControlJugador>().puedeDisparar = false;

    }
}
