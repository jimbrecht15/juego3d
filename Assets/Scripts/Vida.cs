﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour { 

    public float valor = 100;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recibirDano(float dano)
    {
        valor -= dano;
        if (valor <0)
        {
            valor = 0;
        }

    }
}
