using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float smoothTime;
    private float velocidadRotacion;

    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
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
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
        
       
        // Si el jugador tocla teclas
        if (input.magnitude > 0)
        {
            //Calculo el angulo al que tengo que rotarme en funcion de los inputs y camara.
            float angulo = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, angulo, ref velocidadRotacion, smoothTime);
            transform.eulerAngles = new Vector3(0, anguloSuave, 0);
            //Mi movimiento tambien ha quedado rotado en base al angulo calculado.
            Vector3 movimiento = Quaternion.Euler(0, angulo, 0) * Vector3.forward;

            controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
        }






    }
}
