using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Respawn : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnValue;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (player.transform.position.y < -spawnValue)
        {
            RespawnPoint();
        }
    }
    void RespawnPoint()
    {
        transform.position = spawnPoint.position;
    }
    //
}
