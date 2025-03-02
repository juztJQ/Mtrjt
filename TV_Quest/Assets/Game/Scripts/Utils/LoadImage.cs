using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadImage : MonoBehaviour
{
    public AvatarWeb avatarWeb;
    public AssetBox assetBox;
    public int numBackground;
    private string url;
    private BackgroundManager backgroundManager;

    public void Start()
    {
        backgroundManager = FindObjectOfType<BackgroundManager>();
    }

    // ----------------------------- AVATAR ------------------------------//

    public void setLoadImage(string _url)
    {
        url = _url;
        Debug.Log("Loading: " + url);
        StartCoroutine(LoadImageGameObject());
    }

    IEnumerator LoadImageGameObject()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) { Debug.Log(www.error); }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            GetComponent<Image>().sprite = webSprite;
            avatarWeb.loaded++;
        }
    }

    // ----------------------------- ASSET ------------------------------//

    public void setLoadAsset(string _url)
    {
        url = _url;
        Debug.Log("Loading: " + url);
        StartCoroutine(LoadAsset());
    }

    IEnumerator LoadAsset()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) { Debug.Log(www.error); }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            GetComponent<Image>().sprite = webSprite;
            assetBox.OnAssetLoaded();
        }
    }

    // ----------------------------- BACKGROUND ------------------------------//

    public void setLoadBackground(string _url)
    {
        Debug.Log("Loading Background: " + _url);
        url = _url;
        StartCoroutine(LoadBackground());
    }

    IEnumerator LoadBackground()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) { Debug.Log(www.error); }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            GetComponent<Image>().sprite = webSprite;
            backgroundManager.OnBackLoaded(numBackground);
        }
    }

    public void OnAnimated()
    {
        backgroundManager.OnAnimated();
    }

    // ----------------------------- CREDIT ------------------------------//

    public void setLoadCredit(string _url)
    {
        Debug.Log("Loading Credit: " + _url);
        url = _url;
        StartCoroutine(LoadCredit());
    }

    IEnumerator LoadCredit()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) { Debug.Log(www.error); }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            GetComponent<Image>().sprite = webSprite;
        }
    }

    // ----------------------------- EFFECTS ------------------------------//

    Sprite SpriteFromTexture2D(Texture2D texture) { return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f); }

    public void SetBlack()
    {
        var tempColor = this.GetComponent<Image>().color;
        tempColor.r = 0.2f;
        tempColor.g = 0.2f;
        tempColor.b = 0.2f;
        this.GetComponent<Image>().color = tempColor;
    }

    public void SetNormal()
    {
        var tempColor = this.GetComponent<Image>().color;
        tempColor.r = 1;
        tempColor.g = 1;
        tempColor.b = 1;
        this.GetComponent<Image>().color = tempColor;
    }
}
