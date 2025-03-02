using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarLocal : MonoBehaviour
{
    public GameObject oGenero;
    public GameObject oCara;
    public GameObject oCabello;
    public GameObject oPantalon;
    public GameObject oRopa;
    public GameObject oSombrero;

    public Sprite[] cuerpos0;
    public Sprite[] caras0;
    public Sprite[] cabellos0;
    public Sprite[] pantalones0;
    public Sprite[] ropas0;
    public Sprite[] sombreros0;

    public Sprite[] cuerpos1;
    public Sprite[] caras1;
    public Sprite[] cabellos1;
    public Sprite[] pantalones1;
    public Sprite[] ropas1;
    public Sprite[] sombreros1;

    private void Start()
    {
        RandomAvatar();
    }

    public void RandomAvatar()
    {
        setAvatar(Random.Range(0, 2), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8), Random.Range(0, 8));
    }

    public void setAvatar(int _genero, int _cuerpo, int _cara, int _cabello, int _pantalon, int _ropa, int _sombrero)
    {
        if (_genero == 0)
        {
            oGenero.GetComponent<Image>().sprite    = cuerpos0[_cuerpo];
            oCara.GetComponent<Image>().sprite      = caras0[_cara];
            oCabello.GetComponent<Image>().sprite   = cabellos0[_cabello];
            oPantalon.GetComponent<Image>().sprite  = pantalones0[_pantalon];
            oRopa.GetComponent<Image>().sprite      = ropas0[_ropa];
            oSombrero.GetComponent<Image>().sprite  = sombreros0[_sombrero];
        }
        else
        {
            oGenero.GetComponent<Image>().sprite    = cuerpos1[_cuerpo];
            oCara.GetComponent<Image>().sprite      = caras1[_cara];
            oCabello.GetComponent<Image>().sprite   = cabellos1[_cabello];
            oPantalon.GetComponent<Image>().sprite  = pantalones1[_pantalon];
            oRopa.GetComponent<Image>().sprite      = ropas1[_ropa];
            oSombrero.GetComponent<Image>().sprite  = sombreros1[_sombrero];
        }
    }
}
