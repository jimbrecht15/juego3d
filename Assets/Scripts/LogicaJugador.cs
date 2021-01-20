using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Llamar El manejo de la escena 

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool Vida0 = false;
    public float movimiento = 1f;
    public float rotacion = 5f;
    private Animator animadorRender;
    
    
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        animadorRender = GetComponent<Animator>();
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
            //if (Input.GetKey(KeyCode.M)) {
               // animadorRender.SetTrigger("Dispara");
           // }

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
        }
    }

    void reiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
