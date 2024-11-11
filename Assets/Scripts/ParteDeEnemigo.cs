using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParteDeEnemigo : MonoBehaviour
{
    [SerializeField] private Pedro mainScript;
    [SerializeField] private float multiplicadorDanho;
    public void RecibirDanho(float danhoRecibido)
    {
        mainScript.Vidas -= danhoRecibido * multiplicadorDanho;

        if (mainScript.Vidas <= 0)
        {
            mainScript.Morir();
            //if (this.gameObject.name == "LeftUpLeg")
            //{
            //    NavMeshAgent.
            //}
        }
    }
}
