using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarManager : MonoBehaviour
{
    public ADmob oADmob;
    public Entrada_UIManager uIManager;
    public NavigationManager navigationManager;
    public Header header;
    public Header headerLite;
    public AvatarWeb avatarWeb;
    public GameObject cabelloBtn;
    public Sprite spriteCabello1;
    public Sprite spriteCabello2;
    public Text nombre_txt;

    private int genero;
    private int color;
    private int cara;
    private int sombrero;
    private int cabello;
    private int ropa;
    private int pantalon;
    private string nombre;

    public GameObject candadoSombrero;
    public GameObject candadoRopa;
    public GameObject candadoPantalon;
    public GameObject candado;
    public GameObject guardarBtn;
    public GameObject guardarImage;
    public GameObject guardarText;

    public GameObject popupLogout;
    public GameObject popupCambiarContrasena;
    public GameObject popupOpcionesUsuario;

    public void SetAvatarManager()
    {
        genero = GlobalVars.Instance.player1.genero;
        color = GlobalVars.Instance.player1.cuerpo;
        cara = GlobalVars.Instance.player1.cara;
        cabello = GlobalVars.Instance.player1.cabello;
        pantalon = GlobalVars.Instance.player1.pantalon;
        ropa = GlobalVars.Instance.player1.ropa;
        sombrero = GlobalVars.Instance.player1.sombrero;
        nombre = GlobalVars.Instance.player1.nombre;

        nombre_txt.text = nombre;

        avatarWeb.setAvatar(GlobalVars.Instance.player1.genero,
           GlobalVars.Instance.player1.cuerpo,
           GlobalVars.Instance.player1.cara,
           GlobalVars.Instance.player1.cabello,
           GlobalVars.Instance.player1.pantalon,
           GlobalVars.Instance.player1.ropa,
           GlobalVars.Instance.player1.sombrero
           );

        headerLite.SetHeaderLite();
    }

    public void SetGenero()
    {
        uIManager.audioManager.SetClick();
        if (genero == 0)
        {
            genero = 1;
            cabelloBtn.GetComponent<Image>().sprite = spriteCabello2;
        }
        else
        {
            genero = 0;
            cabelloBtn.GetComponent<Image>().sprite = spriteCabello1;
        }
        avatarWeb.PintaGenero(genero);
    }

    public void SetCuerpo()
    {
        uIManager.audioManager.SetClick();
        if (color < 7)
        {
            color++;
        }
        else
        {
            color = 0;
        }
        avatarWeb.PintaCuerpo(color);
    }

    public void SetCara()
    {
        uIManager.audioManager.SetClick();
        if (cara < 7)
        {
            cara++;
        }
        else
        {
            cara = 0;
        }
        avatarWeb.PintaCara(cara);
    }

    public void SetCabello()
    {
        uIManager.audioManager.SetClick();
        if (cabello < 7)
        {
            cabello++;
        }
        else
        {
            cabello = 0;
        }
        avatarWeb.PintaCabello(cabello);
    }

    public void SetPantalon()
    {
        uIManager.audioManager.SetClick();
        if (pantalon < 7)
        {
            pantalon++;
        }
        else
        {
            pantalon = 0;
        }
        avatarWeb.PintaPantalon(pantalon);

        bool canBuy = true;
        switch (pantalon)
        {
            case 3: if (GlobalVars.Instance.numWord > 6) canBuy = true; else canBuy = false; break;
            case 4: if (GlobalVars.Instance.numWord > 21) canBuy = true; else canBuy = false; break;
            case 5: if (GlobalVars.Instance.numWord > 33) canBuy = true; else canBuy = false; break;
            case 6: if (GlobalVars.Instance.numWord > 48) canBuy = true; else canBuy = false; break;
            case 7: if (GlobalVars.Instance.numWord > 60) canBuy = true; else canBuy = false; break;
        }
        candadoPantalon.SetActive(!canBuy);
        candado.SetActive(!canBuy);
        guardarBtn.GetComponent<Button>().enabled = canBuy;
        SetTransparent(guardarImage, !canBuy);
        SetTransparentText(guardarText, !canBuy);
        avatarWeb.DisableItem("pantalon", !canBuy);
    }

    public void SetRopa()
    {
        uIManager.audioManager.SetClick();
        if (ropa < 7)
        {
            ropa++;
        }
        else
        {
            ropa = 0;
        }
        avatarWeb.PintaRopa(ropa);

        bool canBuy = true;
        switch (ropa)
        {
            case 3: if (GlobalVars.Instance.numWord > 3) canBuy = true; else canBuy = false; break;
            case 4: if (GlobalVars.Instance.numWord > 15) canBuy = true; else canBuy = false; break;
            case 5: if (GlobalVars.Instance.numWord > 30) canBuy = true; else canBuy = false; break;
            case 6: if (GlobalVars.Instance.numWord > 42) canBuy = true; else canBuy = false; break;
            case 7: if (GlobalVars.Instance.numWord > 57) canBuy = true; else canBuy = false; break;
        }
        candadoRopa.SetActive(!canBuy);
        candado.SetActive(!canBuy);
        guardarBtn.GetComponent<Button>().enabled = canBuy;
        SetTransparent(guardarImage, !canBuy);
        SetTransparentText(guardarText, !canBuy);
        avatarWeb.DisableItem("ropa", !canBuy);
    }

    public void SetSombrero()
    {
        uIManager.audioManager.SetClick();
        if (sombrero < 7)
        {
            sombrero++;
        }
        else
        {
            sombrero = 0;
        }
        avatarWeb.PintaSombrero(sombrero);

        bool canBuy = true;
        switch (sombrero)
        {
            case 3: if (GlobalVars.Instance.numWord > 12) canBuy = true; else canBuy = false; break;
            case 4: if (GlobalVars.Instance.numWord > 24) canBuy = true; else canBuy = false; break;
            case 5: if (GlobalVars.Instance.numWord > 39) canBuy = true; else canBuy = false; break;
            case 6: if (GlobalVars.Instance.numWord > 51) canBuy = true; else canBuy = false; break;
            case 7: if (GlobalVars.Instance.numWord > 66) canBuy = true; else canBuy = false; break;
        }
        candadoSombrero.SetActive(!canBuy);
        candado.SetActive(!canBuy);
        guardarBtn.GetComponent<Button>().enabled = canBuy;
        SetTransparent(guardarImage, !canBuy);
        SetTransparentText(guardarText, !canBuy);
        avatarWeb.DisableItem("sombrero", !canBuy);
    }

    // ------------------------------------- NAVIGATION ------------------------------------ /

    public void setCancelar()
    {
        avatarWeb.setAvatar(GlobalVars.Instance.player1.genero,
           GlobalVars.Instance.player1.cuerpo,
           GlobalVars.Instance.player1.cara,
           GlobalVars.Instance.player1.cabello,
           GlobalVars.Instance.player1.pantalon,
           GlobalVars.Instance.player1.ropa,
           GlobalVars.Instance.player1.sombrero
           );
        uIManager.CloseAvatar();
    }

    public void CallOpcionesUsuario()
    {
        popupOpcionesUsuario.SetActive(true);
    }

    public void CancelOpcionesUsuario()
    {
        popupOpcionesUsuario.SetActive(false);
    }

    public void CallLogout()
    {
        popupLogout.SetActive(true);
    }

    public void CancelLogout()
    {
        popupLogout.SetActive(false);
    }

    public void logout()
    {
        GlobalVars.Instance.deleteData();
        navigationManager.goEntrada();
    }

    public void CambiarContrasena()
    {
        popupCambiarContrasena.gameObject.SetActive(true);
    }

    public void EliminarCuenta()
    {
        Application.OpenURL("https://www.virtualtejo.com/delete_account/");
    }


    // ------------------------------------- SET CHANGES ------------------------------------ /

    public void SetChanges()
    {
        oADmob.Init();
        oADmob.ShowVideo();
        GlobalVars.Instance.player1.genero = genero;
        GlobalVars.Instance.player1.cuerpo = color;
        GlobalVars.Instance.player1.cara = cara;
        GlobalVars.Instance.player1.cabello = cabello;
        GlobalVars.Instance.player1.pantalon = pantalon;
        GlobalVars.Instance.player1.ropa = ropa;
        GlobalVars.Instance.player1.sombrero = sombrero;
        GlobalVars.Instance.player1.nombre = nombre;
        header.UpdateAvatar();
        uIManager.setUserAvatar();
        uIManager.GoMainMenu();
    }

    // ------------------------------------- UTILS ------------------------------------ /

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

    private void SetTransparentText(GameObject objeto, bool _transparent)
    {
        if (_transparent)
        {
            var tempColor = objeto.GetComponent<Text>().color;
            tempColor.a = 0.2f;
            objeto.GetComponent<Text>().color = tempColor;
        }
        else
        {
            var tempColor = objeto.GetComponent<Text>().color;
            tempColor.a = 1f;
            objeto.GetComponent<Text>().color = tempColor;
        }
    }
}
