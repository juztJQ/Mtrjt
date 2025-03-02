using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClasificacionManager : MonoBehaviour
{
    public ADmob oADmob;
    public ErrorMessage errorMessage;
    public Communicator communicatorManager;
    public GameObject loading;
    public GameObject items;
    public GameObject popupJugar;

    public Text[] user_nombre;
    public Text[] user_puntos;

    public AvatarWeb avatarWinner1;
    public AvatarWeb avatarWinner2;
    public AvatarWeb avatarWinner3;

    private int currentRegion = 0;

    public void showPopupJugar()
    {
        popupJugar.SetActive(true);
    }

    public void comprarJugar()
    {
        if (GlobalVars.Instance.coins >= 100)
        {
            loading.SetActive(true);
            StartCoroutine(waitTantico());
        }
    }

    IEnumerator waitTantico()
    {
        yield return new WaitForSeconds(1f);
        GlobalVars.Instance.coins = GlobalVars.Instance.coins - 100;
        Debug.Log("cargando coins: " + GlobalVars.Instance.coins);
        Debug.Log("nuevos coins: " + GlobalVars.Instance.coins);
        //header.returnWindow = "clasificacion";
        //header.UpdateCoins();
        GlobalVars.Instance.canchaSeleccionada = Random.Range(0, GlobalVars.Instance.nivel);
        //navigationManager.goGamePuntos();
    }

    public void SetClasificacion()
    {
        Debug.Log("SetClasificacion");
        oADmob.Init();
        oADmob.ShowVideo();
        loading.SetActive(true);
        items.SetActive(false);
        communicatorManager.LoadUsers("9");
    }

    public void onCommunicatorResult(JSONObject dataJSON)
    {
        loading.SetActive(false);
        items.SetActive(true);

        JSONObject result = dataJSON;
        //Debug.Log(result.GetField("nombre").str);
        Debug.Log("===========================");
        Debug.Log("onCommunicatorResult: " + result.list.Count);
        for (int i = 0; i < result.list.Count; i++)
        {
            if (i == 0)
            {
                string avatar_str = result[i].GetField("avatar").str;
                string[] avatar = avatar_str.Split(char.Parse("|"));
                avatarWinner1.setAvatar(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]));
            }

            if (i == 1)
            {
                string avatar_str = result[i].GetField("avatar").str;
                string[] avatar = avatar_str.Split(char.Parse("|"));
                avatarWinner2.setAvatar(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]));
            }

            if (i == 2)
            {
                string avatar_str = result[i].GetField("avatar").str;
                string[] avatar = avatar_str.Split(char.Parse("|"));
                avatarWinner3.setAvatar(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]));
            }

            if (i <= 4)
            {
                user_nombre[i].text = result[i].GetField("nombre").str;
                user_puntos[i].text = result[i].GetField("points").str;
            }

            if (result[i].GetField("idUser").str == GlobalVars.Instance.player1.idUser)
            {
                user_nombre[i].color = Color.red;
                user_puntos[i].color = Color.red;
            }
            else
            {
                user_nombre[i].color = Color.black;
                user_puntos[i].color = Color.black;
            }
        }
    }

}
