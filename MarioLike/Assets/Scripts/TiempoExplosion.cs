using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoExplosion : MonoBehaviour {

    public float tiempoExplosion = 0.3f;

	// Use this for initialization
	void Start () {

        Destroy(this.gameObject, tiempoExplosion);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
