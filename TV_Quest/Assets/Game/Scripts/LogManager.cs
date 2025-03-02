using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogManager : MonoBehaviour
{
    public bool testMode = false;
    public bool internalLog = true;
    public GameObject output;
    public GameObject close;

    void Start()
    {
        
    }

    public void ShowLogManager()
    {
        if (testMode)
        {
            this.gameObject.SetActive(true);
        }
    }

    public void Log(string _newEntry)
    {
        ShowLogManager();
        output.GetComponent<Text>().text = output.GetComponent<Text>().text + "\n" + _newEntry;
        if (internalLog)
        {
            Debug.Log(_newEntry);
        }
    }

    public void HideLogManager()
    {
        this.gameObject.SetActive(false);
    }

    public void CleanLogManager()
    {
        output.GetComponent<Text>().text = "";
    }
}
