using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{
    private float Xo;
    private float Xi;
    public GameObject tejoPrefab;
    private GameObject tejoPrefabClone;
    private Tejo tejo;
    public CheckMouse checkMouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lanzamiento();
    }

    public void Lanzamiento()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tejoPrefabClone = Instantiate(tejoPrefab, transform.position, Quaternion.identity);
            tejo = tejoPrefab.GetComponent<Tejo>();
            tejo.SetTejo();
            checkMouse.SetChecking(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void LanzaTejo(float Xo, float Xi, float Yo, float Yi)
    {
        float difX = (Xi - Xo);
        float difY = (Yi - Yo);
        Debug.Log(" - Diff X: " + Xi + " - " + Xo + " = " + difX);
        Debug.Log(" - Diff Y: " + Yi + " - " + Yo + " = " + difY);
        float speed = (difY * 2.5f) / 1047;
        if (speed < 0) speed = -speed;

        float angle = (difX * 2.5f) / 690;
        angle = angle * 1.5f;

        float m_ForceX = 10.5f + speed;
        float m_ForceY = m_ForceX * 0.8f;
        float m_ForceZ;
        m_ForceZ = -angle;

        Debug.Log("m_ForceX: " + m_ForceX + " - m_ForceY: " + m_ForceY + " - m_ForceZ: " + m_ForceZ);
        tejoPrefabClone.GetComponent<Tejo>().Launch(m_ForceX, m_ForceY, m_ForceZ);
    }
}
