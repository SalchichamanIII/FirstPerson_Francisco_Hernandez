using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] protected ParticleSystem system;
    [SerializeField] protected ArmaSO misDatos;
    [SerializeField] protected float tiempoRecarga = 0f;
    protected Camera cam;

    protected float timer;
    protected bool recargando = false;
    protected int balasActualesBolsa;
    protected int balasActualesCargador;

    //[SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioClip disparoClip;

    public int BalasActualesCargador { get => balasActualesCargador;  }
    public int BalasActualesBolsa { get => balasActualesBolsa;  }

    // Start is called before the first frame update
    void Start()
    {
        balasActualesCargador = misDatos.balasMaximasCargadorç;
        balasActualesBolsa = misDatos.balasBolsa;
        cam = Camera.main;
        //Me aseguro que el temporizador empiece desde la cadencia 
        //para que podemos disparar desde el inicio
        timer = misDatos.cadenciaAtaque;

        //if (audioSource == null)
        //{
        //    audioSource = GetComponent<AudioSource>();
        //}

    }

    protected IEnumerator Recargar()
    {
        //    recargando = true;

        //    yield return new WaitForSeconds(tiempoRecarga);


        //    int balasFaltantes = balasActualesCargador - balasActualesBolsa;
        //    if (balasFaltantes < 0)
        //    {
        //        balasActualesCargador += Mathf.Abs(balasFaltantes);
        //        balasActualesBolsa = Mathf.Max(0, balasActualesBolsa - Mathf.Abs(balasFaltantes));
        //    }
        //    else
        //    {
        //        balasActualesCargador = balasActualesBolsa;
        //        balasActualesBolsa = 0;
        //    }

        //    recargando = false;

        //}
        recargando = true;

        yield return new WaitForSeconds(0);

        
        int balasNecesarias = misDatos.balasMaximasCargadorç - balasActualesCargador;

       
        int balasParaRecargar = Mathf.Min(balasNecesarias, balasActualesBolsa);

        
        balasActualesCargador += balasParaRecargar;
        balasActualesBolsa -= balasParaRecargar;

        recargando = false;
    }

}
