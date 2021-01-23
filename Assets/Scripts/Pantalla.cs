using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pantalla : MonoBehaviour
{
    public Text textoVida;
    public Text balas;
    public Text NumDestruidos;
    private LogicaJugador logicaJugador;
    public Vida vida;
    public int balasRestantes;
    public int destruidos;
    


    // Start is called before the first frame update
    void Start()
    {
        logicaJugador = GetComponent<LogicaJugador>();
        balasRestantes = logicaJugador.getBalas();
        destruidos = logicaJugador.getDestruidos(); ;
    }

    // Update is called once per frame
    void Update()
    {
        textoVida.text = "Vida = " + vida.valor + "/100";
        balas.text = "Balas= " +  + logicaJugador.getBalas() ;
        NumDestruidos.text = "Destruidos = " + logicaJugador.getDestruidos();
    }


}
