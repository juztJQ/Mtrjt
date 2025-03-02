using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PopupPromo : MonoBehaviour
{
    private string image_url;
    private string url;
    private string promoType;
    private Texture myTexture;

    public GameObject promoBanner;

    public void SetPromo(string image_url, string url, string type = "EXT")
    {
        Debug.Log(" * PROMO * SetPromo:" + GlobalVars.Instance.URL_HOST + "content/" + image_url);
        this.image_url = image_url;
        this.url = url;
        this.promoType = type;
        this.gameObject.SetActive(true);
        StartCoroutine(LoadImage());
    }

    IEnumerator LoadImage()
    {
        Debug.Log(" * PROMO * " + GlobalVars.Instance.URL_HOST + "content/" + image_url);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(GlobalVars.Instance.URL_HOST + "content/" + image_url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D webTexture = ((DownloadHandlerTexture)www.downloadHandler).texture as Texture2D;
            Sprite webSprite = SpriteFromTexture2D(webTexture);
            promoBanner.SetActive(true);
            promoBanner.GetComponent<Image>().sprite = webSprite;
        }
    }

    Sprite SpriteFromTexture2D(Texture2D texture)
    {

        return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    public void GoPromo()
    {
        Debug.Log(" * PROMO * " + url);
        if (promoType == "EXT")
        {
            if (url != "")
            {
                url = url.Replace("|", "/");
                Application.OpenURL(url);
                //Salir();
            }
        }
    }

    public void Salir()
    {
        GlobalVars.Instance.showPromo = false;
        this.gameObject.SetActive(false);
    }
}
