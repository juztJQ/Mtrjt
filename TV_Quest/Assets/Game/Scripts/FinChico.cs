using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinChico : MonoBehaviour
{
    public ADmob oADmob;
    public SpawnManager spawnManager;
    public Game_UIManager uiManager;
    public GameObject versusRojo;
    public GameObject versusAzul;
    public GameObject retoTitulo;
    public Text retoTitulo_text;
    public GameObject resultados_textos;
    public GameObject player1;
    public GameObject player2;

    public Text winner_text;
    public Text loser_text;
    public Stars stars;
    public Puntos puntos;
    public PopupFinJuego popupFinJuego;
    public GameObject content;

    public GameObject background;
    public GameObject ScoreTraining;
    public GameObject PlayerBoxTraining;
    
    private int score1 = 0;
    private int score2 = 0;
    private int numManos = 0;
    private int numMechas = 0;
    private int numBocines = 0;
    private int numMononas = 0;

    public int starsNum = 0;

    public void SetFinChico(int _score1, int _score2, int _numManos, int _numMechas, int _numBocines, int _numMononas)
    {
        uiManager.CleanUI();
        oADmob.Start();
        score1      = _score1;
        score2      = _score2;
        //Debug.Log("FinChico :: SetFinChico :: score1:" + score1 + " :: score2:" + score2 + "");
        numManos    = _numManos;
        numMechas   = _numMechas;
        numBocines  = _numBocines;
        numMononas  = _numMononas;

        versusRojo.GetComponent<Animator>().SetBool("enter", true);
        versusAzul.GetComponent<Animator>().SetBool("enter", true);
        player1.GetComponent<Animator>().SetBool("enter", true);
        player2.GetComponent<Animator>().SetBool("enter", true);
    }

    public void SetFinChicoTraining()
    {
        background.gameObject.SetActive(true);
        ScoreTraining.GetComponent<Animator>().SetBool("enter", true);
        PlayerBoxTraining.GetComponent<Animator>().SetBool("enter", true);
        StartCoroutine(wait());
    }

    public void SetFinChico2Players()
    {
        versusRojo.GetComponent<Animator>().SetBool("enter", true);
        versusAzul.GetComponent<Animator>().SetBool("enter", true);
        player1.GetComponent<Animator>().SetBool("enter", true);
        player2.GetComponent<Animator>().SetBool("enter", true);
        stars.gameObject.SetActive(false);
    }

    public void ShowContent()
    {
        content.SetActive(true);
        //Debug.Log("FinChico :: ShowContent :: score1:" + score1 + " :: score2:" + score2 + "");
        if (score1 > score2)
        {
            //Debug.Log("FinChico :: :::::::::::::: GANAR");
            SetStars(score1, score2);
            winner_text.text = "¡GANADOR!";
            if (GlobalVars.Instance.gameType == "Campeonato"){
                if (GlobalVars.Instance.numWord <= 81)
                {
                    if (GlobalVars.Instance.currentMundo == GlobalVars.Instance.numWord - 1)
                    {
                        //suma nueva estrella
                        int temp = 0;
                        for (int i = 0; i < GlobalVars.Instance.wordStars.Count; i++) { temp++; }
                        GlobalVars.Instance.wordStars.Add(starsNum);
                        temp = 0;
                        for (int i = 0; i < GlobalVars.Instance.wordStars.Count; i++) { temp++; }
                        if (spawnManager.isBoss)
                        {
                            GlobalVars.Instance.nivel++;
                            GlobalVars.Instance.jump = false;
                        }
                        GlobalVars.Instance.numWord++;
                    }
                    else
                    {
                        if (starsNum > GlobalVars.Instance.wordStars[GlobalVars.Instance.currentMundo])
                        {
                            GlobalVars.Instance.wordStars[GlobalVars.Instance.currentMundo] = starsNum;
                        }
                    }
                    stars.SetStars(starsNum);

                    GlobalVars.Instance.starsString = "";
                    for (int i = 0; i < GlobalVars.Instance.wordStars.Count; i++)
                    {
                        if (i == 0) { GlobalVars.Instance.starsString = GlobalVars.Instance.starsString + GlobalVars.Instance.wordStars[i]; }
                        else { GlobalVars.Instance.starsString = GlobalVars.Instance.starsString + "|" + GlobalVars.Instance.wordStars[i]; }
                    }
                }
                GlobalVars.Instance.currentMundo++;
            }
            else if (GlobalVars.Instance.gameType == "Reto")
            {
                retoTitulo_text.text = "Reto " + GlobalVars.Instance.reto_number.ToString();
                resultados_textos.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -171);
                retoTitulo.GetComponent<Animator>().SetBool("enter_reto", true);
                stars.gameObject.SetActive(false);
                GlobalVars.Instance.reto_number++;
            }
            else if (GlobalVars.Instance.gameType == "2Players")
            {
                winner_text.text = "¡FIN DEL CHICO!";
            }
            StartCoroutine(waitADS());
        }
        else
        {
            //Debug.Log("FinChico :: :::::::::::::: PERDER");
            if (GlobalVars.Instance.gameType == "2Players")
            {
                winner_text.text = "¡FIN DEL CHICO!";
            }
            else
            {
                loser_text.text = "PERDISTE";
                stars.gameObject.SetActive(false);
                puntos.gameObject.SetActive(false);
            }
            uiManager.SetAdLoser();
           // uiManager.SetRevancha();
        }
    }

    IEnumerator waitADS()
    {
        yield return new WaitForSeconds(2f);
        //uiManager.SetSiguiente();
        uiManager.SetAdWinner();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        uiManager.SetAdWinner();
    }

    public void SetPopupFinJuego()
    {
        popupFinJuego.gameObject.SetActive(true);
        popupFinJuego.SetPopupFinJuego(numManos, numMechas, numBocines, numMononas);
    }

    public void SetPopupFinJuegoTraining(int puntosTraining)
    {
        popupFinJuego.gameObject.SetActive(true);
        popupFinJuego.SetPopupFinJuegoTraining(puntosTraining);
    }

    private void SetStars(int _score1, int _score2)
    {
        int diff = _score1 - _score2;
        if (diff >= 8)
        {
            starsNum = 3;
        }
        else if ((diff >= 4) && (diff < 8))
        {
            starsNum = 2;
        }
        else
        {
            starsNum = 1;
        }
    }

    public void CloseFinJuego()
    {
        score1 = 0;
        score2 = 0;
        numManos = 0;
        numMechas = 0;
        numBocines = 0;
        numMononas = 0;
        starsNum = 0;

        content.SetActive(false);
        versusRojo.GetComponent<Animator>().SetBool("enter", false);
        versusAzul.GetComponent<Animator>().SetBool("enter", false);
        retoTitulo.GetComponent<Animator>().SetBool("enter_reto", false);
        player1.SetActive(false);
        player2.SetActive(false);
    }

    public void AlargarChico()
    {
        content.SetActive(false);
        versusRojo.GetComponent<Animator>().SetBool("enter", false);
        versusAzul.GetComponent<Animator>().SetBool("enter", false);
        retoTitulo.GetComponent<Animator>().SetBool("enter_reto", false);
        player1.SetActive(true);
        player2.SetActive(true);
        player1.GetComponent<Animator>().SetBool("enter", false);
        player2.GetComponent<Animator>().SetBool("enter", false);
    }
}
