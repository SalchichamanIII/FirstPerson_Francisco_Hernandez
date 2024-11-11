using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float vidas;
    
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento; 
    [SerializeField] private float factorGravedad;
    [SerializeField] private float alturaSalto;

    [Header("Deteccion Suelo")]
    [SerializeField] private float radioDeteccion;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask queEsSuelo;


    CharacterController controller;
    //Me sirve tanto para la gravedad como para los saltos 
    private Vector3 movimientoVertical;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Bloquea el raton en centro de la pantalla y lo oculta
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MoverYRotar();
    }
    void MoverYRotar()
    {
        //float angulo = 0;
       float h = Input.GetAxisRaw("Horizontal"); //h=0 , h=-1, h=1
       float v= Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
        //if(h == 0 && v != -1)
        //{
        //    //Calculo el angulo al que tengo que rotarme en funcion de los inputs y camara.
        //    angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        //    transform.eulerAngles = new Vector3(0, angulo, 0);
        //}
        //Calculo el angulo al que tengo que rotarme en funcion de los inputs y camara.
        float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        //transform.eulerAngles = new Vector3(0, angulo, 0);

        transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        // Si el jugador tocla teclas
        if (input.magnitude > 0 )
        {
           
            //Mi movimiento tambien ha quedado rotado en base al angulo calculado.
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }

       
       
        //Vector3 movimiento = new Vector3(h, 0, v).normalized;
        //float anguloRotacion = Camera.main.transform.eulerAngles.y;
        //controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        AplicarGravedad();
        if (EnSuelo())
        {
            movimientoVertical.y = 0;
            Saltar();
        }
    }

    public void RecibirDanho(float danhoEnemigo)
    {
        vidas -= danhoEnemigo;
    }
   

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * factorGravedad * alturaSalto);
        }
    }

    private void AplicarGravedad()
    {
        //Mi velocidadVertical va en aumento a cierto factor por segundo 
        movimientoVertical.y += factorGravedad * Time.deltaTime;
        controller.Move(movimientoVertical * Time.deltaTime);
    }

    private bool EnSuelo()
    {
        //Tirar una esfera de deteccion en los pies con cierto radio 
       bool resultado = Physics.CheckSphere(pies.position, radioDeteccion , queEsSuelo);
        return resultado;
    }
    //Sinoniomo de oncolli pero para un c.c
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("ParteEnemigo"))
        {
            Vector3 vectorPush = hit.gameObject.transform.position - transform.position;
            hit.gameObject.GetComponent<Rigidbody>().AddForce(vectorPush.normalized *125, ForceMode.Impulse);
        }
    }

    //Metodo que se ejecuta automaticamente para dibujar cualquier figura 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(pies.position, radioDeteccion);

    }
    
}
