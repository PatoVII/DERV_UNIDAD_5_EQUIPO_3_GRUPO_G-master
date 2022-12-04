using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_RigidBody : MonoBehaviour
{
    
    Rigidbody rb;

    Collider coll;

    [SerializeField] float velocidad = 10f;
    [SerializeField] float fuerzaSalto = 10f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask suelo_mask;

    [SerializeField] float altoPersonaje = 2f;
    [SerializeField] float area_deteccion = 0.4f;
    private float largo_rayo_pendiente = 1.2f;


    [SerializeField] bool enSuelo;

    Vector3 v_movimiento_personaje;

    [SerializeField] bool enPendiente;
    RaycastHit hitPendiente;
    Vector3 v_movimiento_personaje_pendiente;


    bool estaEnPendiente() {
        //Debug.DrawRay(groundCheck.position, Vector3.down * largo_rayo_pendiente, Color.red);
                
        if (Physics.Raycast(transform.position, Vector3.down, out hitPendiente, altoPersonaje / 2 + largo_rayo_pendiente))
        {            
            float angulo = Vector3.Angle(Vector3.up, hitPendiente.normal);
            Debug.Log(angulo);

            if (angulo > 45)
            {
                coll.material.dynamicFriction = 0;
                coll.material.staticFriction = 0;

                rb.AddForce(Vector3.down * 3f, ForceMode.Acceleration);
            }
            else {
                coll.material.dynamicFriction = 10;
                coll.material.staticFriction = 10;
            }
            

            return (hitPendiente.normal != Vector3.up);
        }
        return false;        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        v_movimiento_personaje = transform.right * horizontal + transform.forward * vertical;        
                       
        //Debug.DrawRay(transform.position, Vector3.down * (altoPersonaje/2+area_deteccion), Color.red);
        //enSuelo = Physics.Raycast(transform.position, Vector3.down, altoPersonaje / 2 + area_deteccion);
        
        enSuelo = Physics.CheckSphere(groundCheck.position,area_deteccion, suelo_mask);


        if (Input.GetButtonDown("Jump") && enSuelo) 
        {
            if (enSuelo)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            }            
        }

        //ajusta drag
        if (enSuelo)
        {
            rb.drag = 6f;
        }
        else {
            rb.drag = 0f;
        }
        ////////////////////

        enPendiente = estaEnPendiente();
        v_movimiento_personaje_pendiente = Vector3.ProjectOnPlane(v_movimiento_personaje, hitPendiente.normal);
        

    }

    private void FixedUpdate()
    {
        ///////////////////////////////////////////////////////////////////////////                      
        ///Para limitar la velocidad en diagonal!   
        //v_movimiento_personaje = Vector3.ClampMagnitude(v_movimiento_personaje, 1.0f);
        ///////////////////////////////////////////////////////////////////////////
        //v_movimiento_personaje *= velocidad * 10f; //10 = constante
        //rb.AddForce(v_movimiento_personaje, ForceMode.Acceleration);

        if (enSuelo && !enPendiente)
        {
            rb.AddForce(v_movimiento_personaje.normalized * velocidad * 10f, ForceMode.Acceleration);
        }
        else if (enSuelo && enPendiente) {
            rb.AddForce(v_movimiento_personaje_pendiente.normalized * velocidad * 10f, ForceMode.Acceleration);
        }
        else if(!enSuelo){
            rb.AddForce(v_movimiento_personaje.normalized * velocidad * 10f * 0.1f, ForceMode.Acceleration);
        }
        

        // Debug.Log(v_movimiento_personaje);

    }

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        Debug.Log(name);

        if (name.Equals("Plataforma"))
        {
            rb.interpolation = RigidbodyInterpolation.None;
            transform.SetParent(collision.collider.transform);
            
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        string name = collision.gameObject.name;
        Debug.Log(name);

        if (name.Equals("Plataforma"))
        {
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            transform.transform.SetParent(null);
        }
    }


    private void OnDrawGizmos()
    {
        //Dibuja el area de deteccion con el suelo:
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, area_deteccion);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(groundCheck.position, Vector3.down * largo_rayo_pendiente);
    }
}
