using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPumpkin : MonoBehaviour {

    public Transform[] pumpkinSpawns;
    public GameObject pumpkin;

    // Use this for initialization
    void Start () {
        Spawn();
    }
	

    void Spawn()
        {
            for (int i = 0; i < pumpkinSpawns.Length; i++)
            {
                int coinFlip = Random.Range(0, 2);
                if (coinFlip > 0)
                    Instantiate(pumpkin, pumpkinSpawns[i].position, Quaternion.identity);
            }
        }

 }







   
