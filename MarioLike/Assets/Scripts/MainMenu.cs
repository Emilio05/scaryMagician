using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour {

    public InputField nombreProtagonista;
    public void Jugar()
    {
        SceneManager.LoadScene("PrimeraEscena"); 
    }

    public void Salir()
    {
        Application.Quit(); 
    }

    public void GuardarNombre()
    {
        PlayerPrefs.SetString("NombreProtagonista", nombreProtagonista.text);
        PlayerPrefs.Save();
    }

}
