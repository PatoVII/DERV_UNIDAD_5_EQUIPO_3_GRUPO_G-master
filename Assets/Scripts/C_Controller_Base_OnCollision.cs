using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Controller_Base_OnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Mano Entra en colision con: " + collision.gameObject.name);
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Mano Permanece en colision con: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Mano Sale de colision  con: " + collision.gameObject.name);
    }


}
