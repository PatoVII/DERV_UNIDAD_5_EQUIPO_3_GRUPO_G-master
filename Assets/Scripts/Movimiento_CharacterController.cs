using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_CharacterController : MonoBehaviour
{
    //Check in CC: 
    //skin_width = configurable
    //min move distance = 0

    [SerializeField]
    CharacterController cc;

    [SerializeField] float velocidad; //velocidad de movimiento
        
    [SerializeField] Vector3 velocidadCaida; //velocidad de caida
    [SerializeField] float gravedad = 9.81f; //valor por defecto
    [SerializeField] float alto_salto = 5f; //valor por defecto
    public bool enPiso;

    public bool enPendiente;
    public Vector3 vectorNormal;
    public float velocidadDeslizamiento;
    public float fuerzaEmpuje;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        enPiso = cc.isGrounded; //This give better results here

        
        if (enPiso && velocidadCaida.y < 0)
        {
            velocidadCaida.y = 0f; //Segun algunos autores : -2f
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        /*
         * Esto funciona solo cuando el gameobject no rota
         * En este sentido, al requerirse que el jugador rote, el codigo no es funcional, debido a que 
         * el frente (forward) del objeto cambia en tiempo de ejecucion
         * 
        horizontal = horizontal * velocidad * Time.deltaTime;
        vertical = vertical * velocidad * Time.deltaTime;
        Vector3 v_movimiento_personaje = new Vector3(horizontal, 0, vertical);
        */

        Vector3 v_movimiento_personaje = transform.right * horizontal + transform.forward * vertical;
        ///////////////////////////////////////////////////////////////////////////                      
        ///Para limitar la velocidad en diagonal!   
        v_movimiento_personaje = Vector3.ClampMagnitude(v_movimiento_personaje, 1.0f);
        ///////////////////////////////////////////////////////////////////////////                
        v_movimiento_personaje *= velocidad;
        ///////////////////////////////////////////////////////////////////////////
        float angulo = Vector3.Angle(Vector3.up, vectorNormal);
        Debug.Log(angulo);
        enPendiente = angulo >= cc.slopeLimit && angulo<=89;
        if (enPendiente)
        {
            v_movimiento_personaje.x += ((1f - vectorNormal.y) * vectorNormal.x) * velocidadDeslizamiento;
            v_movimiento_personaje.z += ((1f - vectorNormal.y) * vectorNormal.z) * velocidadDeslizamiento;

            velocidadCaida.y += fuerzaEmpuje;
        }
        ///////////////////////////////////////////////////////////////////////////                
        v_movimiento_personaje *= Time.deltaTime;
        cc.Move(v_movimiento_personaje);

        if (Input.GetButtonDown("Jump") && enPiso)
        {
            //if (Input.GetKeyDown(KeyCode.Space) && enPiso)
            //if (Input.GetKeyDown(KeyCode.J) && enPiso)

            velocidadCaida.y = alto_salto;
        }


       

        velocidadCaida.y += -gravedad * Time.deltaTime;
        cc.Move(velocidadCaida * Time.deltaTime);

    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        vectorNormal = hit.normal;

        string name = hit.collider.gameObject.name;
        Debug.Log(name);

        if (name.Equals("Plataforma"))
        {
            transform.SetParent(hit.collider.transform);
        }
        else {
            transform.SetParent(null);
        }
    }

}
