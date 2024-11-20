using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * fuerzaImpulso, ForceMode.Impulse);
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(1,1,1) * Random.Range(0,500) * Time.deltaTime);
    }

    //Se ejecuta automaticamente cuando esta entidad se va a morir
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}
