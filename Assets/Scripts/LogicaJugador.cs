using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool Vida0 = false;
    public float movimiento = 3f;
    public float rotacion = 400f;
    private Animator animadorRender;
      

    public GameObject bala;
    public Transform puntoDisparo;

    public float fuerzaDisparo = 1500f;
    public float ratioDisparo = 0.5f;
    public float velocidadBala = 20;

    public float tiempoDisparo = 2;
    private AudioSource audioSource;
    public AudioClip SonDisparo;
    
    [Header("Atributos de arma")]
    public int balasEnCartucho;
    private int tamañoDeCartucho = 12;
    public float daño = 100f;
    public int destruidos = 0;
    public Menu menuJuego;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        animadorRender = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        balasEnCartucho = tamañoDeCartucho;
    }

    // Update is called once per frame
    void Update()
     {
        revisarVida();
        mover();
        rotar();
          if (Input.GetKey(KeyCode.Space))
        {
            animadorRender.SetTrigger("Desenfundar");
            Disparar();
        }
        getBalas();
        getDestruidos();
    }

    public int getDestruidos()
    {
        return destruidos;
    }

    public int getBalas()
    {
        return balasEnCartucho;
    }

    private void Disparar()
    {
        animadorRender.SetTrigger("Dispara");
        
             if (Time.time > tiempoDisparo && balasEnCartucho > 0)
            {
                GameObject newBala;
                newBala = Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
                newBala.GetComponent<Rigidbody>().AddForce(puntoDisparo.forward * fuerzaDisparo);
                DisparoDirecto();
                audioSource.PlayOneShot(SonDisparo);
                balasEnCartucho--;
                tiempoDisparo = Time.time + 1;
                Destroy(newBala, 2);
            }
    }

        private void rotar()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3 (0f, -rotacion, 0f) *Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f, rotacion, 0f) *Time.deltaTime);
        }
    }

    private void mover()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward* movimiento * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * movimiento * Time.deltaTime);
        }
    }

    void revisarVida()
    {
        if (Vida0) return; //si vida0 es true return
        if(vida.valor <= 0)
        {
            Vida0 = true;
            animadorRender.SetTrigger("Vivo");
            
            //Destroy(gameObject, 2);
            Destroy(this);
            gameOver();
        }
    }

    private void gameOver()
    {
        menuJuego.SetUp();
    }

    void DisparoDirecto()
    {
        RaycastHit hit;
        if (Physics.Raycast(puntoDisparo.position, puntoDisparo.forward, out hit))
        {
            if (hit.transform.CompareTag("Enemigo"))
            {
                Vida vida = hit.transform.GetComponent<Vida>();
                if (vida == null)
                {
                    throw new System.Exception("No se encontro el componente vida del enemigo");
                }
                else
                {
                    vida.recibirDano(daño);
                                        
                }
            }
        }
    }

   
}
