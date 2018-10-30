using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour {

    public GameObject NombreProtagonista;

    public List<GameObject> vidas;
    public GameObject gameover;
    public static int totalVida;
    public EntidadProtagonista prota;

    // Use this for initialization
    void Start () {

        NombreProtagonista.GetComponent<TextMesh>().text = PlayerPrefs.GetString("NombreProtagonista");

        totalVida = 3;
        foreach(GameObject vida in vidas)
        {
            vida.gameObject.SetActive(true);
        }
        gameover.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update () {

        switch (totalVida)
        {
            case 3:
                vidas[0].gameObject.SetActive(true);
                vidas[1].gameObject.SetActive(true);
                vidas[2].gameObject.SetActive(true);
                break;

            case 2:
                vidas[0].gameObject.SetActive(true);
                vidas[1].gameObject.SetActive(true);
                vidas[2].gameObject.SetActive(false);
                break;

            case 1:
                vidas[0].gameObject.SetActive(true);
                vidas[1].gameObject.SetActive(false);
                vidas[2].gameObject.SetActive(false);
                break;

            case 0:
                vidas[0].gameObject.SetActive(false);
                vidas[1].gameObject.SetActive(false);
                vidas[2].gameObject.SetActive(false);
                StartCoroutine(GameOver());
                break;

        }
	}

    IEnumerator GameOver()
    {
        gameover.transform.position = new Vector3(-5f, 0f);
        gameover.gameObject.SetActive(true);
        yield return new WaitForSeconds(10f);
        gameover.transform.position = new Vector3(0f, 0f);
        Time.timeScale = 0;
    }
    public void QuitarVida()
    {
        totalVida--;
    }
}
