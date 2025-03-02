using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class CreditosItem : MonoBehaviour
{
    private string url;
    private string image;
    public LoadImage banner;

    public void SetCreditosItem(string _url, string _image)
    {
        url = _url;
        image = _image;
        banner.setLoadCredit(image);
    }

    public void GoURL()
    {
        if (url != "")
        {
            Application.OpenURL(url);
        }
    }
}
