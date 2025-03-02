using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public void SetStars(int _num)
    {
        switch (_num)
        {
            case 1:
                Debug.Log("SetStars: " + _num);
                star1.GetComponent<Animator>().SetBool("Show", true);
            break;
            case 2:
                Debug.Log("SetStars: " + _num);
                star1.GetComponent<Animator>().SetBool("Show", true);
                star2.GetComponent<Animator>().SetBool("Show", true);
            break;
            case 3:
                Debug.Log("SetStars: " + _num);
                star1.GetComponent<Animator>().SetBool("Show", true);
                star2.GetComponent<Animator>().SetBool("Show", true);
                star3.GetComponent<Animator>().SetBool("Show", true);
            break;
        }
    }
}
