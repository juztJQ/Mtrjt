using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanioAnimate : MonoBehaviour
{
    public Entrada_UIManager uiManager;
    public GameObject botoneraAvatar;
    public GameObject AvatarWeb;
    public Header headerLite;

    public void onAnimate()
    {
        botoneraAvatar.GetComponent<Animator>().SetBool("enter", true);
        AvatarWeb.GetComponent<Animator>().SetBool("enter", true);
        headerLite.GetComponent<Animator>().SetBool("enter", true);
    }

    public void onOutAnimate()
    {
        botoneraAvatar.GetComponent<Animator>().SetBool("enter", false);
        AvatarWeb.GetComponent<Animator>().SetBool("enter", false);
        headerLite.GetComponent<Animator>().SetBool("enter", false);
    }

    public void GoEnter()
    {
        uiManager.GoEnter();
    }
}
