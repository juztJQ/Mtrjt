using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupDisclaimer : MonoBehaviour
{
    public NavigationManager navigationManager;
    public Entrada_UIManager uiManager;

    public void jugarAsi()
    {
        navigationManager.goEntrada();
        this.gameObject.SetActive(false);
    }

    public void registrarme()
    {
        uiManager.setPopupLogin();
        this.gameObject.SetActive(false);
    }

    public void closePopup()
    {
        this.gameObject.SetActive(false);
    }
}
