using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letrero : MonoBehaviour
{
    public GameObject player_txt;

    public void show(string player)
    {
        player_txt.SetActive(true);
        player_txt.GetComponent<Text>().text = player;
        this.gameObject.SetActive(true);
        StartCoroutine(hide());
    }

    public void showLite()
    {
        this.gameObject.SetActive(true);
        StartCoroutine(hideLite());
    }

    private IEnumerator hide()
    {
        yield return new WaitForSeconds(5f);
        hideAll();
    }

    private IEnumerator hideLite()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }

    public void hideAll()
    {
        this.gameObject.SetActive(false);
        player_txt.SetActive(false);
    }
}
