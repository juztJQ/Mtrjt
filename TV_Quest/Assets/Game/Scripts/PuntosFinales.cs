using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntosFinales : MonoBehaviour
{
    public Header header;
    public AudioManager audioManager;
    public Text puntos_finales;
    public Text[] tablero;
    private bool isAnimating = false;

    private int puntos;
    private int puntos_totales;

    private void Update()
    {
        if (isAnimating)
        {
            AnimatePuntos();
        }    
    }

    public void SetPuntos(int puntos)
    {
        if(puntos > 0)
        {
            Debug.Log("SetPuntos: " + puntos);
            puntos_finales.text = "0";
            this.puntos = puntos;
            this.puntos_totales = puntos;
            isAnimating = true;
        }
        else
        {
            header.SetXP(puntos);
        }
    }

    IEnumerator WaitForNextStep()
    {
        yield return new WaitForSeconds(2f);
        if (puntos <= 0)
        {
            isAnimating = false;
            header.SetXP(puntos_totales);
        }
    }

    private void AnimatePuntos()
    {
        if (puntos > 0)
        {
            if (int.Parse(tablero[0].text) > 0)
            {
                tablero[0].text = (int.Parse(tablero[0].text) - 1).ToString();
            }
            else if (int.Parse(tablero[1].text) > 0)
            {
                tablero[1].text = (int.Parse(tablero[1].text) - 1).ToString();
            }
            else if (int.Parse(tablero[2].text) > 0)
            {
                tablero[2].text = (int.Parse(tablero[2].text) - 1).ToString();
            }
            else if (int.Parse(tablero[3].text) > 0)
            {
                tablero[3].text = (int.Parse(tablero[3].text) - 1).ToString();
            }
            else if (int.Parse(tablero[4].text) > 0)
            {
                tablero[4].text = (int.Parse(tablero[4].text) - 1).ToString();
            }
            else if (int.Parse(tablero[5].text) > 0)
            {
                tablero[5].text = (int.Parse(tablero[5].text) - 1).ToString();
            }
            puntos_finales.text = (int.Parse(puntos_finales.text) + 1).ToString();
            puntos--;
            audioManager.SetWinCoin();
            StartCoroutine(WaitForNextStep());
        }
    }
}
