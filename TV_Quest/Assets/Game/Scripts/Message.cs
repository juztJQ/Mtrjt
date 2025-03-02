using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public Game_UIManager uiManager;
    public Text tituloDisplay;
    public Text mensajeDisplay;

    private float duration;

    public void SetMessage(string _titulo, string _mensaje, float _duration)
    {
        this.gameObject.SetActive(true);
        duration = _duration;
        tituloDisplay.text = _titulo;
        mensajeDisplay.text = _mensaje;
        if (duration > 0)
        {
            StartCoroutine(ClearMessage());
        }
    }

    IEnumerator ClearMessage()
    {
        yield return new WaitForSeconds(duration);
        if (uiManager)
        {
            uiManager.HideMessage();
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
