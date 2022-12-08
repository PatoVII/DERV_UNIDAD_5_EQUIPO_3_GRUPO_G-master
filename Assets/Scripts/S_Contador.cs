using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.PlayerLoop;

public class S_Contador : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI txtTiempo;

    [SerializeField]
    TextMeshProUGUI txtVida;

    [SerializeField] 
    GameObject player;

    [SerializeField] 
    float spawnValue;

    public int vida = 5;
    public static S_Contador contador;
    public float tiempo = 60;

    public GameObject ganaste;
    public bool fin;

    IEnumerator corrutine;

    void Update()
    {
        if (player.transform.position.y < -spawnValue)
        {
            contador.vida--;
            txtVida.text = contador.vida.ToString();     
        }

        if (ganaste.activeSelf)
        {
            fin = true;
            StopCoroutine(corrutine);
        }
    }

    private void Awake()
    {
        if (contador == null)
        {
            contador = this;
        }
        else
        {
            Destroy(this);
        }

        GameObject objVida = GameObject.Find("txt_vidas");
        txtVida = objVida.GetComponent<TextMeshProUGUI>();
        
        GameObject objTiempo = GameObject.Find("txt_tiempo");
        txtTiempo = objTiempo.GetComponent<TextMeshProUGUI>();

        corrutine = Reloj();

    }
    private void Start()
    {
        StopAllCoroutines();
        StartCoroutine(corrutine);
    }

    

    IEnumerator Reloj()
    {
        while (contador.tiempo >= 0 && !contador.fin)
        {
            txtTiempo.text = contador.tiempo.ToString();
            contador.tiempo--;
            
            if (contador.tiempo == 0)
            {
                contador.vida--;
                txtVida.text = contador.vida.ToString();
            }

            yield return new WaitForSeconds(1f);
        }

    }

    
        


}
