using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Entrada_UIManager uiManager;

    public LoadImage back_01;
    public LoadImage back_02;
    public LoadImage back_03;

    private bool loaded_01 = false;
    private bool loaded_02 = false;
    private bool loaded_03 = false;

    private bool done = false;
    
    public void Start()
    {
        
    }

    private void Update()
    {
        if(loaded_01 & loaded_02 & loaded_03 & !done)
        {
            uiManager.GoBackgrounds();
            done = true;
        }
    }

    public void SetLoadBack()
    {
        back_01.setLoadBackground(GlobalVars.Instance.URL_HOST + "services/admin/img/backgrounds/back01.png");
        back_02.setLoadBackground(GlobalVars.Instance.URL_HOST + "services/admin/img/backgrounds/back02.png");
        back_03.setLoadBackground(GlobalVars.Instance.URL_HOST + "services/admin/img/backgrounds/back03.png");
    }

    public void OnBackLoaded(int numBack)
    {
        switch (numBack)
        {
            case 1: loaded_01 = true; break;
            case 2: loaded_02 = true; break;
            case 3: loaded_03 = true; break;
        }
    }

    public void OnAnimated()
    {
        uiManager.CheckJump();
    }
}
