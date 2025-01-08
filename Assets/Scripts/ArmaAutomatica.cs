using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private float tiempoRecarga = 2f;
    private Camera cam;

    private float timer;
    private bool recargando = false;
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
        if (recargando)
        {
            
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R) && misDatos.balasCargador < misDatos.balasBolsa)
        {
            StartCoroutine(Recargar());
        }

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
            misDatos.balasCargador--;
            timer = 0; 
        }


    }
    private IEnumerator Recargar()
    {
        recargando = true;
        
        yield return new WaitForSeconds(tiempoRecarga);

        
        int balasFaltantes = misDatos.balasCargador - misDatos.balasBolsa;
        if (balasFaltantes < 0)
        {
            misDatos.balasCargador += Mathf.Abs(balasFaltantes);
            misDatos.balasBolsa = Mathf.Max(0, misDatos.balasBolsa - Mathf.Abs(balasFaltantes));
        }
        else
        {
            misDatos.balasCargador = misDatos.balasBolsa;
            misDatos.balasBolsa = 0;
        }

        recargando = false; 

    }

}
