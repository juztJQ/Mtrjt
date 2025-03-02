using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SponsorManager : MonoBehaviour
{
    public Communicator communicator;
    public GameObject sponsor;
    public GameObject sponsor2;
    public GameObject bigBanner;
    public AS ASManager;
    public Text agradecimiento1;
    public Text agradecimiento2;
    public Text agradecimiento3;
    public Text agradecimiento4;
    public Text agradecimiento5;
    public Text agradecimiento6;
    private string url_logo;
    private string url_credits;
    private string url_big;
    public string output_url;
    private Texture myTexture;
    private string type = "3D";

    public void loadAgras()
    {
        communicator.getAgras();
    }

    public void onAgrasResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON;
        if (result.Count >= 1) agradecimiento1.text = result[0].GetField("nombre").str;
        if (result.Count >= 2) agradecimiento2.text = result[1].GetField("nombre").str;
        if (result.Count >= 3) agradecimiento3.text = result[2].GetField("nombre").str;
        if (result.Count >= 4) agradecimiento4.text = result[3].GetField("nombre").str;
        if (result.Count >= 5) agradecimiento5.text = result[4].GetField("nombre").str;
        if (result.Count >= 6) agradecimiento6.text = result[5].GetField("nombre").str;
        setLoadBigBanner();
    }

    public void loadSponsor(string type="3D")
    {
        this.type = type;
        communicator.getSponsor();
    }

    public void setLoadBigBanner()
    {
        StartCoroutine(LoadBigBanner());
    }

    public void onCommunicatorResult(JSONObject dataJSON)
    {
        try
        {
            JSONObject result = dataJSON[0];
            url_logo = result.GetField("url_logo").str;
            url_credits = result.GetField("url_credits").str;
            url_big = result.GetField("url_big").str;
            output_url = result.GetField("output_url").str;

            if (this.type == "3D")
            {
                StartCoroutine(GetTexture());
            }
            else if (this.type == "BigIntro")
            {
                if (url_big != "")
                {
                    StartCoroutine(LoadBigIntro());
                }
                else
                {
                    ASManager.goEntrada();
                }
            }
            else
            {
                StartCoroutine(LoadImage());
            }
        }
        catch { }
    }

    IEnumerator LoadImage()
    {
        Debug.Log(GlobalVars.Instance.URL_HOST + "content/" + url_credits);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(GlobalVars.Instance.URL_HOST + "content/" + url_credits);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            sponsor.SetActive(true);
            sponsor.GetComponent<Image>().sprite = webSprite;
        }
    }

    IEnumerator LoadBigIntro()
    {
        Debug.Log(GlobalVars.Instance.URL_HOST + "content/" + url_big);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(GlobalVars.Instance.URL_HOST + "content/" + url_big);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            sponsor.SetActive(true);
            sponsor.GetComponent<Image>().sprite = webSprite;
        }
    }

    IEnumerator LoadBigBanner()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(GlobalVars.Instance.URL_HOST + "content/banner_inApp.png");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            bigBanner.SetActive(true);
            bigBanner.GetComponent<Image>().sprite = webSprite;
            loadSponsor("2D");
        }
    }


    Sprite SpriteFromTexture2D(Texture2D texture)
    {

        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    IEnumerator GetTexture()
    {
        Debug.Log("Loading Sponsor: "+ GlobalVars.Instance.URL_HOST + "content/" + url_logo);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(GlobalVars.Instance.URL_HOST+"content/"+ url_logo);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            sponsor.GetComponent<Renderer>().material.mainTexture = myTexture;
            sponsor.SetActive(true);
            sponsor2.GetComponent<Renderer>().material.mainTexture = myTexture;
            sponsor2.SetActive(true);
        }
    }
}
