using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Pendulo : MonoBehaviour
{

    [SerializeField]
    float angulo;

    [SerializeField]
    float angulo_acumulado;

    [SerializeField]
    bool cambiaSentido;

    [SerializeField]
    float tiempo_trascurrido;

    // Start is called before the first frame update
    void Start()
    {
        cambiaSentido = false;
        angulo = -1;
        angulo_acumulado = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo_trascurrido >= 0.01)
        {
            transform.Rotate(new Vector3(angulo, 0, 0));
            angulo_acumulado += angulo;

            if (angulo_acumulado == -40)
            {
                angulo = 1;
            }
            else if (angulo_acumulado == 40)
            {
                angulo = -1;
            }
            tiempo_trascurrido = 0;
        }
        tiempo_trascurrido += Time.deltaTime;
    }
}
