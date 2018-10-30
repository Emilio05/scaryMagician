using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControlMapa : MonoBehaviour {

    public List<GameObject> prefabs;
    private GameObject nuevoObjeto;
    private GameObject nuevoObjeto2;
    private GameObject nuevoObjeto3;
    private GameObject nuevoObjeto4;
    private GameObject nuevoObjeto5;
    private GameObject nuevoObjeto6;
    private GameObject nuevoObjeto7;
    private GameObject nuevoObjeto8;
    private GameObject nuevoObjeto9;
    private GameObject nuevoObjeto10;
    private GameObject nuevoObjeto11;
    private GameObject nuevoObjeto12;
    private GameObject nuevoObjeto13;
    private GameObject nuevoObjeto14;
    private GameObject nuevoObjeto15;

    private Dictionary<char, GameObject> caracteres;
    public int nivelActual = 2;
 
    private void Awake()
    {
        caracteres = new Dictionary<char, GameObject>() { {'S', prefabs[0]}, { 'M', prefabs[1]}, { 'C', prefabs[2] },
            { 'P', prefabs[3] }, { 'K', prefabs[4] }, { 'D', prefabs[5] },{ 'T', prefabs[6] }, { '1', prefabs[7] }, { 'W', prefabs[8] }, { 'Z', prefabs[9] }, { 'J', prefabs[10] }, { 'A', prefabs[11] }, { 'I', prefabs[12] }, { 'X', prefabs[13] }, { 'B', prefabs[14] } };
    }


	// Use this for initialization
	void Start () {

        CargarMapa();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CargarMapa()
    {
        int i = 0, j = 0;
        string mapaLeido = Resources.Load<TextAsset>("Levels/Level" + nivelActual.ToString()).text;

        foreach(char celdaActual in mapaLeido)
        {
            if(celdaActual.Equals("\n"))
            {
                j = 0;
                i++;
                continue;
            }

            switch (celdaActual)
            {
                case 'S':
                    nuevoObjeto = Instantiate(caracteres[celdaActual], new Vector3(-118.4f + j / 2, -4.815f - i / 2), Quaternion.identity);
                    break;
                case 'M':
                    nuevoObjeto2 = Instantiate(caracteres[celdaActual], new Vector3(-87.60f + j / 2, -4f - i / 2), Quaternion.identity);
                    break;
                case 'C':
                    nuevoObjeto3 = Instantiate(caracteres[celdaActual], new Vector3(-72.0f + j / 2, 0f - i / 2), Quaternion.identity);
                    break;
                case 'P':
                    nuevoObjeto4 = Instantiate(caracteres[celdaActual], new Vector3(-60.4f + j / 2, 0f - i / 2), Quaternion.identity);
                    break;
                case 'K':
                    nuevoObjeto5 = Instantiate(caracteres[celdaActual], new Vector3(-34.5f + j / 2, 0.5f - i / 2), Quaternion.identity);
                    break;
                case 'D':
                   // nuevoObjeto6 = Instantiate(caracteres[celdaActual], new Vector3(-40.0f + j / 2, 0f - i / 2), Quaternion.identity);
                    break;
                case 'T':
                    nuevoObjeto7 = Instantiate(caracteres[celdaActual], new Vector3(-9.2f + j / 2, 10f - i / 2), Quaternion.identity);
                    break;
                case '1':
                    nuevoObjeto8 = Instantiate(caracteres[celdaActual], new Vector3(-83.1f + j / 2, -3.4f - i / 2), Quaternion.identity);
                    break;
                case 'W':
                    nuevoObjeto9 = Instantiate(caracteres[celdaActual], new Vector3(-65f + j / 2, 0f - i / 2), Quaternion.identity);
                    break;
                case 'Z':
                    nuevoObjeto10 = Instantiate(caracteres[celdaActual], new Vector3(-332.7f + j / 2, -4.815f - i / 2), Quaternion.identity);
                    break;
                case 'J':
                    nuevoObjeto11 = Instantiate(caracteres[celdaActual], new Vector3(-250.4f + j / 2, -1.815f - i / 2), Quaternion.identity);
                    break;
                case 'A':
                    nuevoObjeto12 = Instantiate(caracteres[celdaActual], new Vector3(-250.4f + j / 2, -1.815f - i / 2), Quaternion.identity);
                    break;
                case 'I':
                    nuevoObjeto13 = Instantiate(caracteres[celdaActual], new Vector3(-233.9f + j / 2, -3.757f - i / 2), Quaternion.identity);
                    break;
                case 'X':
                    nuevoObjeto14 = Instantiate(caracteres[celdaActual], new Vector3(-233.0f + j / 2, -2.767f - i / 2), Quaternion.identity);
                    break;
                case 'B':
                    nuevoObjeto15 = Instantiate(caracteres[celdaActual], new Vector3(-232.2f + j / 2, -2.767f - i / 2), Quaternion.identity);
                    break;
                default:
                    j++;
                    continue;
            }   
            j++;
        }
    }
}
