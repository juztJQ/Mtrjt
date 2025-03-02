using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MundoItem : MonoBehaviour
{
    public int world;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public Sprite starOn;

    public GameObject copa;
    public Text numWord;

    void Start()
    {
        SetEnable(false);
        if ((world == 9) || (world == 18) || (world == 27) || (world == 36) || (world == 45) || (world == 54) || (world == 63) || (world == 72) || (world == 81))
        {
            copa.SetActive(true);
            numWord.text = "";
        }
        else
        {
            copa.SetActive(false);
            numWord.text = ""+world;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (world <= GlobalVars.Instance.numWord)
        {
            if(world < GlobalVars.Instance.numWord)
            {
                SetEnable(true, GlobalVars.Instance.wordStars[(world-1)]);  
            }
            else
            {
                SetEnable(true);
            }            
        }
        else
        {
            SetEnable(false);
        }
    }

    public void SetEnable(bool _enable, int _stars=0)
    {
        if (_enable)
        {
            SetTransparent(this.gameObject, false);
            SetTransparent(copa, false);
			SetStars(_stars);    
		}
		else
        {
            SetTransparent(this.gameObject, true);
            SetTransparent(copa, true);
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }

    private void SetTransparent(GameObject objeto, bool _transparent)
    {
        if (_transparent)
        {
            var tempColor = objeto.GetComponent<Image>().color;
            tempColor.a = 0.2f;
            objeto.GetComponent<Image>().color = tempColor;
        }
        else
        {
            var tempColor = objeto.GetComponent<Image>().color;
            tempColor.a = 1f;
            objeto.GetComponent<Image>().color = tempColor;
        }
    }

    public void SetStars(int _num)
    {
        star1.SetActive(true);
        star2.SetActive(true);
        star3.SetActive(true);

        switch (_num)
        {
            case 1:
                star1.GetComponent<Image>().sprite = starOn;
                break;
            case 2:
                star1.GetComponent<Image>().sprite = starOn;
                star2.GetComponent<Image>().sprite = starOn;
            break;
            case 3:
                star1.GetComponent<Image>().sprite = starOn;
                star2.GetComponent<Image>().sprite = starOn;
                star3.GetComponent<Image>().sprite = starOn;
            break;
        }
    }
}
