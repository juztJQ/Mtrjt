using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinChicoPlayerAnimation : MonoBehaviour
{
    public FinChico finChico;

    public void onAnimate()
    {
        finChico.ShowContent();
    }
}
