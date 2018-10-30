using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntidadProtagonista : MonoBehaviour {

    public float Dano { get; set; }

    public float Defensa { get; set; }

    public int Vida { get; set; }

    public bool QuitarVida()
    {
        return (Vida--) <= 0;
    }
}
