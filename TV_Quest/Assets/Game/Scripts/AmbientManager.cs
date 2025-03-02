using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientManager : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;

    public Sprite[] walls1;
    public Sprite[] walls2;
    public Sprite[] walls3;

    void Start()
    {
        
    }

    public void SetAmbient(int nivel)
    {
        wall1.GetComponent<SpriteRenderer>().sprite = walls1[nivel];
        wall2.GetComponent<SpriteRenderer>().sprite = walls2[nivel];
        wall3.GetComponent<SpriteRenderer>().sprite = walls3[nivel];
        
    }

}
