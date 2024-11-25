using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParteDeEnemigo : MonoBehaviour
{
    [SerializeField] private Pedro mainScript;
    [SerializeField] private float multiplicadorDanho;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void RecibirDanho(float danhoRecibido)
    {
        mainScript.Vidas -= danhoRecibido * multiplicadorDanho;

        if (mainScript.Vidas <= 0)
        {
            mainScript.Morir();
            if (this.gameObject.name == "LeftUpLeg")
            {
                mainScript.GetComponent<NavMeshAgent>().speed = 2f;
            }
        }
    }

    public void Explotar(float fuerzaExplosion, Vector3 puntoImpacto , float radioExplosion , float upModifier)
    {
        mainScript.Morir();
        rb.AddExplosionForce(fuerzaExplosion, puntoImpacto, radioExplosion, upModifier, ForceMode.Impulse);
    }
}
