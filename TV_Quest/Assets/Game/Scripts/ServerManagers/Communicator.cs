using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.Globalization;

public class Communicator : MonoBehaviour
{
    private Encrypt encrypt;
    public AS alexsosa;
    public CreditosManager creditosManager;
    public SponsorManager sponsorManager;
    public PromoManager promoManager;
    public Entrada_UIManager entrada;
    public Game_UIManager game;
    public RetoBox retoBox;
    public TrofeoBox trofeoBox;
    public PopupLogin popupLogin;
    public PopupCambiarContrasena popupCambiarContrasena;
    public ClasificacionManager clasificacionManager;
    public Header header;
    public GameObject loading;
    public ErrorMessage errorMessage;
    private bool isProcessing = false;
    private string key;
    private string service_type;
    private string servicesURL = "services/v2/";

    private void Awake()
    {
        encrypt = gameObject.AddComponent<Encrypt>();
    }

    ///----------------------------------------------------------------------------
    public void LoadConfig()
    {
        if (InternetAccess())
        {
            key = servicesURL+"config2.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(LoadingConfigPOST(token));
        }
    }

    public IEnumerator LoadingConfigPOST(string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url + " - token:" + token);
            WWWForm form = new WWWForm();
            form.AddField("token", token);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    alexsosa.onCommunicatorResult(dataJSON);
                }
                else { showError(www.error); }
            }
            else { showError(www.error); }
        }
    }
    ///----------------------------------------------------------------------------

    public void SetCacheUser(string idUser)
    {
        key = servicesURL + "setCacheUser.php";
        idUser = encrypt.EncryptString(idUser);
        string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
        string currentMundo = encrypt.EncryptString(PlayerPrefs.GetInt("currentMundo").ToString());
        string nivel = encrypt.EncryptString(PlayerPrefs.GetInt("nivel").ToString());
        string numWord = encrypt.EncryptString(PlayerPrefs.GetInt("numWord").ToString());
        string trofeos = encrypt.EncryptString(PlayerPrefs.GetInt("hasPolaOro").ToString() + "|"+PlayerPrefs.GetInt("hasMechaOro").ToString() + "|" +PlayerPrefs.GetInt("hasSuperBocin").ToString() + "|" +PlayerPrefs.GetInt("hasGallina").ToString() + "|" +PlayerPrefs.GetInt("hasPetacoOro").ToString() + "|" + PlayerPrefs.GetInt("hasCabezaLechona").ToString() + "|" + PlayerPrefs.GetInt("hasCariador").ToString() + "|" + PlayerPrefs.GetInt("hasBofeOro").ToString() + "|" + PlayerPrefs.GetInt("hasFritanga").ToString());
        string starsString = encrypt.EncryptString(PlayerPrefs.GetString("starsString"));
        StartCoroutine(SetCacheUserPOST(idUser, token, currentMundo, nivel, numWord, trofeos, starsString));
    }

    public IEnumerator SetCacheUserPOST(string idUser, string token, string currentMundo, string nivel, string numWord, string trofeos, string starsString)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();

            form.AddField("idUser", idUser);
            form.AddField("token", token);
            form.AddField("currentMundo", currentMundo);
            form.AddField("nivel", nivel);
            form.AddField("numWord", numWord);
            form.AddField("trofeos", trofeos);
            form.AddField("starsString", starsString);
            
            UnityWebRequest www = UnityWebRequest.Post(url, form);

            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    entrada.onSetCacheUserResult(dataJSON);
                }
                else
                {
                    showError(www.error);
                }
            }
            else
            {
                showError(www.error);
            }
        }
    }

    ///----------------------------------------------------------------------------

    public void UpdateCampeonatoUser(string idUser)
    {
        Debug.Log("UpdateCampeonatoUser");
        key = servicesURL + "setCacheUser.php";
        idUser = encrypt.EncryptString(idUser);
        string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
        string currentMundo = encrypt.EncryptString(GlobalVars.Instance.currentMundo.ToString());
        string nivel = encrypt.EncryptString(GlobalVars.Instance.nivel.ToString());
        string numWord = encrypt.EncryptString(GlobalVars.Instance.numWord.ToString());
        string trofeos = encrypt.EncryptString(GlobalVars.Instance.hasPolaOro.ToString() + "|" + GlobalVars.Instance.hasMechaOro.ToString() + "|" + GlobalVars.Instance.hasSuperBocin.ToString() + "|" + GlobalVars.Instance.hasGallina.ToString() + "|" + GlobalVars.Instance.hasPetacoOro.ToString() + "|" + GlobalVars.Instance.hasCabezaLechona.ToString() + "|" + GlobalVars.Instance.hasCariador.ToString() + "|" + GlobalVars.Instance.hasBofeOro.ToString() + "|" + GlobalVars.Instance.hasFritanga.ToString());
        string starsString = encrypt.EncryptString(GlobalVars.Instance.starsString.ToString());
        StartCoroutine(SetCampeonatoUserPOST(idUser, token, currentMundo, nivel, numWord, trofeos, starsString));
    }
    

    public IEnumerator SetCampeonatoUserPOST(string idUser, string token, string currentMundo, string nivel, string numWord, string trofeos, string starsString)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();

            form.AddField("idUser", idUser);
            form.AddField("token", token);
            form.AddField("currentMundo", currentMundo);
            form.AddField("nivel", nivel);
            form.AddField("numWord", numWord);
            form.AddField("trofeos", trofeos);
            form.AddField("starsString", starsString);

            UnityWebRequest www = UnityWebRequest.Post(url, form);

            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    game.OnSetCampeonato(dataJSON);
                }
                else
                {
                    showError(www.error);
                }
            }
            else
            {
                showError(www.error);
            }
        }
    }

    ///----------------------------------------------------------------------------

    public void UpdateTrofeosUser(string idUser)
    {
        Debug.Log("UpdateCampeonatoUser");
        key = servicesURL + "setCacheUser.php";
        idUser = encrypt.EncryptString(idUser);
        string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
        string currentMundo = encrypt.EncryptString(GlobalVars.Instance.currentMundo.ToString());
        string nivel = encrypt.EncryptString(GlobalVars.Instance.nivel.ToString());
        string numWord = encrypt.EncryptString(GlobalVars.Instance.numWord.ToString());
        string trofeos = encrypt.EncryptString(GlobalVars.Instance.hasPolaOro.ToString() + "|" + GlobalVars.Instance.hasMechaOro.ToString() + "|" + GlobalVars.Instance.hasSuperBocin.ToString() + "|" + GlobalVars.Instance.hasGallina.ToString() + "|" + GlobalVars.Instance.hasPetacoOro.ToString() + "|" + GlobalVars.Instance.hasCabezaLechona.ToString() + "|" + GlobalVars.Instance.hasCariador.ToString() + "|" + GlobalVars.Instance.hasBofeOro.ToString() + "|" + GlobalVars.Instance.hasFritanga.ToString());
        string starsString = encrypt.EncryptString(GlobalVars.Instance.starsString.ToString());
        StartCoroutine(SetTrofeosUserPOST(idUser, token, currentMundo, nivel, numWord, trofeos, starsString));
    }

    public IEnumerator SetTrofeosUserPOST(string idUser, string token, string currentMundo, string nivel, string numWord, string trofeos, string starsString)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();

            form.AddField("idUser", idUser);
            form.AddField("token", token);
            form.AddField("currentMundo", currentMundo);
            form.AddField("nivel", nivel);
            form.AddField("numWord", numWord);
            form.AddField("trofeos", trofeos);
            form.AddField("starsString", starsString);

            UnityWebRequest www = UnityWebRequest.Post(url, form);

            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    trofeoBox.OnSetTrofeos(dataJSON);
                }
                else
                {
                    showError(www.error);
                }
            }
            else
            {
                showError(www.error);
            }
        }
    }

    ///----------------------------------------------------------------------------

    public void getSponsor()
    {
        if (InternetAccess())
        {
            key = servicesURL + "getSponsor.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(LoadSponsorPOST(token));
        }
    }

    private IEnumerator LoadSponsorPOST(string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url + " - token:" + token);
            WWWForm form = new WWWForm();
            form.AddField("token", token);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    sponsorManager.onCommunicatorResult(dataJSON);
                }
                else { showError(www.error); }
            }
            else { showError(www.error); }
        }
    }

    ///----------------------------------------------------------------------------

    public void getPromo()
    {
        if (InternetAccess())
        {
            key = servicesURL + "getPromo.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            Debug.Log("* PROMO * Load: " + key + " - token:" + token);
            StartCoroutine(LoadPromoPOST(token));
        }
    }

    private IEnumerator LoadPromoPOST(string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("* PROMO * Loading: " + url + " - token:" + token);
            WWWForm form = new WWWForm();
            form.AddField("token", token);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    promoManager.onCommunicatorResult(dataJSON);
                }
                else { showError(www.error); }
            }
            else { showError(www.error); }
        }
    }

    ///----------------------------------------------------------------------------
    public void getAgras()
    {
        if (InternetAccess())
        {
            key = servicesURL + "getAgras.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(LoadAgrasPOST(token));
        }
    }

    public IEnumerator LoadAgrasPOST(string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url + " - token:" + token);
            WWWForm form = new WWWForm();
            form.AddField("token", token);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    creditosManager.onAgrasResult(dataJSON);
                }
                else { showError("error:++"+www.error); }
            }
            else { showError(www.error); }
        }
    }
    public void getRedes()
    {
        if (InternetAccess())
        {
            key = servicesURL + "getNet.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(LoadRedesPOST(token));
        }
    }

    public IEnumerator LoadRedesPOST(string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url + " - token:" + token);
            WWWForm form = new WWWForm();
            form.AddField("token", token);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    creditosManager.onRedesResult(dataJSON);
                }
                else { showError(www.error); }
            }
            else { showError(www.error); }
        }
    }

    ///----------------------------------------------------------------------------
    public void getUser(string idUser)
    {
        service_type = "getUser";
        if (InternetAccess())
        {
            key = servicesURL + "getUser.php";
            idUser = encrypt.EncryptString(idUser);
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(getUserPOST(idUser, token));
        }
    }

    public void getUserHeader(string idUser)
    {
        service_type = "getUserHeader";
        if (InternetAccess())
        {
            key = servicesURL + "getUser.php";
            idUser = encrypt.EncryptString(idUser);
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(getUserPOST(idUser, token));
        }
    }

    public void getUserFacebook(string idFacebook)
    {
        service_type = "getUserFacebook";
        if (InternetAccess())
        {
            key = servicesURL + "getUserFacebook.php";
            idFacebook = encrypt.EncryptString(idFacebook);
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(getUserPOST(idFacebook, token));
        }
    }

    private IEnumerator getUserPOST(string idUser, string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url + " - idUser:"+ idUser);
            WWWForm form = new WWWForm();
            form.AddField("idUser", idUser);
            form.AddField("token", token);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1)
                {
                    jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                    JSONObject dataJSON = new JSONObject(jsonString);
                    switch (service_type)
                    {
                        case "getUser"          : entrada.onGetUserResult(dataJSON);    break;
                        case "getUserHeader"    : header.onGetUserResult(dataJSON);     break;
                        case "getUserFacebook"  : popupLogin.onGetUserResult(dataJSON); break;
                    }
                    
                }
                else { showError(www.error); }
            }
            else { showError(www.error); }
        }
    }

    ///----------------------------------------------------------------------------

    public void loginUser(string email, string psw)
    {
        if (!InternetAccess())
        {
            try { errorMessage.SetError("Error", "Sumercé se cayó el internet! \n  revise su conexión!"); } catch { }
        }
        else
        {
            key = servicesURL + "loginUser.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            email = encrypt.EncryptString(email);
            psw = encrypt.EncryptString(psw);
            StartCoroutine(loginUserPOST(email, psw, token));
        }
    }

    private IEnumerator loginUserPOST(string email, string psw, string token)
    {
        if (!isProcessing) {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();
            form.AddField("token", token);
            form.AddField("email", email);
            form.AddField("psw", psw);
            UnityWebRequest www = UnityWebRequest.Post(url, form); 
            yield return www.SendWebRequest();
            if (www.isDone) {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1) {
                    jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                    JSONObject dataJSON = new JSONObject(jsonString);
                    entrada.onSetUserResult(dataJSON);
                    //mainMenu.onSetUserResult(dataJSON);
                } else { showError(www.error); }
            } else { showError(www.error); }
        }
    }

    ///----------------------------------------------------------------------------

    public void cambioContrasena(string idUser, string psw, string newPsw)
    {
        if (!InternetAccess())
        {
            try { errorMessage.SetError("Error", "Sumercé se cayó el internet! \n  revise su conexión!"); } catch { }
        }
        else
        {
            key = servicesURL + "cambioPsw.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            idUser = encrypt.EncryptString(idUser);
            psw = encrypt.EncryptString(psw);
            newPsw = encrypt.EncryptString(newPsw);
            StartCoroutine(cambioPswPOST(idUser, psw, newPsw, token));
        }
    }

    private IEnumerator cambioPswPOST(string idUser, string psw, string newPsw, string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();
            form.AddField("token", token);
            form.AddField("idUser", idUser);
            form.AddField("psw", psw);
            form.AddField("newPsw", newPsw);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1)
                {
                    jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                    JSONObject dataJSON = new JSONObject(jsonString);
                    popupCambiarContrasena.onGetUserResult(dataJSON);
                }
                else { showError(www.error); }
            }
            else { showError(www.error); }
        }
    }

    ///----------------------------------------------------------------------------
    public void registerUser(string nombre, string email, string psw, string idZona)
    {
        if (!InternetAccess())
        {
            try { errorMessage.SetError("Error", "Sumercé se cayó el internet! \n  revise su conexión!"); } catch { }
        }
        else
        {
            key = servicesURL + "register.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            email = encrypt.EncryptString(email);
            psw = encrypt.EncryptString(psw);
            idZona = encrypt.EncryptString(idZona);
            StartCoroutine(registerUserPOST(nombre, email, psw, idZona, token));
        }
    }

    private IEnumerator registerUserPOST(string nombre, string email, string psw, string idZona, string token)
    {
        if (!isProcessing) {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();

            if (GlobalVars.Instance.coins == 0) GlobalVars.Instance.coins = 200;

            string idFacebook = encrypt.EncryptString(GlobalVars.Instance.player1.idFacebook);
            string coins  = encrypt.EncryptString(GlobalVars.Instance.coins.ToString());
            string points = encrypt.EncryptString(GlobalVars.Instance.points.ToString());
            string avatar = encrypt.EncryptString(GlobalVars.Instance.player1.genero + "|" + GlobalVars.Instance.player1.cuerpo + "|" + GlobalVars.Instance.player1.cara + "|" + GlobalVars.Instance.player1.cabello + "|" + GlobalVars.Instance.player1.pantalon + "|" + GlobalVars.Instance.player1.ropa + "|" + GlobalVars.Instance.player1.sombrero);

            form.AddField("token", token);
            form.AddField("nombre", nombre);
            form.AddField("email", email);
            form.AddField("psw", psw);
            form.AddField("idZona", idZona);
            form.AddField("idFacebook", idFacebook);
            form.AddField("avatar", avatar);
            form.AddField("coins", coins);
            form.AddField("points", points);

            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone) {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                if (jsonString != null && jsonString.Length > 1) {
                    jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                    JSONObject dataJSON = new JSONObject(jsonString);
                    entrada.onSetUserResult(dataJSON);
                } else { showError(www.error); }
            } else { showError(www.error); }
        }
    }

 ///----------------------------------------------------------------------------

    public void LoadUsers(string idZona)
    {
        Debug.Log("SetClasificacion - LoadUsers");
        service_type = "LoadUsers";
        if (!InternetAccess())
        {
            try { errorMessage.SetError("Error", "Sumercé se cayó el internet! \n  revise su conexión!"); } catch { }
        }
        else
        {
            key = servicesURL + "getUsers.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            idZona = encrypt.EncryptString(idZona);
            StartCoroutine(LoadUsersPOST(idZona, token));
        }
    }

    public IEnumerator LoadUsersPOST(string idZona, string token)
    {
        if (!isProcessing) {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();

            form.AddField("idZona", idZona);
            form.AddField("token", token);

            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone) {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1) {
                    Debug.Log("SetClasificacion - LoadUsersPOST");
                    JSONObject dataJSON = new JSONObject(jsonString);
                    clasificacionManager.onCommunicatorResult(dataJSON);
                } else { showError(www.error); }
            } else { showError(www.error); }
        }
    }

 ///----------------------------------------------------------------------------

    public void updateUserPoints()
    {
        if (!InternetAccess())
        {
            try { errorMessage.SetError("Error", "Sumercé se cayó el internet! \n  revise su conexión!"); } catch { }
        }
        else
        {
            service_type = "setUserPoints";
            key = servicesURL + "setUser.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(LoadingXPOST(token));
        }
    }

    public IEnumerator LoadingXPOST(string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();

            form.AddField("token", token);
            form.AddField("nombre", GlobalVars.Instance.player1.nombre);
            form.AddField("idUser", encrypt.EncryptString(GlobalVars.Instance.player1.idUser));
            form.AddField("idFacebook", encrypt.EncryptString(GlobalVars.Instance.player1.idFacebook));
            form.AddField("email", encrypt.EncryptString(GlobalVars.Instance.player1.email));
            form.AddField("avatar", encrypt.EncryptString(GlobalVars.Instance.player1.genero + "|" + GlobalVars.Instance.player1.cuerpo + "|" + GlobalVars.Instance.player1.cara + "|" + GlobalVars.Instance.player1.cabello + "|" + GlobalVars.Instance.player1.pantalon + "|" + GlobalVars.Instance.player1.ropa + "|" + GlobalVars.Instance.player1.sombrero));
            form.AddField("coins", encrypt.EncryptString(GlobalVars.Instance.coins.ToString()));
            form.AddField("points", encrypt.EncryptString(GlobalVars.Instance.points.ToString()));
            form.AddField("idZona", encrypt.EncryptString(GlobalVars.Instance.idZona.ToString()));

            form.AddField("currentMundo", encrypt.EncryptString(GlobalVars.Instance.currentMundo.ToString()));
            form.AddField("nivel", encrypt.EncryptString(GlobalVars.Instance.nivel.ToString()));
            form.AddField("numWord", encrypt.EncryptString(GlobalVars.Instance.numWord.ToString()));
            form.AddField("trofeos", encrypt.EncryptString(GlobalVars.Instance.hasPolaOro.ToString() + "|" + GlobalVars.Instance.hasMechaOro.ToString() + "|" + GlobalVars.Instance.hasSuperBocin.ToString() + "|" + GlobalVars.Instance.hasGallina.ToString() + "|" + GlobalVars.Instance.hasPetacoOro.ToString() + "|" + GlobalVars.Instance.hasCabezaLechona.ToString() + "|" + GlobalVars.Instance.hasCariador.ToString() + "|" + GlobalVars.Instance.hasBofeOro.ToString() + "|" + GlobalVars.Instance.hasFritanga.ToString()));

            try { form.AddField("starsString", encrypt.EncryptString(GlobalVars.Instance.starsString.ToString()));
            } catch { form.AddField("starsString", ""); }

            form.AddField("reto", encrypt.EncryptString(GlobalVars.Instance.reto_number.ToString()));
            if (GlobalVars.Instance.device == "Android")
            {
                form.AddField("version", encrypt.EncryptString(GlobalVars.Instance.androidVersion));
            }
            else
            {
                form.AddField("version", encrypt.EncryptString(GlobalVars.Instance.iosVersion));
            }
            form.AddField("SO", encrypt.EncryptString(GlobalVars.Instance.device));

            UnityWebRequest www = UnityWebRequest.Post(url, form);

            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    Debug.Log("service_type: " + service_type);
                    header.onPointsResult(dataJSON);
                }
                else
                {
                    showError(www.error);
                }
            }
            else
            {
                showError(www.error);
            }
        }
    }

    ///----------------------------------------------------------------------------
    
    public void updateUserCoins()
    {
        if (!InternetAccess())
        {
            try { errorMessage.SetError("Error", "Sumercé se cayó el internet! \n  revise su conexión!"); } catch { }
        }
        else
        {
            service_type = "setUserCoins";
            key = servicesURL + "setUser.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(LoadingPOST(token));
        }
    }

    public IEnumerator LoadingPOST(string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();

            form.AddField("token", token);
            form.AddField("nombre", encrypt.EncryptString(GlobalVars.Instance.player1.nombre));
            form.AddField("idUser", encrypt.EncryptString(GlobalVars.Instance.player1.idUser));
            form.AddField("idFacebook", encrypt.EncryptString(GlobalVars.Instance.player1.idFacebook));
            form.AddField("email", encrypt.EncryptString(GlobalVars.Instance.player1.email));
            form.AddField("avatar", encrypt.EncryptString(GlobalVars.Instance.player1.genero + "|" + GlobalVars.Instance.player1.cuerpo + "|" + GlobalVars.Instance.player1.cara + "|" + GlobalVars.Instance.player1.cabello + "|" + GlobalVars.Instance.player1.pantalon + "|" + GlobalVars.Instance.player1.ropa + "|" + GlobalVars.Instance.player1.sombrero));
            form.AddField("coins", encrypt.EncryptString(GlobalVars.Instance.coins.ToString()));
            form.AddField("points", encrypt.EncryptString(GlobalVars.Instance.points.ToString()));
            form.AddField("idZona", encrypt.EncryptString(GlobalVars.Instance.idZona.ToString()));

            form.AddField("currentMundo", encrypt.EncryptString(GlobalVars.Instance.currentMundo.ToString()));
            form.AddField("nivel", encrypt.EncryptString(GlobalVars.Instance.nivel.ToString()));
            form.AddField("numWord", encrypt.EncryptString(GlobalVars.Instance.numWord.ToString()));
            form.AddField("trofeos", encrypt.EncryptString(GlobalVars.Instance.hasPolaOro.ToString() + "|" + GlobalVars.Instance.hasMechaOro.ToString() + "|" + GlobalVars.Instance.hasSuperBocin.ToString() + "|" + GlobalVars.Instance.hasGallina.ToString() + "|" + GlobalVars.Instance.hasPetacoOro.ToString() + "|" + GlobalVars.Instance.hasCabezaLechona.ToString() + "|" + GlobalVars.Instance.hasCariador.ToString() + "|" + GlobalVars.Instance.hasBofeOro.ToString() + "|" + GlobalVars.Instance.hasFritanga.ToString()));

            try{
                form.AddField("starsString", encrypt.EncryptString(GlobalVars.Instance.starsString.ToString()));
            }
            catch
            {
                form.AddField("starsString", "");
            }
            
            form.AddField("reto", encrypt.EncryptString(GlobalVars.Instance.reto_number.ToString()));

            if (GlobalVars.Instance.device == "Android")
            {
                form.AddField("version", encrypt.EncryptString(GlobalVars.Instance.androidVersion));
            }
            else
            {
                form.AddField("version", encrypt.EncryptString(GlobalVars.Instance.iosVersion));
            }
            form.AddField("SO", encrypt.EncryptString(GlobalVars.Instance.device));

            UnityWebRequest www = UnityWebRequest.Post(url, form);

            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    Debug.Log("service_type: " + service_type);
                    header.onCoinsResult(dataJSON);
                }
                else
                {
                    showError(www.error);
                }
            }
            else
            {
                showError(www.error);
            }
        }
    }

   

    ///----------------------------------------------------------------------------

    public void setUserAvatar()
    {
        service_type = "setUserAvatar";
        if (!InternetAccess())
        {
            try { errorMessage.SetError("Error", "Sumercé se cayó el internet! \n  revise su conexión!"); } catch { }
        }
        else
        {
            key = servicesURL + "setUserAvatar.php";
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(LoadingUserAvatarPOST(token));
        }
    }

    public IEnumerator LoadingUserAvatarPOST(string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url);
            WWWForm form = new WWWForm();
            form.AddField("token", token);
            form.AddField("idUser", encrypt.EncryptString(GlobalVars.Instance.player1.idUser));
            form.AddField("avatar", encrypt.EncryptString(GlobalVars.Instance.player1.genero + "|" + GlobalVars.Instance.player1.cuerpo + "|" + GlobalVars.Instance.player1.cara + "|" + GlobalVars.Instance.player1.cabello + "|" + GlobalVars.Instance.player1.pantalon + "|" + GlobalVars.Instance.player1.ropa + "|" + GlobalVars.Instance.player1.sombrero));
            
            UnityWebRequest www = UnityWebRequest.Post(url, form);

            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1)
                {
                    JSONObject dataJSON = new JSONObject(jsonString);
                    header.onSetUserResult(dataJSON);
                }
                else
                {
                    showError(www.error);
                }
            }
            else
            {
                showError(www.error);
            }
        }
    }
    ///----------------------------------------------------------------------------

    public void getReto(string idReto)
    {
        if (InternetAccess())
        {
            key = servicesURL + "getReto.php";
            idReto = encrypt.EncryptString(idReto);
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(getRetoPOST(idReto, token));
        }
    }

    private IEnumerator getRetoPOST(string idReto, string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url + " - idReto:" + idReto);
            WWWForm form = new WWWForm();
            form.AddField("idReto", idReto);
            form.AddField("token", token);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1)
                {
                    jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                    JSONObject dataJSON = new JSONObject(jsonString);
                    retoBox.onGetRetoResult(dataJSON);
                }
                else { showError(www.error); }
            }
            else { showError(www.error); }
        }
    }

    ///----------------------------------------------------------------------------

    public void refreshReto(string idReto)
    {
        if (InternetAccess())
        {
            key = servicesURL + "getReto.php";
            idReto = encrypt.EncryptString(idReto);
            string token = encrypt.EncryptString("e5087e631d984dfdb14d0bf33d59ca9dcdb516f253da4dbaae21dff2d86401e6");
            StartCoroutine(refreshRetoPOST(idReto, token));
        }
    }

    private IEnumerator refreshRetoPOST(string idReto, string token)
    {
        if (!isProcessing)
        {
            isProcessing = true;
            string url = GlobalVars.Instance.URL_HOST + key;
            Debug.Log("Loading: " + url + " - idReto:" + idReto);
            WWWForm form = new WWWForm();
            form.AddField("idReto", idReto);
            form.AddField("token", token);
            UnityWebRequest www = UnityWebRequest.Post(url, form);
            yield return www.SendWebRequest();
            if (www.isDone)
            {
                isProcessing = false;
                Debug.Log("Result: " + www.downloadHandler.text);
                string jsonString = www.downloadHandler.text;
                jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                if (jsonString != null && jsonString.Length > 1)
                {
                    jsonString = DecodeEncodedNonAsciiCharacters(jsonString);
                    JSONObject dataJSON = new JSONObject(jsonString);
                    game.OnRefreshRetoResult(dataJSON);
                }
                else { refreshReto(idReto); }
            }
            else { refreshReto(idReto); }
        }
    }

    ///----------------------------------------------------------------------------

    public bool InternetAccess()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet connection!");
            return (false);
        }
        else
        {
            Debug.Log("Internet connection!");
            return (true);
        }
    }

    private void showError(string errorMsg)
    {
        Debug.Log("Connection error : " + errorMsg);
        isProcessing = false;
        loading.SetActive(false);
        errorMessage.SetError("Error", "Sumercé se dañó la conexión \n  intente de nuevo!");
    }

    static string DecodeEncodedNonAsciiCharacters(string value)
    {
        return Regex.Replace(
            value,
            @"\\u(?<Value>[a-fA-F0-9]{4})",
            m => {
                return ((char)int.Parse(m.Groups["Value"].Value, NumberStyles.HexNumber)).ToString();
            });
    }

}
