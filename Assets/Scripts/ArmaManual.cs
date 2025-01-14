using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : Arma
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip disparoClip;

    // Update is called once per frame
    void Update()
    {
        if (recargando || balasActualesCargador <= 0)  
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && balasActualesCargador < misDatos.balasMaximasCargadorç)
        {
            StartCoroutine(Recargar());
        }

        if (Input.GetMouseButtonDown(0) && balasActualesCargador > 0)
        {
            if (audioSource != null && disparoClip != null)
            {
                audioSource.PlayOneShot(disparoClip);  
            }
            system.Play();
            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    hitInfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);
                }
                
            }

            balasActualesCargador--;
        }
    }
}
