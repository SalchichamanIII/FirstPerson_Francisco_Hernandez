using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawneador : MonoBehaviour
{
    [SerializeField]  private GameObject enemigoPrefab;
    [SerializeField] private Transform[] puntosSpawn;
    // Start is called before the first frame update
    void Start()
    {
        //sacar una copia del prefab del enemigo en una posicion
        //Quaternion.identity: Rotacion(0,0,0)
        StartCoroutine(Spawnear());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Spawnear()
    {
        while (true)
        {
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
    }
}
