using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;

    //Recoge el indice de arma actual
    private int indiceArmaActual;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambiarArmaConTeclado();
        CambiarArmaConRaton();
    }

    private void CambiarArmaConRaton()
    {
       float scrollwheel = Input.GetAxis("Mouse ScrollWheel");

        if(scrollwheel > 0)//Siguiente
        {
            CambiarArma(indiceArmaActual + 1);
        }
        else if(scrollwheel < 0)//Anterior
        {
            CambiarArma(indiceArmaActual - 1);
        }
    }

    private void CambiarArmaConTeclado()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambiarArma(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambiarArma(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            CambiarArma(3);
        }
    }

    private void CambiarArma(int indiceNuevaArma)
    {
        //Desactivo el arma actual
        armas[indiceArmaActual].SetActive(false);

        //Si me ha llegado un indice de armas que es negativo
        if(indiceNuevaArma <0)
        {
            indiceNuevaArma = armas.Length - 1; //el indice es el ultimo de la lista
        }
        else if(indiceNuevaArma >= armas.Length)
        {
            indiceNuevaArma = 0;
        }

        //Activar la nueva
      armas[indiceNuevaArma].SetActive(true);

        indiceArmaActual = indiceNuevaArma;
    }

    public int GetCurrentWeaponIndex()
    {
        return indiceArmaActual;
    }
}
