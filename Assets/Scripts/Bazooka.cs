using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Arma
{
    [SerializeField] private GameObject granadaPrefab;
    [SerializeField] private Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(granadaPrefab, spawnPoint.position, transform.rotation);
            
        }
    }
}
