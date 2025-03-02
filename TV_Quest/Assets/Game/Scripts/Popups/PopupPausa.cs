using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupPausa : MonoBehaviour
{
    private AudioManager audioManager;
    public NavigationManager navigationManager;
    
    public GameObject popupSalida;
    public GameObject musicaFondoBtn;
    public GameObject efectosSonidoBtn;
    public GameObject vibracionBtn;

    public Sprite switchOn;
    public Sprite switchOff;

    private void Start()
    {
        audioManager    = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (GlobalVars.Instance.backgroundMusicON == 1)
        {
            musicaFondoBtn.GetComponent<Image>().sprite = switchOn;
        }
        else
        {
            musicaFondoBtn.GetComponent<Image>().sprite = switchOff;
        }

        if (GlobalVars.Instance.soundEffectsON == 1)
        {
            efectosSonidoBtn.GetComponent<Image>().sprite = switchOn;
        }
        else
        {
            efectosSonidoBtn.GetComponent<Image>().sprite = switchOff;
        }

        if (GlobalVars.Instance.vibracionON == 1)
        {
            vibracionBtn.GetComponent<Image>().sprite = switchOn;
        }
        else
        {
            vibracionBtn.GetComponent<Image>().sprite = switchOff;
        }
    }

    public void musicaFondoToggle()
    {
        audioManager.SetClick();
        if (GlobalVars.Instance.backgroundMusicON==1)
        {
            musicaFondoBtn.GetComponent<Image>().sprite = switchOff;
            GlobalVars.Instance.backgroundMusicON = 0;
            audioManager.SetBackgroundMusic(false);
        }
        else
        {
            musicaFondoBtn.GetComponent<Image>().sprite = switchOn;
            GlobalVars.Instance.backgroundMusicON = 1;
            audioManager.SetBackgroundMusic(true);
        }
        GlobalVars.Instance.SetCache();
    }
    
    public void efectosSonidoToggle()
    {
        audioManager.SetClick();
        if (GlobalVars.Instance.soundEffectsON==1)
        {
            efectosSonidoBtn.GetComponent<Image>().sprite = switchOff;
        }
        else
        {
            efectosSonidoBtn.GetComponent<Image>().sprite = switchOn;
        }
        GlobalVars.Instance.SoundEffectsToggle();
    }

    public void vibracionToggle()
    {
        audioManager.SetClick();
        if (GlobalVars.Instance.vibracionON == 1)
        {
            efectosSonidoBtn.GetComponent<Image>().sprite = switchOff;
        }
        else
        {
            efectosSonidoBtn.GetComponent<Image>().sprite = switchOn;
        }
        GlobalVars.Instance.VibracionToggle();
    }

    public void closePopup()
    {
        try { popupSalida.SetActive(false); } catch { }
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void SalirJuego()
    {
        audioManager.SetClick();
        popupSalida.SetActive(true);
        this.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Rendirse()
    {
        Time.timeScale = 1;
        GlobalVars.Instance.jumpTo = "MainMenu";
        navigationManager.goEntrada();
    }
}
