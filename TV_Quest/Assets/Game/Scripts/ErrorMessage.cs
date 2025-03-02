using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessage : MonoBehaviour
{
    public TejoScene tejoScene;
    public Text title;
    public Text subtitle;
    public GameObject listoBtn;
    public GameObject intentarBtn;
    public Text actionButtonText;

    private string url = "";

    public void SetError(string _title, string _subtitle)
    {
        this.url = "";
        this.title.text = _title;
        this.subtitle.text = _subtitle;
        listoBtn.SetActive(true);
        intentarBtn.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void SetErrorURL(string _title, string _subtitle, string buttonText, string url)
    {
        this.url = url;
        this.title.text = _title;
        this.subtitle.text = _subtitle;
        this.actionButtonText.text = buttonText;
        listoBtn.SetActive(true);
        intentarBtn.SetActive(false);
        this.gameObject.SetActive(true);
    }

    public void SetInternetError()
    {
        this.url = "";
        this.title.text = "Sin Internet";
        this.subtitle.text = "Parece hay problemas \n con la conexión a internet\n Peguese a una waifei (wifi)!";
        listoBtn.SetActive(false);
        intentarBtn.SetActive(true);
        this.gameObject.SetActive(true);
    }

    public void CloseError()
    {
        if(url != "")
        {
            Application.OpenURL(url);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        
    }

    public void TryInternet()
    {
        intentarBtn.SetActive(false);
        NavigationManager navigationManager = FindObjectOfType<NavigationManager>();
        navigationManager.goSplash();
    }
}
