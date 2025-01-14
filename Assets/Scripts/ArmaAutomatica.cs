using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : Arma
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip disparoClip;
    // Update is called once per frame
    void Update()
    {
        if (recargando)
        {
            
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R) && balasActualesCargador < misDatos.balasMaximasCargadorç)
        {
            StartCoroutine(Recargar());
        }

        //Si mantengo pulsado clk izq  y el timer supera o iguala cadenciaAtaque...
        if (Input.GetMouseButton(0) && timer >= misDatos.cadenciaAtaque && balasActualesCargador > 0)
        {

            if (audioSource != null && disparoClip != null)
            {
                audioSource.PlayOneShot(disparoClip);
            }
            //Puedodisparar
            system.Play();//Ejecuto sistema de particulas
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.TryGetComponent(out ParteDeEnemigo scriptEnemigo))
                {
                    scriptEnemigo.RecibirDanho(misDatos.danhoAtaque);
                }

            }
            balasActualesCargador--;
            timer = 0; 
        }


    }

}
