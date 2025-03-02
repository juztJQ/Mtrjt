using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBox : MonoBehaviour
{
    public PopupFinJuego popupFinJuego;
    public GameObject XPJumpPrefab;
    public GameObject xp;
    public GameObject nuevo_nivel;
    public Header header;

    public Text ganados;
    public bool isTiming = false;
    public bool counting = false;

    public int count = 0;
    public int countGanados = 0;
    public int max = 0;

    public void onAnimate()
    {
        isTiming = true;
    }

    private void Update()
    {
        if (isTiming)
        {
            UpdateNum();
        }
    }

    public void SetXP(int _XP)
    {
        max = _XP;
        xp.SetActive(true);
        this.GetComponent<Animator>().SetBool("enter", true);
    }

    public void UpdateNum()
    {
        if (countGanados < max)
        {
            countGanados++;
            StartCoroutine(SetPulse());
        }
        else
        {
            StartCoroutine(wait());
        }
    }

    public void SetNuevoNivel()
    {
        nuevo_nivel.gameObject.SetActive(true);
        nuevo_nivel.GetComponent<Text>().text = "NIVEL " + GlobalVars.Instance.progress;
        xp.gameObject.SetActive(false);
        ganados.gameObject.SetActive(false);
        StartCoroutine(WaitNuevoNivel());
    }

    IEnumerator WaitNuevoNivel()
    {
        yield return new WaitForSeconds(4f);
        popupFinJuego.SetPopupAsset();
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        isTiming = false;
        if (!counting)
        {
            header.SetXP(countGanados);
            counting = true;
        }
    }

    IEnumerator SetPulse()
    {
        ganados.text = countGanados.ToString();
        //GameObject CoinAnim = Instantiate(XPJumpPrefab, transform.position, Quaternion.identity);
        //CoinAnim.transform.parent = xp.transform;
        yield return new WaitForSeconds(0.1f);
    }

}
