using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditosManager : MonoBehaviour
{
    public Communicator communicator;
    public GameObject botonera;
    public Text version;
    public GameObject banners;

    public CreditosItem creditosItem1;
    public CreditosItem creditosItem2;
    public CreditosItem creditosItem3;

    private string facebook;
    private string instagram;
    private string tiktok;
    private string youtube;

    public void SetCreditos()
    {
        //sponsorManager.loadAgras();
        if (GlobalVars.Instance.device == "Android")
        {
            version.text = "TEJO VIRTUAL - v" + GlobalVars.Instance.androidVersion;
        }
        else
        {
            version.text = "TEJO VIRTUAL - v" + GlobalVars.Instance.iosVersion;
        }

        botonera.GetComponent<Animator>().SetBool("enter", true);
        loadAgras();

    }

    public void loadAgras()
    {
        communicator.getAgras();
    }

    public void onAgrasResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON;

        creditosItem1.SetCreditosItem(result[0].GetField("url").str.Replace("|", "/"), GlobalVars.Instance.URL_HOST + "images/agras/" + result[0].GetField("image").str);
        creditosItem2.SetCreditosItem(result[1].GetField("url").str.Replace("|", "/"), GlobalVars.Instance.URL_HOST + "images/agras/" + result[1].GetField("image").str);
        creditosItem3.SetCreditosItem(result[2].GetField("url").str.Replace("|", "/"), GlobalVars.Instance.URL_HOST + "images/agras/" + result[2].GetField("image").str);
        communicator.getRedes();
    }

    public void onRedesResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON;
        facebook = result[0].GetField("link").str.Replace("|", "/");
        instagram = result[1].GetField("link").str.Replace("|", "/");
        tiktok = result[2].GetField("link").str.Replace("|", "/");
        youtube = result[3].GetField("link").str.Replace("|", "/");

        Debug.Log("facebook: " + facebook);
    }

    public void goFacebook() { if (facebook != "") Application.OpenURL(facebook); }
    public void goInstagram() { if (instagram != "") Application.OpenURL(instagram); }
    public void goTiktok() { if (tiktok != "") Application.OpenURL(tiktok); }
    public void goYoutube() { if (youtube != "") Application.OpenURL(youtube); }

}
