using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class PopupRegistro : MonoBehaviour
{
    public Entrada_UIManager uiManager;
    public InputField nombreInput;
    public InputField emailInput;
    public InputField pswInput;
    public RegionSelector regionSelector;
    public Communicator communicator;
    public GameObject loading;

    public GameObject eye;
    public GameObject eyeClosed;

    public void registerUser()
    {
        if (nombreInput.text.Length < 3)
        {
            uiManager.SetError("Error", "Ingrese bien su nombre sumercé!");
        }
        else if (!checkEmail(emailInput.text))
        {
            uiManager.SetError("Error", "Ingrese bien su email sumerce!");
        }
        else if (pswInput.text.Length < 8)
        {
            uiManager.SetError("Error", "Ingrese una contraseña \n de más de 8 digitos!");
        }
        else{
            loading.SetActive(true);
            communicator.registerUser(nombreInput.text, emailInput.text, pswInput.text, regionSelector.selection.ToString());
        }
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
        return (Regex.IsMatch(email, "([a-zA-Z0-9]{1,100})[@]([a-zA-Z0-9]{2,50})[.]([a-zA-Z0-9]{2,10})", RegexOptions.IgnoreCase));
    }
}
