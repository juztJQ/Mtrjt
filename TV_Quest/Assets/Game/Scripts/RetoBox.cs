using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetoBox : MonoBehaviour
{
    public Entrada_UIManager uiManager;
    public AvatarWeb avatarWeb;
    public Text municipio_txt;
    public Text departamento_txt;
    public Text reto_text;
    public Text reto_titulo_text;
    public Communicator communicator;

    public void SetRetoBox()
    {
        communicator.getReto(GlobalVars.Instance.reto.ToString());
    }

    public void onGetRetoResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        Debug.Log(result.GetField("status").str);

        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.reto_avatar         = result.GetField("avatar").str;
            GlobalVars.Instance.reto_municipio      = result.GetField("municipio").str;
            GlobalVars.Instance.reto_departamento   = result.GetField("departamento").str;
            GlobalVars.Instance.reto_idRegion       = int.Parse(result.GetField("idRegion").str);
            GlobalVars.Instance.reto_number         = int.Parse(result.GetField("game_order").str);
            GlobalVars.Instance.reto_level          = int.Parse(result.GetField("level").str);

            string[] avatar         = GlobalVars.Instance.reto_avatar.Split(char.Parse("|"));
            municipio_txt.text      = GlobalVars.Instance.reto_municipio;
            departamento_txt.text   = GlobalVars.Instance.reto_departamento;
            reto_text.text          = "Reto " + GlobalVars.Instance.reto_number.ToString();
            reto_titulo_text.text   = "Reto " + GlobalVars.Instance.reto_number.ToString();

            avatarWeb.setAvatar(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]));
            uiManager.setEnemyAvatar(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]), result.GetField("municipio").str);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        uiManager.loadPromo();
    }

}
