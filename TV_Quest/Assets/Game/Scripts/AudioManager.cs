using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource click;
    public AudioSource Nivel0;
    public AudioSource Nivel1;
    public AudioSource Nivel2;
    public AudioSource Nivel3;
    public AudioSource Nivel4;
    public AudioSource Nivel5;
    public AudioSource Nivel6;
    public AudioSource Nivel7;
    public AudioSource Nivel8;
    public AudioSource Lanzamiento;
    public AudioSource Applause;
    public AudioSource Golpe;
    public AudioSource Lose_mano;
    public AudioSource Mecha;
    public AudioSource Win_coin;
    public AudioSource Win_mano;

    public bool controlPlaying = false;

    public SpawnManager spawnManager;

    public void SetBackgroundMusic(bool _opc)
    {
        controlPlaying = false;
        if (_opc) { try { if (spawnManager) { SetNivel(true); }  else { GlobalVars.Instance.SetBackgroundMusic(true); }  } catch { } }
        else {      try { if (spawnManager) { SetNivel(false); } else { GlobalVars.Instance.SetBackgroundMusic(false); } } catch { } }
    }

    public void SetClick() { if ((GlobalVars.Instance.soundEffectsON == 1) && (!click.isPlaying))    click.Play(); }

    public void SetLanzamiento(){ if ((GlobalVars.Instance.soundEffectsON == 1) && (!Lanzamiento.isPlaying))    Lanzamiento.Play(); }
    public void SetApplause()   { if ((GlobalVars.Instance.soundEffectsON == 1) && (!Applause.isPlaying))       Applause.Play(); }
    public void SetGolpe()      { if ((GlobalVars.Instance.soundEffectsON == 1) && (!Golpe.isPlaying))          Golpe.Play(); }
    public void SetLoseMano()   { if ((GlobalVars.Instance.soundEffectsON == 1) && (!Lose_mano.isPlaying))      Lose_mano.Play(); }
    public void SetMecha()      { if ((GlobalVars.Instance.soundEffectsON == 1) && (!Mecha.isPlaying))          Mecha.Play(); }
    public void SetWinCoin()    { if ((GlobalVars.Instance.soundEffectsON == 1) && (!Win_coin.isPlaying))       Win_coin.Play(); }
    public void SetWinMano()    { if ((GlobalVars.Instance.soundEffectsON == 1) && (!Win_mano.isPlaying))       Win_mano.Play(); }

    public void SetNivel(bool _opc)
    {
        if (!controlPlaying)
        {
            GlobalVars.Instance.SetBackgroundMusic(false);
            if (_opc)
            {
                Nivel0.Stop();
                Nivel1.Stop();
                Nivel2.Stop();
                Nivel3.Stop();
                Nivel4.Stop();
                Nivel5.Stop();
                Nivel6.Stop();
                Nivel7.Stop();
                Nivel8.Stop();

                int nivelAJugar = 0;
                if (GlobalVars.Instance.gameType == "Campeonato") {     nivelAJugar = GlobalVars.Instance.currentNivel; }
                else if (GlobalVars.Instance.gameType == "Reto")  {     nivelAJugar = GlobalVars.Instance.reto_idRegion; }
                else if (GlobalVars.Instance.gameType == "Training") {  nivelAJugar = 0; }

                if (GlobalVars.Instance.backgroundMusicON == 1)
                {  
                    switch (nivelAJugar)
                    {
                        case 0: Nivel0.Play(); break;
                        case 1: Nivel1.Play(); break;
                        case 2: Nivel2.Play(); break;
                        case 3: Nivel3.Play(); break;
                        case 4: Nivel4.Play(); break;
                        case 5: Nivel5.Play(); break;
                        case 6: Nivel6.Play(); break;
                        case 7: Nivel7.Play(); break;
                        case 8: Nivel8.Play(); break;
                    }
                }
            }
            else
            {
                Nivel0.Stop();
                Nivel1.Stop();
                Nivel2.Stop();
                Nivel3.Stop();
                Nivel4.Stop();
                Nivel5.Stop();
                Nivel6.Stop();
                Nivel7.Stop();
                Nivel8.Stop();
            }
            controlPlaying = true;
        }
    }
}
