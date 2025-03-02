using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromoManager : MonoBehaviour
{
    public Communicator communicator;
    public PopupPromo popupPromo;
    
    private string image_url;
    private string ios_url;
    private string android_url;
    private string promoType;

    private string url;

    public void loadPromo()
    {
        Debug.Log(" * PROMO * loadPromo");
        communicator.getPromo();
    }

    public void onCommunicatorResult(JSONObject dataJSON)
    {
        try
        {
            JSONObject result = dataJSON[0];
            image_url = result.GetField("image_url").str;
            ios_url = result.GetField("ios_url").str;
            android_url = result.GetField("android_url").str;
            promoType = result.GetField("promoType").str;

            if(GlobalVars.Instance.device == "Android")
            {
                url = android_url;
            }
            else
            {
                url = ios_url;
            }

            if (image_url != "")
            {
                popupPromo.SetPromo(image_url, url, promoType);
            }
        }
        catch { }
    }
}
