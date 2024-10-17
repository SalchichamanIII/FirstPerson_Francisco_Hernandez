using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento; 

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
       float h = Input.GetAxisRaw("Horizontal"); //h=0 , h=-1, h=1
       float v= Input.GetAxisRaw("Vertical");
        Vector3 movimiento = new Vector3(h, 0, v).normalized;
        float anguloRotacion = Camera.main.transform.eulerAngles.y;
        controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
    }
}
