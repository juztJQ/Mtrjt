using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrofeosManager : MonoBehaviour
{
    public GameObject message;
    public GameObject polaOro;
    public GameObject mechaOro;
    public GameObject superBocin;
    public GameObject gallina;
    public GameObject petacoOro;
    public GameObject cabezaLechona;
    public GameObject cariador;
    public GameObject bofeOro;
    public GameObject fritanga;

    public void SetTrofeos()
    {
        if (GlobalVars.Instance.hasPolaOro == 0)        GlobalVars.Instance.SetBlack(polaOro, 0.08f);
        if (GlobalVars.Instance.hasMechaOro == 0)       GlobalVars.Instance.SetBlack(mechaOro, 0.08f);
        if (GlobalVars.Instance.hasSuperBocin == 0)     GlobalVars.Instance.SetBlack(superBocin, 0.08f);
        if (GlobalVars.Instance.hasGallina == 0)        GlobalVars.Instance.SetBlack(gallina, 0.08f);
        if (GlobalVars.Instance.hasPetacoOro == 0)      GlobalVars.Instance.SetBlack(petacoOro, 0.08f);
        if (GlobalVars.Instance.hasCabezaLechona == 0)  GlobalVars.Instance.SetBlack(cabezaLechona, 0.08f);
        if (GlobalVars.Instance.hasCariador == 0)       GlobalVars.Instance.SetBlack(cariador, 0.08f);
        if (GlobalVars.Instance.hasBofeOro == 0)        GlobalVars.Instance.SetBlack(bofeOro, 0.08f);
        if (GlobalVars.Instance.hasFritanga == 0)       GlobalVars.Instance.SetBlack(fritanga, 0.08f);
    }

    public void SetMessage(string tipo)
    {
        switch (tipo)
        {
            case "pola":        message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Pola de Oro", 2f); break;
            case "mecha":       message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Mecha de Oro", 2f); break;
            case "bocin":       message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Super Bocín", 2f); break;
            case "gallina":     message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Gallina Radiactiva", 2f); break;
            case "petaco":      message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Petaco de Oro", 2f); break;
            case "lechona":     message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Cabeza de lechona", 2f); break;
            case "cariador":    message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Cariador", 2f); break;
            case "bofe":        message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Bofe de Oro", 2f); break;
            case "fritanga":    message.SetActive(true); message.GetComponent<Message>().SetMessage("", "Plato de Fritanga", 2f); break;
        }
    }
}
