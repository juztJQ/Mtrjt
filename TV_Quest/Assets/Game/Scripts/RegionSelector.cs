using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionSelector : MonoBehaviour
{
    public ScrollSnapRect ScrollSnap;
    public int selection = 0;
    public ClasificacionManager clasificacionManager;

    public void onSelection()
    {
        selection = ScrollSnap._currentPage;
        //try { clasificacionManager.onRegionChanged(selection); } catch { }
    }
}
