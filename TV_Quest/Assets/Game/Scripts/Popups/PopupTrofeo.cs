using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupTrofeo : MonoBehaviour
{
    public Sprite[] trofeos;
    public GameObject trofeo;
    public NavigationManager navigationManager;

    public void SetTrofeo(string _trofeo)
    {
        switch (_trofeo)
        {
            case "pola"     : trofeo.GetComponent<Image>().sprite = trofeos[0];  break;
            case "mecha"    : trofeo.GetComponent<Image>().sprite = trofeos[1]; break;
            case "bocin"    : trofeo.GetComponent<Image>().sprite = trofeos[2]; break;
            case "gallina"  : trofeo.GetComponent<Image>().sprite = trofeos[3]; break;
            case "petaco"   : trofeo.GetComponent<Image>().sprite = trofeos[4]; break;
            case "lechona"  : trofeo.GetComponent<Image>().sprite = trofeos[5]; break;
            case "cariador" : trofeo.GetComponent<Image>().sprite = trofeos[6]; break;
            case "bofe"     : trofeo.GetComponent<Image>().sprite = trofeos[7]; break;
            case "fritanga" : trofeo.GetComponent<Image>().sprite = trofeos[8]; break;  
        }
    }
}
