using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupAsset : MonoBehaviour
{
    public GameObject sombrero;
    public GameObject ropa;
    public GameObject pantalon;
    public Sprite[] sombreros1;
    public Sprite[] sombreros2;
    public Sprite[] ropas1;
    public Sprite[] ropas2;
    public Sprite[] pantalones1;
    public Sprite[] pantalones2;

    public void SetAsset(string _type, int _numLevel)
    {
        int numAsset = 0;
        switch (_numLevel)
        {
            case 4  : numAsset = 3; break;
            case 7  : numAsset = 3; break;
            case 13 : numAsset = 3; break;
            case 16 : numAsset = 4; break;
            case 22 : numAsset = 4; break;
            case 25 : numAsset = 4; break;
            case 31 : numAsset = 5; break;
            case 34 : numAsset = 5; break;
            case 40 : numAsset = 5; break;
            case 43 : numAsset = 6; break;
            case 49 : numAsset = 6; break;
            case 52 : numAsset = 6; break;
            case 58 : numAsset = 7; break;
            case 61 : numAsset = 7; break;
            case 67 : numAsset = 7; break;
        }
        switch (_type)
        {
            case "ropa":
                ropa.SetActive(true);
                if (GlobalVars.Instance.player1.genero == 0) ropa.GetComponent<Image>().sprite = ropas1[numAsset]; else ropa.GetComponent<Image>().sprite = ropas2[numAsset];
            break;
            case "sombrero":
                sombrero.SetActive(true);
                if (GlobalVars.Instance.player1.genero == 0) sombrero.GetComponent<Image>().sprite = sombreros1[numAsset]; else sombrero.GetComponent<Image>().sprite = sombreros2[numAsset];
            break;
            case "pantalon":
                pantalon.SetActive(true);
                if (GlobalVars.Instance.player1.genero == 0) pantalon.GetComponent<Image>().sprite = pantalones1[numAsset]; else pantalon.GetComponent<Image>().sprite = pantalones2[numAsset];
            break;
        }
    }
}
