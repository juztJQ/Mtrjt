using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarObject : MonoBehaviour
{
    public GameObject cuerpoDisplay;
    public GameObject caraDisplay;

    public GameObject cabello1Display;
    public GameObject cabello2Display;
    public GameObject ropa1Display;
    public GameObject ropa2Display;
    public GameObject sombrero1Display;
    public GameObject sombrero2Display;
    public GameObject pantalon1Display;
    public GameObject pantalon2Display;

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

    public void SetAvatar(int _genero, int _cuerpo, int _cara, int _cabello, int _pantalon, int _ropa, int _sombrero)
    {
        //Debug.Log("Avatar: " + _genero + "," + _cuerpo + "," + _cara + "," + _cabello + "," + _pantalon + "," + _ropa + "," + _sombrero);
        genero      = _genero;
        cuerpo      = _cuerpo;
        cara        = _cara;
        cabello     = _cabello;
        pantalon    = _pantalon;
        ropa        = _ropa;
        sombrero    = _sombrero;
        PintaAvatar();
    }

    public void PintaAvatar()
    {
        if (genero == 0) cuerpoDisplay.GetComponent<SpriteRenderer>().sprite = cuerpos1[cuerpo]; else cuerpoDisplay.GetComponent<SpriteRenderer>().sprite = cuerpos2[cuerpo];
        if (genero == 0) caraDisplay.GetComponent<SpriteRenderer>().sprite = caras1[cara]; else caraDisplay.GetComponent<SpriteRenderer>().sprite = caras2[cara];

        if (genero == 0)
        {
            cabello1Display.SetActive(true);
            cabello2Display.SetActive(false);
            ropa1Display.SetActive(true);
            ropa2Display.SetActive(false);
            sombrero1Display.SetActive(true);
            sombrero2Display.SetActive(false);
            pantalon1Display.SetActive(true);
            pantalon2Display.SetActive(false);
        }
        else
        {
            cabello1Display.SetActive(false);
            cabello2Display.SetActive(true);
            ropa1Display.SetActive(false);
            ropa2Display.SetActive(true);
            sombrero1Display.SetActive(false);
            sombrero2Display.SetActive(true);
            pantalon1Display.SetActive(false);
            pantalon2Display.SetActive(true);
        }

        if (genero == 0)
        {
            cabello1Display.GetComponent<SpriteRenderer>().sprite = cabellos1[cabello];
        }
        else
        {
            cabello2Display.GetComponent<SpriteRenderer>().sprite = cabellos2[cabello];
        }
        if (genero == 0) ropa1Display.GetComponent<SpriteRenderer>().sprite = ropas1[ropa];                          else ropa2Display.GetComponent<SpriteRenderer>().sprite = ropas2[ropa];
        if (genero == 0) sombrero1Display.GetComponent<SpriteRenderer>().sprite = sombreros1[sombrero];              else sombrero2Display.GetComponent<SpriteRenderer>().sprite = sombreros2[sombrero];
        if (genero == 0) pantalon1Display.GetComponent<SpriteRenderer>().sprite = pantalones1[pantalon];    else pantalon2Display.GetComponent<SpriteRenderer>().sprite = pantalones2[pantalon];

    }
}
