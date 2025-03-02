using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMouse : MonoBehaviour
{
    public SpawnManager spawnManager;
    public bool checking = false;
    private bool is2Player = false;
    private float Xo;
    private float Xi;

    private float Yo;
    private float Yi;


    void Update()
    {
        if (checking && spawnManager.canLaunch)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Xi = Input.mousePosition.x;
                Yi = Input.mousePosition.y;
                spawnManager.LanzaTejo(Xo, Xi, Yo, Yi, is2Player);
                spawnManager.flecha.SetActive(false);
            }
        }            
    }

    public void SetChecking(float _Xo, float _Yo, bool _is2Player = false)
    {
        is2Player = _is2Player;
        Xo = _Xo;
        Yo = _Yo;
        checking = true;
    }
}
