using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public GameObject CoinJumpPrefab;
    public GameObject XPJumpPrefab;
    public GameObject coin;
    public GameObject xp;

    public Header header;
    public Text titulo;
    public Text valor;
    public Text ganados;
    public bool isTiming = false;
    public bool counting = false;

    private string PuntosType;
    private int count = 0;
    private int countGanados = 0;
    private int max = 0;

    public int manos;
    public int mechas;
    public int bocines;
    public int mononas;
    public int bonus;

    private int multiplier = 1;

    public int step = 0;
    private int fullStep = 0;
    private bool isFullXP = false;


    private void Update()
    {
        if (!isTiming && counting && !isFullXP)
        {
            UpdateNum();
            isTiming = true;
        }else if (!isTiming && counting && isFullXP)
        {
            SetXPulse();
            isTiming = true;
        }
    }

    public void SetCoins(int _manos, int _mechas, int _bocines, int _mononas, int _bonus=0)
    {
        PuntosType = "Coins";
        coin.SetActive(true);
        xp.SetActive(false);
        manos   = _manos;
        mechas  = _mechas;
        bocines = _bocines;
        mononas = _mononas;
        bonus = _bonus;
        checkStep();
    }

    public void SetXP(int _manos, int _mechas, int _bocines, int _mononas, int _bonus = 0)
    {
        PuntosType = "XP";
        coin.SetActive(false);
        xp.SetActive(true);
        manos = _manos;
        mechas = _mechas;
        bocines = _bocines;
        mononas = _mononas;
        bonus = _bonus;
        checkStep();
    }

    public void SetFullXP(int _fullXP)
    {
        coin.SetActive(false);
        xp.SetActive(true);
        fullStep = GlobalVars.Instance.points;
        count = 0;
        isFullXP = true;
    }

    IEnumerator SetXPulse()
    {
        valor.text = "";
        ganados.text = count.ToString();
        GameObject XPAnim = Instantiate(XPJumpPrefab, transform.position, Quaternion.identity);
        XPAnim.transform.parent = xp.transform;
        
        yield return new WaitForSeconds(0.1f);
        isTiming = false;
    }

    public void UpdateNum()
    {
        if(count < max)
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
        if (PuntosType == "Coins")
        {
            GameObject CoinAnim = Instantiate(CoinJumpPrefab, transform.position, Quaternion.identity);
            CoinAnim.transform.parent = coin.transform;
        }
        else
        {
            GameObject XPAnim = Instantiate(XPJumpPrefab, transform.position, Quaternion.identity);
            XPAnim.transform.parent = xp.transform;
        }
        
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
                SetFullXP(countGanados);
            break;
            case 6:
                header.counting = true;
                if (PuntosType == "Coins")
                {
                    header.SetCoins(countGanados);
                }
                else
                {
                    header.SetXP(countGanados);
                }
                step++;
                checkStep();
                break;
            default:
                Destroy(this.gameObject, 0.5f);
            break;
        }
    }
}
