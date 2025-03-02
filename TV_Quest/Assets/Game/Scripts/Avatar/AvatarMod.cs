using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarMod : MonoBehaviour
{
    
    public GameObject caraDisplay;
    public GameObject pantalonDisplay;
    public Text nombreDisplay;

    public GameObject cuerpo1Display;
    public GameObject cuerpo2Display;
    public GameObject cabello1Display;
    public GameObject cabello2Display;
    public GameObject ropa1Display;
    public GameObject ropa2Display;
    public GameObject sombrero1Display;
    public GameObject sombrero2Display;

    public Sprite[] cuerpos1;
    public Sprite[] caras1;
    public Sprite[] cabellos1;
    public Sprite[] pantalones1;
    public Sprite[] ropas1;
    public Sprite[] sombreros1;

    public Sprite[] cuerpos2;
    public Sprite[] caras2;
    public Sprite[] cabellos2;
    public Sprite[] pantalones2;
    public Sprite[] ropas2;
    public Sprite[] sombreros2;

    private int genero;
    private int cuerpo;
    private int cara;
    private int cabello;
    private int pantalon;
    private int ropa;
    private int sombrero;
    private string nombre = "";
    
    public void SetAvatar(int _genero, int _cuerpo, int _cara, int _cabello, int _pantalon, int _ropa, int _sombrero, string _nombre = "")
    {
        genero      = _genero;
        cuerpo      = _cuerpo;
        cara        = _cara;
        cabello     = _cabello;
        pantalon    = _pantalon;
        ropa        = _ropa;
        sombrero    = _sombrero;
        nombre      = _nombre;
        //Debug.Log("SetAvatar :: sombrero: " + sombrero);
        PintaAvatar();
    }

    public void PintaAvatar()
    {
        //Debug.Log("PintaAvatar :: sombrero: " + sombrero);
        caraDisplay.SetActive(true);
        pantalonDisplay.SetActive(true);
        if (genero == 0) caraDisplay.GetComponent<Image>().sprite = caras1[cara]; else caraDisplay.GetComponent<Image>().sprite = caras2[cara];
        if (genero == 0) pantalonDisplay.GetComponent<Image>().sprite = pantalones1[pantalon]; else pantalonDisplay.GetComponent<Image>().sprite = pantalones2[pantalon];

        if (genero == 0)
        {
            cuerpo1Display.SetActive(true);
            cuerpo2Display.SetActive(false);
            cabello1Display.SetActive(true);
            cabello2Display.SetActive(false);
            ropa1Display.SetActive(true);
            ropa2Display.SetActive(false);
            sombrero1Display.SetActive(true);
            sombrero2Display.SetActive(false);
        }
        else
        {
            cuerpo1Display.SetActive(false);
            cuerpo2Display.SetActive(true);
            cabello1Display.SetActive(false);
            cabello2Display.SetActive(true);
            ropa1Display.SetActive(false);
            ropa2Display.SetActive(true);
            sombrero1Display.SetActive(false);
            sombrero2Display.SetActive(true);
        }

        if (genero == 0) cuerpo1Display.GetComponent<Image>().sprite = cuerpos1[cuerpo];        else cuerpo2Display.GetComponent<Image>().sprite = cuerpos2[cuerpo];
        if (genero == 0) cabello1Display.GetComponent<Image>().sprite = cabellos1[cabello];     else cabello2Display.GetComponent<Image>().sprite = cabellos2[cabello];
        if (genero == 0) ropa1Display.GetComponent<Image>().sprite = ropas1[ropa];              else ropa2Display.GetComponent<Image>().sprite = ropas2[ropa];
        if (genero == 0) sombrero1Display.GetComponent<Image>().sprite = sombreros1[sombrero];  else sombrero2Display.GetComponent<Image>().sprite = sombreros2[sombrero];
        nombreDisplay.text = nombre;
    }

    public void PintaGenero(int _genero)
    {
        //Debug.Log("++ genero:" + _genero);
        genero = _genero;
        if (genero == 0)
        {
            cuerpo1Display.SetActive(true);
            cuerpo2Display.SetActive(false);
        }
        else
        {
            cuerpo1Display.SetActive(false);
            cuerpo2Display.SetActive(true);
        }
        PintaAvatar();
    }

    public void PintaColor(int _cuerpo)
    {
        cuerpo = _cuerpo;
        if (genero == 0)
        {
            cuerpo1Display.SetActive(true);
            cuerpo1Display.GetComponent<Image>().sprite = cuerpos1[cuerpo];
        }
        else
        {
            cuerpo2Display.SetActive(true);
            cuerpo2Display.GetComponent<Image>().sprite = cuerpos2[cuerpo];
        }
    }

    public void PintaCara(int _cara)
    {
        cara = _cara;
        if (genero == 0)
        {
            cuerpo1Display.SetActive(true);
            caraDisplay.GetComponent<Image>().sprite = caras1[cara];
        }
        else
        {
            cuerpo2Display.SetActive(true);
            caraDisplay.GetComponent<Image>().sprite = caras2[cara];
        }
    }

    public void PintaSombrero(int _sombrero)
    {
        sombrero = _sombrero;
        if (genero == 0)
        {
            cuerpo1Display.SetActive(true);
            sombrero1Display.GetComponent<Image>().sprite = sombreros1[sombrero];
        }
        else
        {
            cuerpo2Display.SetActive(true);
            sombrero2Display.GetComponent<Image>().sprite = sombreros2[sombrero];
        }
    }

    public void PintaCabello(int _cabello)
    {
        cabello = _cabello;
        if (genero == 0)
        {
            cuerpo1Display.SetActive(true);
            cabello1Display.GetComponent<Image>().sprite = cabellos1[cabello];
        }
        else
        {
            cuerpo2Display.SetActive(true);
            cabello2Display.GetComponent<Image>().sprite = cabellos2[cabello];
        }
    }

    public void PintaRopa(int _ropa)
    {
        ropa = _ropa;
        if (genero == 0)
        {
            cuerpo1Display.SetActive(true);
            ropa1Display.GetComponent<Image>().sprite = ropas1[ropa];
        }
        else
        {
            cuerpo2Display.SetActive(true);
            ropa2Display.GetComponent<Image>().sprite = ropas2[ropa];
        }
    }

    public void PintaPantalon(int _pantalon)
    {
        pantalon = _pantalon;
        pantalonDisplay.SetActive(true);
        if (genero == 0)
        {
            pantalonDisplay.GetComponent<Image>().sprite = pantalones1[pantalon];
        }
        else
        {
            pantalonDisplay.GetComponent<Image>().sprite = pantalones2[pantalon];
        }
    }

    public void SetNombre(string _nombre)
    {
        nombre = _nombre;
        nombreDisplay.text = nombre;
    }

    public void DisableRopa(bool _disable)
    {
        if (_disable)
        {
            if (genero == 0) SetBlack(ropa1Display); else SetBlack(ropa2Display);
        }
        else
        {
            if (genero == 0) SetNormal(ropa1Display); else SetNormal(ropa2Display);
        }
        
    }

    public void DisablePantalon(bool _disable)
    {
        if (_disable)
        {
            SetBlack(pantalonDisplay);
        }
        else
        {
            SetNormal(pantalonDisplay);
        }
    }

    public void DisableSombrero(bool _disable)
    {
        if (_disable)
        {
            if (genero == 0) SetBlack(sombrero1Display); else SetBlack(sombrero2Display);
        }
        else
        {
            if (genero == 0) SetNormal(sombrero1Display); else SetNormal(sombrero2Display);
        }
    }

    private void SetBlack(GameObject objeto)
    {
        var tempColor = objeto.GetComponent<Image>().color;
        tempColor.r = 0.2f;
        tempColor.g = 0.2f;
        tempColor.b = 0.2f;
        objeto.GetComponent<Image>().color = tempColor;
    }

    private void SetNormal(GameObject objeto)
    {
        var tempColor = objeto.GetComponent<Image>().color;
        tempColor.r = 1;
        tempColor.g = 1;
        tempColor.b = 1;
        objeto.GetComponent<Image>().color = tempColor;
    }
}
