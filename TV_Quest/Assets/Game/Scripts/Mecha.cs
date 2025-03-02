using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecha : MonoBehaviour
{
    public GameObject sparks;
    public GameObject stars;
    public GameObject mechaQuemada;

    void Start()
    {
        sparks.SetActive(false);
        stars.SetActive(false);
        mechaQuemada.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetExplotion()
    {
        sparks.SetActive(true);
        stars.SetActive(true);
        mechaQuemada.SetActive(true);
        StartCoroutine(HideSparks());
    }

    IEnumerator HideSparks()
    {
        yield return new WaitForSeconds(6f);
        sparks.SetActive(false);
        stars.SetActive(false);
        mechaQuemada.SetActive(false);
    }
}
