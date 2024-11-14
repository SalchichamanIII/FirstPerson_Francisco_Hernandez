using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semaforo : MonoBehaviour
{
    private bool yaEjecutado = false;
    // Start is called before the first frame update
    void Start()
    {
        Coroutine sem1= StartCoroutine(EjemploSemaforo());
        Coroutine sem2= StartCoroutine(EjemploSemaforo());
        Coroutine sem3= StartCoroutine(EjemploSemaforo());
        Coroutine sem4= StartCoroutine(EjemploSemaforo());

        StopCoroutine(sem4);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && yaEjecutado == false)
        {
            yaEjecutado=true;
            StartCoroutine (EjemploSemaforo());
        }
    }
    IEnumerator EjemploSemaforo()
    {
        while(true)
        {
            Debug.Log("Verde");
            //Espera 2 segundos
            yield return new WaitForSeconds(2);
            Debug.Log("Amarillo");
            //Espera de 4 segundos
            yield return new WaitForSeconds(4);
            Debug.Log("Rojo");
            yield return new WaitForSeconds(1);
        }
        
    }
}
