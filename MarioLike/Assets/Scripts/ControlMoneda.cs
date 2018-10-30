using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControlMoneda : MonoBehaviour {
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SegundaEscena", LoadSceneMode.Additive);
            GameObject.Find("Main Camera").GetComponent<ControlMapa>().nivelActual++;
        }
    }
}
