using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_Impulse : MonoBehaviour
{
    [SerializeField]
    public Rigidbody rb;

    [SerializeField]
    float velocidad;

    [SerializeField] 
    GameObject player;

    float empuje = 546;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionStay(Collision collision) {

        if (collision.gameObject.tag == "Pendulo")
        {

            rb = GetComponent<Rigidbody>();
            if (player.transform.position.x < empuje)
            {

                rb.AddForce(Vector3.right * velocidad, ForceMode.Impulse); //derecha

            }
            else
            {
                rb.AddForce(Vector3.left * velocidad, ForceMode.Impulse); //Izquierda
            }
        }
    }
}
