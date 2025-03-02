using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PopupLogin : MonoBehaviour
{
    public Entrada_UIManager uiManager;
    public Communicator communicator;
    public GameObject loading;
    public InputField emailInput;
    public InputField pswInput;

    public GameObject eye;
    public GameObject eyeClosed;

    public void login()
    {
        if (!checkEmail(emailInput.text))
        {
            uiManager.SetError("Error", "Ingrese bien su email sumerce!");
        }
        else if (pswInput.text.Length < 8)
        {
            uiManager.SetError("Error", "Ingrese una contraseña \n de más de 8 digitos!");
        }
        else
        {
            loading.SetActive(true);
            communicator.loginUser(emailInput.text, pswInput.text);
        }
    }

    public void GoOlvidoContra()
    {
        Application.OpenURL("https://alexsosa.me/virtualtejo#forgot");
        this.gameObject.SetActive(false);
    }

    public void onLoginFacebook(string idFacebook, string nombre, string email, Texture2D foto)
    {
        loading.SetActive(true);
        GlobalVars.Instance.player1.idFacebook = idFacebook;
        GlobalVars.Instance.player1.nombre = nombre;
        GlobalVars.Instance.player1.email = email;
        GlobalVars.Instance.player1.foto = foto;
        communicator.getUserFacebook(idFacebook);
    }

    public void registrarse()
    {
        uiManager.setPopupRegistro();
        this.gameObject.SetActive(false);
    }

    public void onGetUserResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        Debug.Log(result.GetField("status").str);
        loading.SetActive(false);
        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.SaveGlobalUserVars(result);

            uiManager.header.SetDefaultData();
            uiManager.header.SetAvatar();
            uiManager.setUserAvatar();
            this.gameObject.SetActive(false);
        }
    }

    public void ShowInvitado()
    {
        uiManager.setPopupInvitado();
    }

    public void SetInvitado()
    {
        Debug.Log("XX :: GlobalVars.Instance.invitadoSelection:" + GlobalVars.Instance.invitadoSelection);

        GlobalVars.Instance.SaveInvitadoUserVars();
        uiManager.header.SetDefaultData();
        uiManager.header.SetAvatar();
        uiManager.setUserAvatar();
        this.gameObject.SetActive(false);
        uiManager.popupInvitado.SetActive(false);

        if (GlobalVars.Instance.invitadoSelection == "campeonato")
        {
            uiManager.GoNivel();
        }

        if (GlobalVars.Instance.invitadoSelection == "reto")
        {
            uiManager.GoReto();
        }
        GlobalVars.Instance.invitadoSelection = "";
    }

    public void showPassword()
    {
        eye.SetActive(false);
        eyeClosed.SetActive(true);
        pswInput.contentType = InputField.ContentType.Standard;
        pswInput.Select();
    }

    public void hidePassword()
    {
        eye.SetActive(true);
        eyeClosed.SetActive(false);
        pswInput.contentType = InputField.ContentType.Password;
        pswInput.Select();
    }

    public void closePopup()
    {
        this.gameObject.SetActive(false);
    }

    private bool checkEmail(string email)
    {
        Debug.Log("email to check:" + email);
        return(Regex.IsMatch(email, "([a-zA-Z0-9]{1,100})[@]([a-zA-Z0-9]{2,50})[.]([a-zA-Z0-9]{2,10})", RegexOptions.IgnoreCase));
    }
}
