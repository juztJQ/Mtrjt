using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsBox : MonoBehaviour
{
    public GameObject CoinJumpPrefab;
    public GameObject coin;

    public Header header;
    public Text titulo;
    public Text valor;
    public Text ganados;
    public bool isTiming = false;
    public bool counting = false;

    public int count = 0;
    public int countGanados = 0;
    public int max = 0;
    
    private int manos;
    private int mechas;
    private int bocines;
    private int mononas;
    private int bonus;

    private int multiplier = 1;
    public int step = 0;

    public void onAnimate()
    {
        checkStep();
    }

    private void Update()
    {
        if (!isTiming && counting)
        {
            UpdateNum();
            isTiming = true;
        }
    }

    public void SetCoins(int _manos, int _mechas, int _bocines, int _mononas, int _bonus = 0)
    {
        coin.SetActive(true);
        manos = _manos;
        mechas = _mechas;
        bocines = _bocines;
        mononas = _mononas;
        bonus = _bonus;
        this.GetComponent<Animator>().SetBool("enter", true);
    }

    public void UpdateNum()
    {
        if (count < max)
        {
            count++;
            countGanados += (10 * multiplier);
            StartCoroutine(SetPulse());
        }
        else
        {
            StartCoroutine(wait());
        }
    }

    IEnumerator SetPulse()
    {
        valor.text = count.ToString();
        ganados.text = countGanados.ToString();
        GameObject CoinAnim = Instantiate(CoinJumpPrefab, transform.position, Quaternion.identity);
        CoinAnim.transform.SetParent(coin.transform);
        yield return new WaitForSeconds(0.1f);
        isTiming = false;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        step++;
        counting = false;
        isTiming = false;
        checkStep();
    }

    private void checkStep()
    {
        switch (step)
        {
            case 0:
                if (manos > 0)
                {
                    multiplier = 1;
                    titulo.text = "Manos:";
                    count = 0;
                    max = manos;
                    counting = true;
                }
                else
                {
                    step++;
                    counting = false;
                    isTiming = false;
                    checkStep();
                }
                break;
            case 1:
                if (mechas > 0)
                {
                    multiplier = 3;
                    titulo.text = "Mechas:";
                    count = 0;
                    max = mechas;
                    counting = true;
                }
                else
                {
                    step++;
                    counting = false;
                    isTiming = false;
                    checkStep();
                }
                break;
            case 2:
                if (bocines > 0)
                {
                    multiplier = 6;
                    titulo.text = "Bocines:";
                    count = 0;
                    max = bocines;
                    counting = true;
                }
                else
                {
                    step++;
                    counting = false;
                    isTiming = false;
                    checkStep();
                }
                break;
            case 3:
                if (mononas > 0)
                {
                    multiplier = 9;
                    titulo.text = "Moñonas:";
                    count = 0;
                    max = mononas;
                    counting = true;
                }
                else
                {
                    step++;
                    counting = false;
                    isTiming = false;
                    checkStep();
                }
                break;
            case 4:
                if (bonus > 0)
                {
                    multiplier = 10;
                    titulo.text = "Chico Online:";
                    count = 0;
                    max = bonus;
                    counting = true;
                }
                else
                {
                    step++;
                    counting = false;
                    isTiming = false;
                    checkStep();
                }
                break;
            case 5:
                titulo.text = "";
                valor.text = "";
                step++;
                checkStep();
                break;
            case 6:
                header.SetCoins(countGanados);
                Debug.Log("::: Fin Coins");
                break;

            default:
                Destroy(this.gameObject, 0.5f);
                break;
        }
    }
}
