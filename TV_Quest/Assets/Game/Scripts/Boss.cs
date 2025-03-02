using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public Sprite[] bosses;
    public string nombre;
    public Text nombreText;

    public void SetBoss(int _currentBoss, bool _isUI=true)
    {
        nombre = GlobalVars.Instance.nivel1[((_currentBoss +1) * 9)-1].nombre;

        if (_isUI)
        {
            GetComponent<Image>().sprite = bosses[_currentBoss];
            nombreText.text = nombre;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = bosses[_currentBoss];
        }
    }
}
