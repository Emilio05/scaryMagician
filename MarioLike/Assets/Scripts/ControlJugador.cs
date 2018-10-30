using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour {

    public float velocidadMaxima = 5f;
    public float velocidad = 2f;
    public bool tocandoSuelo;
    public float fuerzaSalto = 3f;

    Vector3 deltaPos;


    public GameObject bombaDeAgua;
    public Vector3 velocidadBala = new Vector3(5f, 0, 0);
    public Vector3 aceleracionBala = new Vector3(1f, 0, 0);

    public bool puedeDisparar = false;
    public Vector3 offset = new Vector3(0.4f, 0.1f);
    public float coolDown = 1f;
    public float tiempoPowerUpDisparar = 15f;

    private ComprobarSuelo comprobarSuelo;
    private Animator animator;
    private SpriteRenderer spr;
    private Rigidbody rb;
    private bool saltando;
    private bool dobleSalto;
    private bool movimiento = true;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        animator.SetFloat("Velocidad",  Mathf.Abs(rb.velocity.x));
        animator.SetBool("TocandoSuelo", tocandoSuelo);

        if (tocandoSuelo)
        {
            dobleSalto = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && tocandoSuelo){
            if (tocandoSuelo)
            {
                saltando = true;
                dobleSalto = true;
            }
            else if (dobleSalto)
            {
                saltando = true;
                dobleSalto = false;
            }
          
        }


        Dispara();

    }

    void Dispara()
    {
        if (Input.GetKeyDown("space") && puedeDisparar)
        {
            GetComponent<Animator>().SetTrigger("Atacar");

            GameObject go = (GameObject)Instantiate(bombaDeAgua, transform.position + offset * transform.localScale.x, Quaternion.identity);
        //    deltaPos = new Vector3(velocidadBala.x * Time.deltaTime +
        //(aceleracionBala.x * Mathf.Pow(Time.deltaTime, 2) / 2), velocidadBala.y * Time.deltaTime + (aceleracionBala.y * Mathf.Pow(Time.deltaTime, 2) / 2));
            go.GetComponent<Rigidbody>().velocity = new Vector3(velocidadBala.x * transform.localScale.x, velocidadBala.y);
            //go.transform.Translate(deltaPos);
            //velocidadBala += aceleracionBala * Time.deltaTime;

        }
     //  yield return new WaitForSeconds(tiempoPowerUpDisparar);
     //  puedeDisparar = false;
    }
    IEnumerator CoolDownDisparo()
    {
        puedeDisparar = false;
        yield return new WaitForSeconds(coolDown);
        puedeDisparar = true;
    }

    void FixedUpdate(){

        //reducir velocidad para simular friccion
        Vector3 velocidadArreglada = rb.velocity;
        velocidadArreglada.x *= 0.75f;

        if (tocandoSuelo)
        {
            rb.velocity = velocidadArreglada;
        }
        float posH = Input.GetAxis("Horizontal");
        if (!movimiento)
        {
            posH = 0;
        }
        rb.AddForce(Vector3.right * velocidad * posH);

        float limiteVelocidad = Mathf.Clamp(rb.velocity.x, -velocidadMaxima, velocidadMaxima);
        rb.velocity = new Vector3(limiteVelocidad, rb.velocity.y);

        if(posH > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
             
        }  

        if(posH < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        if (saltando)
        { 
            rb.velocity = new Vector3(rb.velocity.x, 0);
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            saltando = false;
        }
    }

    void OnBecameInvisible()
    {
        StartCoroutine(Esperar());
    }

    IEnumerator Esperar()
    {
        transform.position = new Vector3(-6f, 1f, 0);
        yield return new WaitForSeconds(2f);
        //GameObject.Find("Scripts Globales").GetComponent<ControlJuego>().QuitarVida();
    }
    public void SaltoEnemigo()
    {
        saltando = true;
    }

    public void DanoEnemigo(float posEnemigoX)
    {
        saltando = true;

        float lado = Mathf.Sign(posEnemigoX - transform.position.x);
        rb.AddForce(Vector3.left * lado, ForceMode.Impulse);
        movimiento = false;
        Invoke("ActivarMovimiento", 1f);

        spr.color = Color.red;
    }

    void ActivarMovimiento()
    {
        movimiento = true;
        spr.color = Color.white;
    }

    public void PuedeDisparar()
    {
        puedeDisparar = true;
    }
}
