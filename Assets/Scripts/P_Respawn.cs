using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_Respawn : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;

    int scene = 2;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (S_Contador.contador.vida > 0)
        {
            if (player.transform.position.y < -spawnValue)
            {
                RespawnPoint();
            }
        }
        else
        {
            loadscene(scene);
        }
    }
    void RespawnPoint()
    {
        transform.position = spawnPoint.position;
    }

    private void loadscene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
