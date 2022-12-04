using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Plataformas : MonoBehaviour
{

    [SerializeField]
    float velocidad;

    [SerializeField]
    List<Transform> puntos;

    [SerializeField]
    int punto_destino_p1;
    [SerializeField]
    int punto_destino_p2;
    [SerializeField]
    int punto_destino_p3;

    [SerializeField]
    Transform plataforma1;
    [SerializeField]
    Transform plataforma2;
    [SerializeField]
    Transform plataforma3;

    // Start is called before the first frame update
    void Start()
    {
        velocidad = 5f;

        punto_destino_p3 = 3;
        punto_destino_p2 = 2;
        punto_destino_p1 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        plataforma3.position = Vector3.MoveTowards((plataforma3.position), puntos[punto_destino_p3].position, velocidad * Time.deltaTime);

        if (Vector3.Distance(plataforma3.position, puntos[punto_destino_p3].position) <= 0.1)
        {
            punto_destino_p3 = ++punto_destino_p3 % puntos.Count;
        }

        //////////////////////////////////////////////////////////////////////

        plataforma2.position = Vector3.MoveTowards((plataforma2.position), puntos[punto_destino_p2].position, velocidad * Time.deltaTime);

        if (Vector3.Distance(plataforma2.position, puntos[punto_destino_p2].position) <= 0.1)
        {
            punto_destino_p2 = ++punto_destino_p2 % puntos.Count;
        }

        //////////////////////////////////////////////////////////////////////

        plataforma1.position = Vector3.MoveTowards((plataforma1.position), puntos[punto_destino_p1].position, velocidad * Time.deltaTime);

        if (Vector3.Distance(plataforma1.position, puntos[punto_destino_p1].position) <= 0.1)
        {
            punto_destino_p1 = ++punto_destino_p1 % puntos.Count;
        }
    }
}
