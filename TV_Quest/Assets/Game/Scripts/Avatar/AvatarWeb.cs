using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarWeb : MonoBehaviour
{
    public GameObject miniLoading;
    public GameObject oAvatar;
    public LoadImage oGenero;
    public LoadImage oCara;
    public LoadImage oCabello;
    public LoadImage oPantalon;
    public LoadImage oRopa;
    public LoadImage oSombrero;
    public int loaded = 0;

    public int genero, cuerpo, cara, cabello, pantalon, ropa, sombrero;

    private void Start()
    {
        //RandomAvatar();
    }

    private void Update()
    {
        if (loaded >= 6)
        {
            oAvatar.GetComponent<Animator>().SetBool("enter", true);
            miniLoading.SetActive(false);
            loaded = 0;
        }
    }

    public void setAvatar(int _genero, int _cuerpo, int _cara, int _cabello, int _pantalon, int _ropa, int _sombrero)
    {
        oAvatar.GetComponent<Animator>().SetBool("enter", false);
        loaded = 0;
        genero      = _genero;
        cuerpo      = _cuerpo;
        cara        = _cara;
        cabello     = _cabello;
        pantalon    = _pantalon;
        ropa        = _ropa;
        sombrero    = _sombrero;

        oGenero.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/cuerpos/" + genero.ToString() + "/" + cuerpo.ToString() + ".png");
        oCara.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/caras/" + genero.ToString() + "/" + cara.ToString() + ".png");
        oCabello.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/cabellos/" + genero.ToString() + "/" + cabello.ToString() + ".png");
        oPantalon.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/pantalones/" + genero.ToString() + "/" + pantalon.ToString() + ".png");
        oRopa.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/ropas/" + genero.ToString() + "/" + ropa.ToString() + ".png");
        oSombrero.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/sombreros/" + genero.ToString() + "/" + sombrero.ToString() + ".png");
    }

    public void RandomAvatar()
    {
        setAvatar(Random.Range(0, 2), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8));
    }

    public void PintaGenero(int _genero)
    {
        genero = _genero;
        setAvatar(genero, cuerpo, cara, cabello, pantalon, ropa, sombrero);
    }

    public void PintaCuerpo(int _cuerpo)
    {
        cuerpo = _cuerpo;
        oGenero.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/cuerpos/" + genero.ToString() + "/" + cuerpo.ToString() + ".png");
    }

    public void PintaCara(int _cara)
    {
        cara = _cara;
        oCara.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/caras/" + genero.ToString() + "/" + cara.ToString() + ".png");
    }

    public void PintaCabello(int _cabello)
    {
        cabello = _cabello;
        oCabello.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/cabellos/" + genero.ToString() + "/" + cabello.ToString() + ".png");
    }

    public void PintaPantalon(int _pantalon)
    {
        pantalon = _pantalon;
        oPantalon.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/pantalones/" + genero.ToString() + "/" + pantalon.ToString() + ".png");
    }

    public void PintaRopa(int _ropa)
    {
        ropa = _ropa;
        oRopa.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/ropas/" + genero.ToString() + "/" + ropa.ToString() + ".png");
    }

    public void PintaSombrero(int _sombrero)
    {
        sombrero = _sombrero;
        oSombrero.setLoadImage(GlobalVars.Instance.URL_HOST + "services/admin/img/sombreros/" + genero.ToString() + "/" + sombrero.ToString() + ".png");
    }

    public void DisableItem(string objeto, bool _disable)
    {
        LoadImage oObjeto = oRopa;

        switch (objeto)
        {
            case "cara"     : oObjeto = oCara; break;
            case "cabello"  : oCabello = oCara; break;
            case "pantalon" : oObjeto = oPantalon; break;
            case "ropa"     : oObjeto = oRopa; break;
            case "sombrero": oObjeto = oSombrero; break;
        }

        if (_disable)
        {
            oObjeto.SetBlack();
        }
        else
        {
            oObjeto.SetNormal();
        }

    }

}
