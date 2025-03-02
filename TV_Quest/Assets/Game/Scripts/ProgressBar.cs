using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private int maximum = 100;
    public Image mask;

    public void SetProgressBar(float _progress)
    {
       mask.fillAmount = _progress / (float)maximum;
    }
}
