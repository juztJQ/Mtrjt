using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetBox : MonoBehaviour
{
    public PopupFinJuego popupFinJuego;
    public LoadImage assetImage;
    public string kind;

    public void SetAsset()
    {
        if (GlobalVars.Instance.numWord <= 81)
        {
            if ((GlobalVars.Instance.numWord == 4) || (GlobalVars.Instance.numWord == 16) || (GlobalVars.Instance.numWord == 31) || (GlobalVars.Instance.numWord == 43) || (GlobalVars.Instance.numWord == 58))
            {
                loadAsset("ropas");
            }
            else if ((GlobalVars.Instance.numWord == 7) || (GlobalVars.Instance.numWord == 22) || (GlobalVars.Instance.numWord == 34) || (GlobalVars.Instance.numWord == 49) || (GlobalVars.Instance.numWord == 61))
            {
                loadAsset("pantalones");
            }
            else if ((GlobalVars.Instance.numWord == 13) || (GlobalVars.Instance.numWord == 25) || (GlobalVars.Instance.numWord == 40) || (GlobalVars.Instance.numWord == 52) || (GlobalVars.Instance.numWord == 67))
            {
                loadAsset("sombreros");
            }
        }
    }


    public void loadAsset(string _kind)
    {
        kind = _kind;
        this.GetComponent<Animator>().SetBool("enter", true);
        int numAsset = 0;
        switch (GlobalVars.Instance.numWord)
        {
            case 4: numAsset = 3; break;
            case 7: numAsset = 3; break;
            case 13: numAsset = 3; break;
            case 16: numAsset = 4; break;
            case 22: numAsset = 4; break;
            case 25: numAsset = 4; break;
            case 31: numAsset = 5; break;
            case 34: numAsset = 5; break;
            case 40: numAsset = 5; break;
            case 43: numAsset = 6; break;
            case 49: numAsset = 6; break;
            case 52: numAsset = 6; break;
            case 58: numAsset = 7; break;
            case 61: numAsset = 7; break;
            case 67: numAsset = 7; break;
        }
        assetImage.setLoadAsset(GlobalVars.Instance.URL_HOST + "services/admin/img/" + kind +"/" + GlobalVars.Instance.player1.genero.ToString() + "/" + numAsset.ToString() + ".png");
    }

    public void OnAssetLoaded()
    {
        assetImage.gameObject.transform.localScale = new Vector3(0.6f, 0.9f, 0.6f);

        switch (kind)
        {
            case "ropas"        : assetImage.gameObject.transform.localPosition = new Vector3(-3.5f, 23.3f, 0); break;
            case "pantalones"   : assetImage.gameObject.transform.localPosition = new Vector3(-4.1f, 48.8f, 0); break;
            case "sombreros"    : assetImage.gameObject.transform.localPosition = new Vector3(-4.1f, -4.2f, 0); assetImage.gameObject.transform.localScale = new Vector3(0.89f, 1.33f, 0.89f); break;
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4f);
        this.GetComponent<Animator>().SetBool("enter", false);
        popupFinJuego.ClosePopup();
    }

    public void onAnimate()
    {
        
    }
}
