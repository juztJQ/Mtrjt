using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupFinJuego : MonoBehaviour
{
    public Game_UIManager uiManager;
    public CoinsBox coinsBox;
    public XPBox xpBox;
    public AssetBox assetBox;
    public TrofeoBox trofeoBox;
    private int manos;
    private int mechas;
    private int bocines;
    private int mononas;
    private int bonus;
    private int puntosTraining;

    public void SetPopupFinJuego(int _manos, int _mechas, int _bocines, int _mononas, int _bonus = 0)
    {
        manos = _manos;
        mechas = _mechas;
        bocines = _bocines;
        mononas = _mononas;
        bonus = _bonus;
        coinsBox.SetCoins(manos, mechas, bocines, mononas, bonus);
    }

    public void SetPopupFinJuegoTraining(int _puntosTraining)
    {
        puntosTraining = _puntosTraining;
        SetPopupNext();
    }

    public void SetPopupNext()
    {
        coinsBox.GetComponent<Animator>().SetBool("enter", false);
        if (GlobalVars.Instance.gameType == "Campeonato")
        {
            Debug.Log("ShowRateUs ? GlobalVars.Instance.numWord: " + GlobalVars.Instance.numWord);
            if ((GlobalVars.Instance.numWord == 6) || (GlobalVars.Instance.numWord == 26) || (GlobalVars.Instance.numWord == 46) || (GlobalVars.Instance.numWord == 66)) { uiManager.ShowRateUs(); }

            int xp = ((GlobalVars.Instance.currentNivel + 1) * 100) / 9;
            xp = xp + (mononas * 9);
            xp = xp + (bocines * 6);
            xp = xp + (mechas * 3);
            xpBox.SetXP(xp);
        }
        else if (GlobalVars.Instance.gameType == "Reto")
        {
            Debug.Log("ShowRateUs ? GlobalVars.Instance.reto_number: " + GlobalVars.Instance.reto_number);
            if ((GlobalVars.Instance.reto_number == 11) || (GlobalVars.Instance.reto_number == 33) || (GlobalVars.Instance.reto_number == 55) || (GlobalVars.Instance.reto_number == 77) || (GlobalVars.Instance.reto_number == 99) || (GlobalVars.Instance.reto_number == 200) || (GlobalVars.Instance.reto_number == 400) || (GlobalVars.Instance.reto_number == 600) || (GlobalVars.Instance.reto_number == 900) || (GlobalVars.Instance.reto_number == 1000) || (GlobalVars.Instance.reto_number == 1500) || (GlobalVars.Instance.reto_number == 2000) || (GlobalVars.Instance.reto_number == 2250) || (GlobalVars.Instance.reto_number == 3000)) { uiManager.ShowRateUs(); }
            int xp = ((GlobalVars.Instance.reto_level +1) * 100) / 9;
            xp = xp + (GlobalVars.Instance.reto_number-1);
            xp = xp + (mononas * 9);
            xp = xp + (bocines * 6);
            xp = xp + (mechas * 3);
            xpBox.SetXP(xp);
        }
        else if (GlobalVars.Instance.gameType == "Training")
        {
            int xp = puntosTraining;
            xpBox.SetXP(xp);
        }
    }

    public void SetNuevoNivel()
    {
        xpBox.SetNuevoNivel();
    }

    public void SetPopupAsset()
    {
        xpBox.GetComponent<Animator>().SetBool("enter", false);
        if (GlobalVars.Instance.gameType == "Campeonato")
        {
            if ((GlobalVars.Instance.numWord == 4) || (GlobalVars.Instance.numWord == 16) || (GlobalVars.Instance.numWord == 31) || (GlobalVars.Instance.numWord == 43) || (GlobalVars.Instance.numWord == 58) || (GlobalVars.Instance.numWord == 7) || (GlobalVars.Instance.numWord == 22) || (GlobalVars.Instance.numWord == 34) || (GlobalVars.Instance.numWord == 49) || (GlobalVars.Instance.numWord == 61) || (GlobalVars.Instance.numWord == 13) || (GlobalVars.Instance.numWord == 25) || (GlobalVars.Instance.numWord == 40) || (GlobalVars.Instance.numWord == 52) || (GlobalVars.Instance.numWord == 67))
            {
                assetBox.SetAsset();
            }
            else
            {
                SetPopupTrofeo();
            }
        }
        else if (GlobalVars.Instance.gameType == "Reto")
        {
            ClosePopup();
        }
        else if (GlobalVars.Instance.gameType == "Training")
        {
            ClosePopup();
        }
    }

    public void SetPopupTrofeo()
    {
        xpBox.GetComponent<Animator>().SetBool("enter", false);
        if (GlobalVars.Instance.gameType == "Campeonato")
        {
            if ((GlobalVars.Instance.numWord == 10) || (GlobalVars.Instance.numWord == 19) || (GlobalVars.Instance.numWord == 28) || (GlobalVars.Instance.numWord == 37) || (GlobalVars.Instance.numWord == 46) || (GlobalVars.Instance.numWord == 55) || (GlobalVars.Instance.numWord == 64) || (GlobalVars.Instance.numWord == 73) || (GlobalVars.Instance.numWord == 82))
            {
                trofeoBox.SetPopupTrofeo();
            }
            else
            {
                ClosePopup();
            }   
        }
        else if (GlobalVars.Instance.gameType == "Reto")
        {
            ClosePopup();
        }
        else if (GlobalVars.Instance.gameType == "Training")
        {
            ClosePopup();
        }
    }

    public void ClosePopup()
    {
        this.gameObject.SetActive(false);
        uiManager.SetSiguiente();
    }

}
