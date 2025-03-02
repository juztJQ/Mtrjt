using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TejoScene : MonoBehaviour
{
    public ErrorMessage errorMessage;
    public NavigationManager navigationManager;
    public AudioManager audioManager;

    public virtual void Init() {}

    public void CheckInternet()
    {
        Debug.Log("INTERNET: " + InternetOn());
        if (!InternetOn())
        {
            SetInternetError();
        }
    }

    public bool InternetOn()
    {
        return (!(Application.internetReachability == NetworkReachability.NotReachable));
    }

    public void SetInternetError()
    {
        errorMessage.SetInternetError();
    }

    public void SetError(string title, string content)
    {
        errorMessage.SetError(title, content);
    }
}
