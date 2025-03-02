using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrofeoBox : MonoBehaviour
{
    public Sprite[] trofeos;
    public GameObject trofeo;
    public Communicator communicator;
    public PopupFinJuego popupFinJuego;

    public void SetPopupTrofeo()
    {
        this.GetComponent<Animator>().SetBool("enter", true);

        if (GlobalVars.Instance.numWord == 10) {        GlobalVars.Instance.hasPolaOro = 1;         SetTrofeo("pola");      }
        else if (GlobalVars.Instance.numWord == 19) {   GlobalVars.Instance.hasMechaOro = 1;        SetTrofeo("mecha");     }
        else if (GlobalVars.Instance.numWord == 28) {   GlobalVars.Instance.hasSuperBocin = 1;      SetTrofeo("bocin");     }
        else if (GlobalVars.Instance.numWord == 37) {   GlobalVars.Instance.hasGallina = 1;         SetTrofeo("gallina");   }
        else if (GlobalVars.Instance.numWord == 46) {   GlobalVars.Instance.hasPetacoOro = 1;       SetTrofeo("petaco");    }
        else if (GlobalVars.Instance.numWord == 55) {   GlobalVars.Instance.hasCabezaLechona = 1;   SetTrofeo("lechona");   }
        else if (GlobalVars.Instance.numWord == 64) {   GlobalVars.Instance.hasCariador = 1;        SetTrofeo("cariador");  }
        else if (GlobalVars.Instance.numWord == 73) {   GlobalVars.Instance.hasBofeOro = 1;         SetTrofeo("bofe");      }
        else if (GlobalVars.Instance.numWord == 82) {   GlobalVars.Instance.hasFritanga = 1;        SetTrofeo("fritanga");  }
        communicator.UpdateTrofeosUser(GlobalVars.Instance.player1.idUser);
    }

    public void SetTrofeo(string _trofeo)
    {
        trofeo.gameObject.SetActive(true);
        switch (_trofeo)
        {
            case "pola": trofeo.GetComponent<Image>().sprite = trofeos[0]; break;
            case "mecha": trofeo.GetComponent<Image>().sprite = trofeos[1]; break;
            case "bocin": trofeo.GetComponent<Image>().sprite = trofeos[2]; break;
            case "gallina": trofeo.GetComponent<Image>().sprite = trofeos[3]; break;
            case "petaco": trofeo.GetComponent<Image>().sprite = trofeos[4]; break;
            case "lechona": trofeo.GetComponent<Image>().sprite = trofeos[5]; break;
            case "cariador": trofeo.GetComponent<Image>().sprite = trofeos[6]; break;
            case "bofe": trofeo.GetComponent<Image>().sprite = trofeos[7]; break;
            case "fritanga": trofeo.GetComponent<Image>().sprite = trofeos[8]; break;
        }
    }

    public void OnSetTrofeos(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        Debug.Log(result.GetField("status").str);

        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.SaveGlobalUserVars(result);
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
