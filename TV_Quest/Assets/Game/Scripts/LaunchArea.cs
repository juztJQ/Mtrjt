using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArea : MonoBehaviour
{
    public SpawnManager spawnManager;
    public string gameType = "Game";

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameType == "Game")
        {
            if (spawnManager.currentCancha == 1)
            {
                transform.SetPositionAndRotation(new Vector3(-5, 0.1f, 0), Quaternion.identity);
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3(8, 0.1f, 0), Quaternion.identity);
            }
        }
        else
        {
            transform.SetPositionAndRotation(new Vector3(-5, 0.1f, 0), Quaternion.identity);
        }
        
    }
}
