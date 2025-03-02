using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen_UIManager : MonoBehaviour
{
    public Text conectando;
    public GameObject conectandoObj;

    public void SetText(string _text)
    {
        conectando.text = _text;
        conectandoObj.SetActive(true);
    }
}
