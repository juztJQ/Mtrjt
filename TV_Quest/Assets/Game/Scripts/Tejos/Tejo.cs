using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tejo : MonoBehaviour
{
    private SpawnManager spawnManager;
    private CameraManager cameraManager;
    private Rigidbody rigidBody;
    public GameObject tejoOut;
    public GameObject tejoGold;
    public AudioManager audioManager;
    /*
    public float m_ForceX = 9;
    public float m_ForceY = 9;
    public float m_ForceZ = 1;
    */
    private Vector3 defaultScale;
    public bool dragging = false;
    private float distance;

    public float speed;
    public float angle;
    public bool hit = false;
    public Vector3 initPos;
    public Vector3 finalPos;
    private bool isMecha1 = false;
    private bool isMecha = false;
    public bool isBocin = false;
    private bool evaluateHit = true;
    private bool enableHit = true;

    public float diff;

    void Start()
    {
        tejoOut.SetActive(false);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        transform.position = new Vector3(-11, 1.5f, 0);
        transform.eulerAngles = new Vector3(-89.98f, 0, 0);
        rigidBody = GetComponent<Rigidbody>();
        //test();
    }

    private void test()
    {
        /*
        m_ForceX = 10.5f;
        m_ForceY = m_ForceX * 0.8f;
        m_ForceZ = -1.5f;
        transform.position = new Vector3(-4.45f, 1.78f, 0);
        Launch();
        */
    }

    void Update()
    {
        
        if (dragging) Drag();
    }

    public void Drag()
    {
        float newX;
        if (spawnManager.currentCancha == 1) newX = Camera.main.transform.position.x + 1; else newX = Camera.main.transform.position.x - 1;
        
        float newY = Camera.main.transform.position.y;
        float newZ = Camera.main.transform.position.z;
        //Debug.Log("newX :" + newX + "newY :" + newY + "newZ :" + newZ);
        distance = Vector3.Distance(transform.position, new Vector3(newX, newY, newZ));
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        transform.position = rayPoint;
        spawnManager.flecha.SetActive(false);
    }

    public void SetTejo()
    {
        //transform.position = Input.mousePosition;
        float newX;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (spawnManager.currentCancha == 1) newX = Camera.main.transform.position.x + 50; else newX = Camera.main.transform.position.x - 50;
        float newY = Camera.main.transform.position.y;
        float newZ = Camera.main.transform.position.z;
        distance = Vector3.Distance(transform.position, new Vector3(newX, newY, newZ));
        dragging = true;
    }

    public void ShowTejoGold()
    {
        tejoGold.SetActive(true);
    }

    public void Launch(float m_ForceX, float m_ForceY, float m_ForceZ)
    {
        dragging = false;
        if (spawnManager.currentCancha != 1) m_ForceX = -m_ForceX;
        rigidBody.isKinematic = false;
        Vector3 m_NewForce = new Vector3(m_ForceX, m_ForceY, m_ForceZ);
        rigidBody.AddForce(m_NewForce, ForceMode.Impulse);
        rigidBody.useGravity = true;
        spawnManager.flecha.SetActive(false);
        StartCoroutine(CheckError());
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Tejo Collision con: " + other.tag + " - " + other.name);
        if (evaluateHit && enableHit)
        {
            hit = true;
            if ((other.tag != "Tablero") && (other.tag != "Mecha") && (other.tag != "Mecha1") && (other.tag != "Bocin"))
            {
                spawnManager.hitOutside = true;
                tejoOut.SetActive(true);
                audioManager.SetGolpe();
                if (GlobalVars.Instance.vibracionON == 1) Handheld.Vibrate();
            }
            else StopTejo();

            if ((other.tag == "Bocin") && (!isBocin) && (!spawnManager.hitOutside)) isBocin = true;

            if ((other.tag == "Mecha") && (!isMecha) && (!spawnManager.hitOutside))
            {
                audioManager.SetMecha();
                Mecha mecha = other.GetComponent<Mecha>();
                mecha.SetExplotion();
                isMecha = true;
                if (GlobalVars.Instance.vibracionON == 1) Handheld.Vibrate();
            }
            if ((other.tag == "Mecha1") && (!isMecha1) && (!spawnManager.hitOutside))
            {
                audioManager.SetMecha();
                Mecha mecha = other.GetComponent<Mecha>();
                mecha.SetExplotion();
                isMecha1 = true;
                if (GlobalVars.Instance.vibracionON == 1) Handheld.Vibrate();
            }
            StartCoroutine(CheckResults());
        }
    }

    private IEnumerator CheckResults()
    {
        yield return new WaitForSeconds(0.5f);
        if (isMecha)
        {
            if (isBocin) isBocin = false;
            spawnManager.SetMecha();
        }
        else if (isMecha1)
        {
            if (isBocin) spawnManager.SetMonona(); else spawnManager.SetMecha();
        }
        else if (isBocin)
        {
            spawnManager.SetBocin();
        }else{
            spawnManager.SetPlayerStep();
        }
        
    }

    private IEnumerator CheckError()
    {
        yield return new WaitForSeconds(4f);
        if (!hit)
        {
            //Debug.Log("XXXXXXXXXXXXXXXXXXX P1");
            tejoOut.SetActive(true);
            spawnManager.hitOutside = true;
            spawnManager.SetPlayerStep();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tablero") spawnManager.SetTejoPosition(this.transform.position);

        if ((other.tag != "Tablero") && (other.tag != "Mecha") && (other.tag != "Mecha1") && (other.tag != "Bocin"))
        {
            spawnManager.distanciaTejo1 = 1000f;
            spawnManager.hitOutside = true;
            tejoOut.SetActive(true);
        }
    }

    public void StopTejo()
    {
        rigidBody.linearVelocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }

    public void DisableHit()
    {
        enableHit = false;
    }
}
