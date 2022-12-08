using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ganaste : MonoBehaviour
{
    public GameObject UIPanel;
    public GameObject VictoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIPanel.SetActive(false);
            VictoryPanel.SetActive(true);
        }
    }
}
