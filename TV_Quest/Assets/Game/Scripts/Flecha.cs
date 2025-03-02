using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    public SpawnManager spawnManager;

    void Update()
    {
        if (GlobalVars.Instance.gameType != "Training")
        {
            if (spawnManager.currentCancha == 1)
            {
                transform.SetPositionAndRotation(new Vector3(-0.08f, 1.16f, 0), Quaternion.identity);
                Vector3 newRotation = transform.localEulerAngles;
                newRotation.x = -74.093f;
                newRotation.y = -90;
                transform.localEulerAngles = newRotation;
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3(0.08f, 1.16f, 0), Quaternion.identity);
                Vector3 newRotation = transform.localEulerAngles;
                newRotation.x = -74.093f;
                newRotation.y = -270;
                transform.localEulerAngles = newRotation;
            }
        }
        else
        {
            if (spawnManager.currentCancha == 1)
            {
                transform.SetPositionAndRotation(new Vector3(-0.08f, 1.16f, 0), Quaternion.identity);
                Vector3 newRotation = transform.localEulerAngles;
                newRotation.x = -74.093f;
                newRotation.y = -90;
                transform.localEulerAngles = newRotation;
            }
            else
            {
                transform.SetPositionAndRotation(new Vector3(0.08f, 1.16f, 0), Quaternion.identity);
                Vector3 newRotation = transform.localEulerAngles;
                newRotation.x = -74.093f;
                newRotation.y = -270;
                transform.localEulerAngles = newRotation;
            }
        }
         
    }
}
