using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Developer : MonoBehaviour
{
    public Button reset_btn;
    public Text currentMundo;
    public Text nivel;
    public Text currentNivel;
    public Text numWorld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentMundo.text = "currentMundo: " + GlobalVars.Instance.currentMundo;
        nivel.text = "nivel: " + GlobalVars.Instance.nivel;
        currentNivel.text = "currentNivel: " + GlobalVars.Instance.currentNivel;
        numWorld.text = "numWord: " + GlobalVars.Instance.numWord;
    }

    public void SetDeveloper()
    {
        this.gameObject.SetActive(true);
    }

    public void ResetScores()
    {
        GlobalVars.Instance.ResetAll();
        this.gameObject.SetActive(false);
    }
}
