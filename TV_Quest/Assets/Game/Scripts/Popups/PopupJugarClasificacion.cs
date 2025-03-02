using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupJugarClasificacion : MonoBehaviour
{
    public GameObject jugar_btn;
    public Text jugar_txt;
    public Text precio_txt;

    private void Start()
    {
        int precio = 100 + GlobalVars.Instance.progress;
        precio_txt.text = precio.ToString();

        if (GlobalVars.Instance.coins < precio)
        {
            SetTransparent(jugar_btn, true);
            //SetTransparentText(jugar_txt, true);
            jugar_txt.text = "Sin Fondos";
        }
    }

    public void closePopup()
    {
        this.gameObject.SetActive(false);
    }

    private void SetTransparent(GameObject objeto, bool _transparent)
    {
        if (_transparent)
        {
            var tempColor = objeto.GetComponent<Image>().color;
            tempColor.a = 0.2f;
            objeto.GetComponent<Image>().color = tempColor;
        }
        else
        {
            var tempColor = objeto.GetComponent<Image>().color;
            tempColor.a = 1f;
            objeto.GetComponent<Image>().color = tempColor;
        }
    }

    private void SetTransparentText(Text objeto, bool _transparent)
    {
        if (_transparent)
        {
            var tempColor = objeto.color;
            tempColor.a = 0.2f;
            objeto.color = tempColor;
        }
        else
        {
            var tempColor = objeto.color;
            tempColor.a = 1f;
            objeto.color = tempColor;
        }
    }
}
