using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HacerHijo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            gameObject.transform.SetParent(collision.transform, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        gameObject.transform.SetParent(null);
    }
}
