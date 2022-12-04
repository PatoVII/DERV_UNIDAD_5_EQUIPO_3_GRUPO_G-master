using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Rayo : MonoBehaviour
{
    [SerializeField] GameObject jugador;
    RaycastHit hit;
    private int plataformas;

    // Start is called before the first frame update
    void Start()
    {
        plataformas = 1 << 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(jugador.transform.position, Vector3.down, out hit, 10, plataformas)) {
            Debug.Log(hit.transform.name);
        }
    }
}
