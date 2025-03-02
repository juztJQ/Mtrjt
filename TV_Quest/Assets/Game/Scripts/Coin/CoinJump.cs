using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinJump : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        if (GlobalVars.Instance.soundEffectsON == 0)
        {
            audioSource.enabled = false;
        }
        else
        {
            audioSource.enabled = true;
        }
        Destroy(this.gameObject, 0.5f);
    }

}
