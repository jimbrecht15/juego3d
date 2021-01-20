using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicaArma : MonoBehaviour
{
    protected Animator animator;
    protected AudioSource audioSource;
    public bool tiempoNoDisparo = false;
    public bool puedeDisparar = false;
    public bool recargando = false;
   

    [Header("Referencia de Objetos")]  //Se usa para dar titulos y ordenar las variables 
    public ParticleSystem fuegoArma;

    [Header("Referencia Sonidos")]
    public AudioClip SonDisparo;

    [Header("Atributos de arma")]
    
    public float daño = 20f;
    public float ritmoDisparo = 0.3f;
    public int balasEnCartucho;
    public int tamanoCartucho = 12;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        balasEnCartucho = tamanoCartucho;
        Invoke(methodName: "HabilitarArma", 0.5F);
       
    }

    // Update is called once per frame
    void Update()
    {
        RevisarDisparo();
        

    }

    void HabilitarArma()
    {
        puedeDisparar = true;
    }
    void RevisarDisparo()
    {
        if (!puedeDisparar) return;
        if (tiempoNoDisparo) return;
        if (recargando) return;
        if(balasEnCartucho > 0)
        {
            Disparar();
        }
    }
     void Disparar()
    {
        audioSource.PlayOneShot(SonDisparo);
        tiempoNoDisparo = true;
        fuegoArma.Stop();
        fuegoArma.Play();
        ReproducirAnimacionDisparo();
        balasEnCartucho--;
        StartCoroutine(ReiniarTiempoNoDisparo());

    }


    public virtual void ReproducirAnimacionDisparo()
    {
        if(balasEnCartucho > 1)
        {
            animator.CrossFadeInFixedTime("FireLast", 0.1f);
        }

    }

    void SinBalas()
    {
        tiempoNoDisparo = true;
        StartCoroutine(ReiniarTiempoNoDisparo());
    }

    IEnumerator ReiniarTiempoNoDisparo()
    {
        yield return new WaitForSeconds(ritmoDisparo);
        tiempoNoDisparo = false;
    }

}
