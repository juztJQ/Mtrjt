using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ayuda : MonoBehaviour
{
    public GameObject comoSeJuega;
    public GameObject comoSeLanza;

    public void SetComoSeLanza()
    {
        comoSeJuega.SetActive(false);
        comoSeLanza.SetActive(true);
    }
}
