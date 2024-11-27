using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    private Camera cam;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        //Me aseguro que el temporizador empiece desde la cadencia 
        //para que podemos disparar desde el inicio
        timer = misDatos.cadenciaAtaque;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Si mantengo pulsado clk izq  y el timer supera o iguala cadenciaAtaque...
        if (Input.GetMouseButton(0) && timer >= misDatos.cadenciaAtaque)
        {
            //Puedodisparar
            system.Play();//Ejecuto sistema de particulas
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.TryGetComponent(out ParteDeEnemigo scriptEnemigo))
                {
                    scriptEnemigo.RecibirDanho(misDatos.danhoAtaque);
                }

            }
            timer = 0; //Reinicio el timer para posteerioired disparos
        }
    }
    
}
