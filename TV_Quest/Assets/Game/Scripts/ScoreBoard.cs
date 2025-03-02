using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public ClasificacionManager clasificacion;

    public void SetClasificacion()
    {
        clasificacion.SetClasificacion();
    }
}
