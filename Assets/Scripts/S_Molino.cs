using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Molino : MonoBehaviour
{
    [SerializeField]
    float angulo;

    [SerializeField]
    float tiempo_rotacion;
    // Start is called before the first frame update
    void Start()
    {
        angulo = 0;
        StartCoroutine("Molino_Movimiento");
        tiempo_rotacion = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {



    }

    IEnumerator Molino_Movimiento()
    {
        while (true)
        {
            Quaternion destino = Quaternion.Euler(new Vector3(0, angulo, 0));

            transform.rotation = destino;
            angulo++;

            if (angulo == 360)
            {
                angulo = 1;
            }
            yield return new WaitForSeconds(tiempo_rotacion);

        }
    }
}
