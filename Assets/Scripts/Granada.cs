using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float fuerzaImpulso;
    [SerializeField] private float radioExplosion;
    [SerializeField] private GameObject explosion;
    [SerializeField] private LayerMask queEsExplotable;

    private Collider[] buffer = new Collider[100];
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
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    //Se ejecuta automaticamente cuando esta entidad se va a morir
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        //Si este if se cumple la granada ha detectado al menos un collider en la capa que es explotable
        int numerosDetectados = Physics.OverlapSphereNonAlloc(transform.position, radioExplosion, buffer, queEsExplotable);
        
          if(numerosDetectados > 0)
        {
            //Recorrer todos los cols detectados
            for(int i = 0; i < numerosDetectados; i++)
            {
                //Y por cada col detectado (HUESOS) voy a coger el script de cada uno
                if(buffer[i].TryGetComponent(out ParteDeEnemigo scriptHueso))
                {
                    scriptHueso.Explotar();
                }
            }
        }
        
    }
}
