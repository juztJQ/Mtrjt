using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupCambiarContrasena : MonoBehaviour
{
    public Communicator communicator;
    public GameObject loading;
    public InputField pswInput;
    public InputField newPswInput;

    public GameObject eye;
    public GameObject eyeClosed;
    public GameObject eye2;
    public GameObject eyeClosed2;

    public ErrorMessage errorMessage;

    public void cambiar()
    {
        if (pswInput.text.Length < 8)
        {
            errorMessage.SetError("Error", "Ingrese una contraseña \n de más de 8 digitos!");
        }else if (newPswInput.text.Length < 8)
        {
            errorMessage.SetError("Error", "Ingrese una nueva contraseña \n de más de 8 digitos!");
        }
        else
        {
            loading.SetActive(true);
            communicator.cambioContrasena(GlobalVars.Instance.player1.idUser, pswInput.text, newPswInput.text);
        }
    }

    public void onGetUserResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        Debug.Log(result.GetField("status").str);
        loading.SetActive(false);
        if (result.GetField("status").str == "existe")
        {
            pswInput.text = "";
            newPswInput.text = "";
            errorMessage.SetError("bien!", "La contraseña se ha cambiado \n no la olvide sumercé!");
            this.gameObject.SetActive(false);
        }
        else
        {
            errorMessage.SetError("Error", "La información es incorrecta \n Intente de nuevo!");
        }
    }

    public void closePopup()
    {
        this.gameObject.SetActive(false);
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

    public void showNewPassword()
    {
        eye2.SetActive(false);
        eyeClosed2.SetActive(true);
        newPswInput.contentType = InputField.ContentType.Standard;
        newPswInput.Select();
    }

    public void hideNewPassword()
    {
        eye2.SetActive(true);
        eyeClosed2.SetActive(false);
        newPswInput.contentType = InputField.ContentType.Password;
        newPswInput.Select();
    }

}
