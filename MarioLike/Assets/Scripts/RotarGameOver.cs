using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarGameOver : MonoBehaviour {

    float contador = 0;

    float speed;
    float width;
    float height;
    // Use this for initialization
    void Start () {
        speed = 2;
        width = 5;
        height = 5;
    }
	
	// Update is called once per frame
	void Update () {

        contador += Time.deltaTime * speed;

        float x = Mathf.Cos(contador) * width;
        float y = Mathf.Sin(contador) * height;
        float z = 0;

        transform.position = new Vector3(x, y, z);
    }
}
