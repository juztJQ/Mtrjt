using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UI;

public class AS : TejoScene
{
    public ADmob oADmob;
    public SplashScreen_UIManager uiManager;
    public Communicator communicatorManager;
    public GameObject connecting;
    public SponsorManager sponsorManager;
    public Text version;

    private string serverVersion;
    private string forceupdateAndroid;
    private string forceupdateIOS;

    public void Start()
    {
        CheckInternet();
        oADmob.Init();
    }

    public void Update()
    {
        if (GlobalVars.Instance.device == "Android")
        {
            version.text = "v" + GlobalVars.Instance.androidVersion;
        }
        else
        {
            version.text = "v" + GlobalVars.Instance.iosVersion;
        }

    }

    public void onAppear()
    {
        if (InternetOn())
        {
            GlobalVars.Instance.isBack = false;
            StartCoroutine(waitLogo());
        }
    }

    IEnumerator waitLogo()
    {
        yield return new WaitForSeconds(2.0f);
        connecting.SetActive(true);
        communicatorManager.LoadConfig();
    }

    public void onCommunicatorResult(JSONObject dataJSON)
    {
        JSONObject result   = dataJSON[0];
        forceupdateAndroid  = result.GetField("forceupdateAndroid").str;
        forceupdateIOS      = result.GetField("forceupdateIOS").str;


        if (GlobalVars.Instance.device == "Android")
        {
            serverVersion = result.GetField("android").str;
            if ((GlobalVars.Instance.androidVersion != serverVersion) && (forceupdateAndroid == "1"))
            {
                errorMessage.SetErrorURL("Nueva versión!", "Sumercé, hay una nueva \n versión del juego! \n Tocó descargarla!", "Descargar", GlobalVars.Instance.store_android);
            }
            else
            {
                sponsorManager.loadSponsor("BigIntro");
                StartCoroutine(waitSponsor());
            }
        }
        else
        {
            serverVersion = result.GetField("ios").str;
            if ((GlobalVars.Instance.iosVersion != serverVersion) && (forceupdateIOS == "1"))
            {
                errorMessage.SetErrorURL("Nueva versión!", "Sumercé, hay una nueva \n versión del juego! \n Tocó descargarla!", "Descargar", GlobalVars.Instance.store_ios);
            }
            else
            {
                sponsorManager.loadSponsor("BigIntro");
                StartCoroutine(waitSponsor());
            }
        }
        connecting.SetActive(false);
    }

    IEnumerator waitSponsor()
    {
        yield return new WaitForSeconds(3.0f);
        goEntrada();
    }

    public void goEntrada()
    {
        navigationManager.goEntrada();
    }

}
