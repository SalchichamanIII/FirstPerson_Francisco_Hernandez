using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;
using UnityEngine.Video;

public class Pedro : MonoBehaviour

{
    [SerializeField] private float vidas;
    [SerializeField] private float danhoEnemigo;
    
   [SerializeField] private Transform attackPoint;
    [SerializeField] private float radioAtaque;
    [SerializeField] private LayerMask queEsDanhable;
   
    private NavMeshAgent agent;
    private Animator anim;
    private FirstPerson player;
    private bool ventanaAbierta;
    private bool puedoDanhar = true;
    Rigidbody[] huesos;

    public float Vidas { get => vidas; set => vidas = value; }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindObjectOfType<FirstPerson>();

        huesos = GetComponentsInChildren<Rigidbody>();

        CambiarEstadoHuesos(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            Perseguir();
        }
        
        if(ventanaAbierta && puedoDanhar)
        {
            DetectarImpacto();
        }
        
    }

    private void DetectarImpacto()
    {
       Collider[] collsDetectados = Physics.OverlapSphere(attackPoint.position, radioAtaque, queEsDanhable);
       
        //Si hemos detectado algo en nuestro "Radar" (OverlapSphere)
        if(collsDetectados.Length > 0)
        {
          for(int i = 0; i < collsDetectados.Length; i++)
            {
                collsDetectados[i].GetComponent<FirstPerson>().RecibirDanho(danhoEnemigo);
            }
          puedoDanhar=false;
        }
    }

    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);
        //Si el enemigo esta a distancia de ataque de ti
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            //Lanza animacion de ataque
            agent.isStopped = true;//Me paro
            anim.SetBool("attacking", true);//Lanzo ataque
            EnfocarObjetivo();
        }
    }
    private void EnfocarObjetivo()
    {
        //1.Calculo vector unitario que mira hacia el player  desde nuestra posicion
        Vector3 direccionAObjetivo = player.transform.position - transform.position;

        //1.5 Modifico la y del vector para prevenir que el enemigo se tumbe
        direccionAObjetivo.y = 0;

        //2. Calculo la rotacion para conseguir dicha direccion
        Quaternion rotacionAObjetivo = Quaternion.LookRotation(direccionAObjetivo);

        transform.rotation = rotacionAObjetivo;
    }

    private void FinAtaque()
    {
        agent.isStopped = false;//Sigo moviendome
        anim.SetBool("attacking", false);//Dejo atacar
        puedoDanhar = true;
    }

    private void CambiarEstadoHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
    
    private void AbrirVentana()
    {
        ventanaAbierta = true;
    }

    private void CerrarVentanaAtaque()
    {
        ventanaAbierta |= false;
    }

    public void Morir()
    {
        CambiarEstadoHuesos(false);
        anim.enabled = false;
        agent.enabled = false ;
        Destroy(gameObject, 15);
    }
}
