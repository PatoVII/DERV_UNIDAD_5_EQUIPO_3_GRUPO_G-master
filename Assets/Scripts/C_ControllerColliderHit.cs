using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_ControllerColliderHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        string name = hit.collider.name;
        string tag = hit.collider.tag;

        Debug.Log("Name: " + name + " Tag: " + tag);

        //Ejemplo para empujar objetos
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null)
        {
            Vector3 direccionFuerza = hit.gameObject.transform.position - transform.position;
            direccionFuerza.y = 0; //para no afectar al vector y
            direccionFuerza.Normalize(); //Normaliza al vector para hacer que se encuentre dentro del intervalo valido

            float fuerza_aplicada = 2;
            rb.AddForceAtPosition(direccionFuerza * fuerza_aplicada, transform.position, ForceMode.Impulse);

        }

    }
}
