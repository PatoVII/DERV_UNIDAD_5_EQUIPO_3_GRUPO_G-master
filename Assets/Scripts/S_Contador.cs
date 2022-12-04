using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_Contador : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI txtTiempo;

    [SerializeField]
    TextMeshProUGUI txtCaidas;

    [SerializeField]
    TextMeshProUGUI txtVida;

    [SerializeField] 
    GameObject player;

    [SerializeField] 
    float spawnValue;

    public int caidas = 0;
    public int vida = 5;
    public static S_Contador contador;
    public float tiempo = 60;

    void Update()
    {
        if (player.transform.position.y < -spawnValue)
        {
            contador.caidas++;
            txtCaidas.text = contador.caidas.ToString();

            contador.vida--;
            txtVida.text = contador.vida.ToString();
     
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

        GameObject objCaidas = GameObject.Find("txt_caidas");
        txtCaidas = objCaidas.GetComponent<TextMeshProUGUI>();

        GameObject objVida = GameObject.Find("txt_vidas");
        txtVida = objVida.GetComponent<TextMeshProUGUI>();
        
        GameObject objTiempo = GameObject.Find("txt_tiempo");
        txtTiempo = objTiempo.GetComponent<TextMeshProUGUI>();

    }
    private void Start()
    {
        StopAllCoroutines();
        StartCoroutine("Reloj");
    }

    IEnumerator Reloj()
    {
        while (contador.tiempo >= 0)
        {
            txtTiempo.text = contador.tiempo.ToString();
            contador.tiempo--;
            
            if(contador.vida == 0)
            {
                contador.tiempo = 60;
                contador.vida = 5;
                txtVida.text = contador.vida.ToString();
            }
            if (contador.tiempo == 0)
            {
                contador.vida--;
                txtVida.text = contador.vida.ToString();
            }

            yield return new WaitForSeconds(1f);
        }
    }


}
