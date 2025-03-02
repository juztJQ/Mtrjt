using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private GameObject oGameObject = new GameObject();
    public Material material;
    public float lineWidth = 5;
    public float depth = 5;

    public void SetLine(Vector3 _startPoint, Vector3 _endPoint)
    {
        LineRenderer line = oGameObject.AddComponent<LineRenderer>();
        line.material = material;
        line.SetPositions(new Vector3[] { _startPoint, _endPoint });
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
    }

}