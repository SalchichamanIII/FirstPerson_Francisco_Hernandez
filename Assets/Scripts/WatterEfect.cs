using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WatterEfect : MonoBehaviour
{
    private Volume volume;
    private LensDistortion distorsionEffect;
    [SerializeField] float velocidad;
    //private ColorAdjustments colorAdjudments;
    // Start is called before the first frame update
    void Start()
    {
        volume = GetComponent<Volume>();
        if(volume.profile.TryGet(out LensDistortion lensDistorsion))
        {
            distorsionEffect = lensDistorsion;
        }
        //if (volume.profile.TryGet(out ColorAdjustments ))
        //{
        //    distorsionEffect = lensDistorsion;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        // Metemos un seno y coseno en el efecto de agua y sumamos 1 para que vaya de 
        //0 a 2 y dividimos entre 2 pata que vaya de 0 a 1 
        FloatParameter ejemplo = new FloatParameter(1 +  Mathf.Sin(velocidad *Time.time) / 2);
        FloatParameter ejemplo2 = new FloatParameter(1 + Mathf.Cos(velocidad * Time.time) /2);
        distorsionEffect.xMultiplier.SetValue(ejemplo);
        distorsionEffect.yMultiplier.SetValue(ejemplo2);
            
    }
}
