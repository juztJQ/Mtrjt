using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nivel : MonoBehaviour
{
    public Text nivel_txt;
    public ProgressBar nivel_bar;
    public ProgressBar nivel_bar2;

    private int points;
    private int progress_init;
    private int progress_end;

    private int countXP = 0;
    private int maxXP = 177289847;
    private int xp = 0;
    private int progress;
    private int init;
    private int end;

    private Color normalColor;

    public bool countingXPTEST = false;

    public void Start()
    {
        
    }

    public void Update()
    {
        
        SetNivel();
        
        if (countingXPTEST)
        {
            SetProgress();
            UpdateNumXP();
        }
        
    }

    public void SetNivel()
    {
        nivel_txt.text  = "Nivel: " + GlobalVars.Instance.progress.ToString();
        points          = GlobalVars.Instance.points;
        progress_init   = GlobalVars.Instance.progress_init;
        progress_end    = GlobalVars.Instance.progress_end;
        
        if((progress_end - progress_init) > 0)
        {
            double progres_en_nivel = 100 - ((progress_end - points) * 100) / (progress_end - progress_init);
            nivel_bar.SetProgressBar((float)progres_en_nivel);
        } 
    }

    public void Blink182()
    {
        nivel_bar2.gameObject.SetActive(true);
        if ((progress_end - progress_init) > 0)
        {
            double progres_en_nivel = 100 - ((progress_end - points) * 100) / (progress_end - progress_init);
            nivel_bar2.SetProgressBar((float)progres_en_nivel);
        }
        StartCoroutine(SetBlink());
    }

    IEnumerator SetBlink()
    {
        yield return new WaitForSeconds(0.02f);
        nivel_bar2.gameObject.SetActive(false);
    }

    // -------------------------------- TEST --------------------------------- //

    public void StartTest()
    {
        countingXPTEST = true;
    }

    public void UpdateNumXP()
    {
        if (xp < maxXP)
        {
            xp += 180;
            StartCoroutine(SetPulseXP());
        }
        else
        {
            countingXPTEST = false;
        }
    }

    IEnumerator SetPulseXP()
    {
        if (countXP <= maxXP)
        {
            SetNivel();
        }
        yield return new WaitForSeconds(0.02f);
    }

    private void SetProgress()
    {
        int[] aMinin = {0, 50, 61, 74, 90, 109, 132, 160, 194, 235, 284, 344, 416, 503, 609, 737, 892, 1079, 1306, 1580, 1912, 2314, 2800, 3388, 4099, 4960, 6002, 7262, 8787, 10632, 12865, 15567, 18836, 22792, 27578, 33369, 40376, 48855, 59115, 71529, 86550, 104726, 126718, 153329, 185528, 224489, 271632, 328675, 397697, 481213, 582268, 704544, 852498, 1031523, 1248143, 1510253, 1827406, 2211161, 2675505, 3237361, 3917207, 4739820, 5735182, 6939570, 8396880, 10160225, 12293872, 14875585, 17999458, 21779344, 26353006, 31887137, 38583436, 46685958, 56490009, 68352911, 82707022, 100075497, 121091351, 146520535};
        int[] aMax = {50, 61, 74, 90, 109, 132, 160, 194, 235, 284, 344, 416, 503, 609, 737, 892, 1079, 1306, 1580, 1912, 2314, 2800, 3388, 4099, 4960, 6002, 7262, 8787, 10632, 12865, 15567, 18836, 22792, 27578, 33369, 40376, 48855, 59115, 71529, 86550, 104726, 126718, 153329, 185528, 224489, 271632, 328675, 397697, 481213, 582268, 704544, 852498, 1031523, 1248143, 1510253, 1827406, 2211161, 2675505, 3237361, 3917207, 4739820, 5735182, 6939570, 8396880, 10160225, 12293872, 14875585, 17999458, 21779344, 26353006, 31887137, 38583436, 46685958, 56490009, 68352911, 82707022, 100075497, 121091351, 146520535, 177289847};
        for(int i=0; i<= aMinin.Length-1; i++)
        {
            if ((xp > aMinin[i]) && (xp <= aMax[i])) { progress = (i+1); init = aMinin[i]; end = aMax[i]; }
        }
    }
}
