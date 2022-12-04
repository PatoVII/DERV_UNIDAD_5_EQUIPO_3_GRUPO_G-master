using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MovBarreras : MonoBehaviour
{
    [SerializeField]
    List<Transform> puntos;

    [SerializeField]
    int indx_punto_destino;//indice del punto desino actual

    // Start is called before the first frame update
    void Start()
    {
        indx_punto_destino = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards((transform.position),puntos[indx_punto_destino].position,0.1f);

        if (Vector3.Distance(transform.position, puntos[indx_punto_destino].position) <= 0.1)
        {
            indx_punto_destino = ++indx_punto_destino % puntos.Count;
        }
    }
}
