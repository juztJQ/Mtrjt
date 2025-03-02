using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TejoEnemy : MonoBehaviour
{
    private SpawnManager spawnManager;
    private CameraManager cameraManager;
    public GameObject tejoOut;
    public AudioManager audioManager;

    private Rigidbody rigidBody;
    private float m_ForceX = 9;
    private float m_ForceY = 9;
    private float m_ForceZ = 1;

    public float speed;
    public float angle;
    public float initPosZ;
    public int direction = 0;
    public bool moviendo = true;
    public bool hit = false;
    private int level = 5;
    public bool isMecha = false;
    public bool isMecha1 = false;
    public bool isBocin = false;
    private bool isChecking = false;

    void Start()
    {
        tejoOut.SetActive(false);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        
        rigidBody = GetComponent<Rigidbody>();
        if (spawnManager.currentCancha == 1)
        {
            transform.SetPositionAndRotation(new Vector3(-4.26f, 1.69f, 0), Quaternion.identity);
        }
        else
        {
            transform.SetPositionAndRotation(new Vector3(4.26f, 1.69f, 0), Quaternion.identity);
        }
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x = -90;
        transform.localEulerAngles = newRotation;

        SetIA();
        //SetNormal();
        //SetMonona();
        //SetFuera();
        //transform.position = new Vector3(transform.position.x, transform.position.y, initPosZ);

        StartCoroutine(SetTejo());
    }

    private void SetIA()
    {
        int suerte;
        int tipoSuerte;

        switch (GlobalVars.Instance.gameType)
        {
            case "Campeonato": level = GlobalVars.Instance.currentNivel; break;
            case "Reto"      : level = GlobalVars.Instance.reto_level; break;
        }
        
        switch (level)
        {
            case 0:
                suerte = Random.Range(0, 100);
                if (suerte <= 2)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5) {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.04f, 0.04f);
                            speed = Random.Range(10.6f, 11.6f);
                            angle = Random.Range(-0.5f, 0.5f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.04f, 0.04f);
                        speed = Random.Range(10.6f, 11.6f);
                        angle = Random.Range(-0.5f, 0.5f);
                    }                    
                }
            break;
            case 1:
                suerte = Random.Range(0, 100);
                if (suerte <= 4)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5)
                        {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.038f, 0.038f);
                            speed = Random.Range(10.65f, 11.55f);
                            angle = Random.Range(-0.45f, 0.48f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.038f, 0.038f);
                        speed = Random.Range(10.65f, 11.55f);
                        angle = Random.Range(-0.45f, 0.48f);
                    }
                }
            break;
            case 2:
                suerte = Random.Range(0, 100);
                if (suerte <= 6)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5)
                        {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.036f, 0.036f);
                            speed = Random.Range(10.7f, 11.5f);
                            angle = Random.Range(-0.4f, 0.35f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.036f, 0.036f);
                        speed = Random.Range(10.7f, 11.5f);
                        angle = Random.Range(-0.4f, 0.35f);
                    }
                }
            break;
            case 3:
                suerte = Random.Range(0, 100);
                if (suerte <= 8)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5)
                        {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.34f, 0.034f);
                            speed = Random.Range(10.75f, 11.45f);
                            angle = Random.Range(-0.35f, 0.42f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.34f, 0.034f);
                        speed = Random.Range(10.75f, 11.45f);
                        angle = Random.Range(-0.35f, 0.42f);
                    }
                }
            break;
            case 4:
                suerte = Random.Range(0, 100);
                if (suerte <= 10)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5)
                        {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.032f, 0.032f);
                            speed = Random.Range(10.8f, 11.4f);
                            angle = Random.Range(-0.3f, 0.3f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.032f, 0.032f);
                        speed = Random.Range(10.8f, 11.4f);
                        angle = Random.Range(-0.3f, 0.3f);
                    }
                }
            break;
            case 5:
                suerte = Random.Range(0, 100);
                if (suerte <= 12)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5)
                        {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.032f, 0.032f);
                            speed = Random.Range(10.8f, 11.4f);
                            angle = Random.Range(-0.3f, 0.3f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.03f, 0.03f);
                        speed = Random.Range(10.85f, 11.35f);
                        angle = Random.Range(-0.25f, 0.3f);
                    }
                }
            break;
            case 6:
                suerte = Random.Range(0, 100);
                if (suerte <= 15)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5)
                        {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.025f, 0.025f);
                            speed = Random.Range(10.9f, 11.3f);
                            angle = Random.Range(-0.2f, 0.25f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.025f, 0.025f);
                        speed = Random.Range(10.9f, 11.3f);
                        angle = Random.Range(-0.2f, 0.25f);
                    }
                }
            break;
            case 7:
                suerte = Random.Range(0, 100);
                if (suerte <= 20)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5)
                        {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.02f, 0.02f);
                            speed = Random.Range(10.95f, 11.25f);
                            angle = Random.Range(-0.15f, 0.2f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.02f, 0.02f);
                        speed = Random.Range(10.95f, 11.25f);
                        angle = Random.Range(-0.15f, 0.2f);
                    }
                }
            break;
            case 8:
                suerte = Random.Range(0, 100);
                if (suerte <= 25)
                {
                    tipoSuerte = Random.Range(1, 5);
                    SetTipoSuerte(tipoSuerte);
                }
                else
                {
                    if (spawnManager.isBoss)
                    {
                        tipoSuerte = Random.Range(1, 15);
                        if (tipoSuerte <= 5)
                        {
                            SetTipoSuerte(tipoSuerte);
                        }
                        else
                        {
                            initPosZ = Random.Range(-0.01f, 0.01f);
                            speed = Random.Range(11f, 11.2f);
                            angle = Random.Range(-0.1f, 0.1f);
                        }
                    }
                    else
                    {
                        initPosZ = Random.Range(-0.01f, 0.01f);
                        speed = Random.Range(11f, 11.2f);
                        angle = Random.Range(-0.1f, 0.1f);
                    }
                }
            break;
            case 9:
                SetMecha1();
            break;
        }
        /* cancha
        initPosZ = -0.01f;
        speed = 10.81f;
        angle = -0.3f;
        */
       // Debug.Log("TejoEnemy initPosZ: " + initPosZ + " - speed: " + speed + " - angle: " + angle);
        transform.position = new Vector3(transform.position.x, transform.position.y, initPosZ);
    }

    private void SetTipoSuerte(int _tipo)
    {
        switch (_tipo)
        {
            case 1: SetMecha1(); break;
            case 2: SetMecha2(); break;
            case 3: SetMecha3(); break;
            case 4: SetBocin(); break;
            case 5: SetMonona(); break;
        }
    }

    private void SetFuera()
    {
        initPosZ = 0;
        speed = 10f;
        angle = -0.03f;
    }

    private void SetNormal()
    {
        initPosZ = 0;
        speed = 11.30f;
        angle = -0.03f;
    }

    private void SetMecha1()
    {
        Debug.Log("Suerte");
        initPosZ = 0;
        speed = 11.15f;
        angle = 0;
    }

    private void SetMecha2()
    {
        Debug.Log("Suerte");
        initPosZ = -0.01f;
        speed = 11.08f;
        angle = 0.04f;
    }

    private void SetMecha3()
    {
        Debug.Log("Suerte");
        initPosZ = -0.01f;
        speed = 11.1f;
        angle = -0.03f;
    }

    private void SetBocin()
    {
        Debug.Log("Suerte");
        initPosZ = -0.01f;
        speed = 11.09f;
        angle = 0;
    }

    private void SetMonona()
    {
        Debug.Log("Suerte");
        initPosZ = -0.01f;
        speed = 11.11f;
        angle = 0;
    }

    private IEnumerator SetTejo()
    {
        yield return new WaitForSeconds(0.5f);
        Launch();
    }

    public void Launch()
    {
        audioManager.SetLanzamiento();
        m_ForceX = speed;
        if (spawnManager.currentCancha != 1) m_ForceX = -m_ForceX;
        m_ForceY = speed * 0.8f;
        m_ForceZ = angle;

        Vector3 m_NewForce = new Vector3(m_ForceX, m_ForceY, m_ForceZ);
        rigidBody.AddForce(m_NewForce, ForceMode.Impulse);
        rigidBody.useGravity = true;
        StartCoroutine(CheckError());
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("TejoEnemy Collision con: " + other.tag + " - " + other.name);
        hit = true;
        if ((other.tag != "Tablero") && (other.tag != "Mecha") && (other.tag != "Mecha1") && (other.tag != "Bocin"))
        {
            spawnManager.hitOutsideEnemy = true;
            //tejoOut = GameObject.Find("TejoEnemyOut").GetComponent<GameObject>();
            tejoOut.SetActive(true);
            audioManager.SetGolpe();
            if (GlobalVars.Instance.vibracionON == 1) Handheld.Vibrate();
        }
        else StopTejo();
        

        if ((other.tag == "Bocin") && (!isBocin) && (!spawnManager.hitOutsideEnemy)) isBocin = true;
        
        if ((other.tag == "Mecha") && (!isMecha) && (!spawnManager.hitOutsideEnemy))
        {
            if (GlobalVars.Instance.vibracionON == 1) Handheld.Vibrate();
            Mecha mecha = other.GetComponent<Mecha>();
            audioManager.SetMecha();
            mecha.SetExplotion();
            isMecha = true;
        }
        if ((other.tag == "Mecha1") && (!isMecha1) && (!spawnManager.hitOutsideEnemy))
        {
            if (GlobalVars.Instance.vibracionON == 1) Handheld.Vibrate();
            Mecha mecha = other.GetComponent<Mecha>();
            audioManager.SetMecha();
            mecha.SetExplotion();
            isMecha1 = true;
        }
        
        if (!isChecking)
        {
            if (spawnManager.currentCancha == 1)
            {
                cameraManager.ZoomCancha1();
            }
            else
            {
                cameraManager.ZoomCancha2();
            }
            StartCoroutine(CheckResults());
            isChecking = true;
        }
    }

    private IEnumerator CheckResults()
    {
        //Debug.Log("CheckResults");
        yield return new WaitForSeconds(1f);
        //Debug.Log("isMecha:" + isMecha + " - isMecha1:" + isMecha1 + " - isBocin:" + isBocin);
        if (isMecha)
        {
            if (isBocin) isBocin = false;
            spawnManager.SetMechaEnemy();
        }
        else if (isMecha1)
        {
            if (isBocin) spawnManager.SetMononaEnemy(); else spawnManager.SetMechaEnemy();
        }
        else if (isBocin) spawnManager.SetBocinEnemy();
        spawnManager.SetEnemyStep();
    }

    private IEnumerator CheckError()
    {
        yield return new WaitForSeconds(4f);
        if (!hit)
        {
            if (spawnManager.currentCancha == 1)
            {
                cameraManager.ZoomCancha1();
            }
            else
            {
                cameraManager.ZoomCancha2();
            }
            Debug.Log("XXXXXXXXXXXXXXXXXXX P2");
            tejoOut.SetActive(true);
            spawnManager.hitOutsideEnemy = true;
            spawnManager.SetEnemyStep();
        }

    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tablero") spawnManager.SetTejoEnemyPosition(this.transform.position);
        
        if ((other.tag != "Tablero") && (other.tag != "Mecha") && (other.tag != "Mecha1") && (other.tag != "Bocin"))
        {
            spawnManager.distanciaTejo2 = 1000f;
            spawnManager.hitOutsideEnemy = true;
            tejoOut.SetActive(true);
        }
    }

    public void StopTejo()
    {
        rigidBody.linearVelocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }
}
