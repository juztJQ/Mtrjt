using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Avatar : MonoBehaviour
{
    
    public Image caraDisplay;
    public Image pantalonDisplay;
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
    public string nombre = "";

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
        PintaAvatar();
    }

    public void PintaAvatar()
    {
        if (genero == 0) caraDisplay.sprite = caras1[cara]; else caraDisplay.sprite = caras2[cara];
        if (genero == 0) pantalonDisplay.sprite = pantalones1[pantalon]; else pantalonDisplay.sprite = pantalones2[pantalon];

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
}
