using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Boton : MonoBehaviour
{
    
    public void CargarJuego()
    {
        SceneManager.LoadScene(1);
    }
    public void Pantallafinal()
    {
        SceneManager.LoadScene(1);
    }
    public void PantallaInicial()
    {
        SceneManager.LoadScene(0);
    }

}
