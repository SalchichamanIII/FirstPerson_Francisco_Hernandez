using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    [SerializeField] private float distanciainteraccion;
    private Camera cam;
    private Transform interactuableAcual;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        DeteccionInteractuable();
              
    }

    
    private void DeteccionInteractuable()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, distanciainteraccion))
        {
            if (hitInfo.transform.TryGetComponent(out AmmoBox script))
            {
                interactuableAcual = script.transform;
                interactuableAcual.GetComponent<Outline>().enabled = true;

                if(Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("hOLA");
                    script.AbrirCaja();
                }
            }

        }
        else if (interactuableAcual != null)
        {
            interactuableAcual.GetComponent<Outline>().enabled = false;
            interactuableAcual = null;
        }
    }
}
