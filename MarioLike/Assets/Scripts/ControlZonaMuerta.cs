using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlZonaMuerta : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("Scripts Globales").GetComponent<ControlJuego>().QuitarVida();
            other.transform.position = new Vector3(-6f, 1f, 0);
            StartCoroutine(DesactivarZonaMuerta());
        }
        else
        {
            Destroy(other.gameObject);
        }
      

    }

    public IEnumerator DesactivarZonaMuerta()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<Collider>().enabled = true;
    }

}
