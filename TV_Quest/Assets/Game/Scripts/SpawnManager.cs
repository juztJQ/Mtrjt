using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	private CameraManager cameraManager;
    public AudioManager audioManager;
    public CheckMouse checkMouse;
    public GameObject boss;

    public GameObject tejoPrefab;
    private GameObject tejoPrefabClone;

    public GameObject tejoEnemyPrefab;
    private GameObject tejoEnemyPrefabClone;

    public GameObject tejo2PlayerPrefab;
    private GameObject tejo2PlayerPrefabClone;

    public GameObject line1;
    public GameObject line2;
    public GameObject flecha;
    private Tejo tejo;
    private Tejo2Player tejo2Player;
    public GameObject tablero1;
    public GameObject tablero2;
    private Vector3 tejoPosition;
    private Vector3 tejoEnemyPosition;
    private Game_UIManager uiManager;
    private bool isLaunching = false;
    private bool isLaunching2P = false;
    public  bool canLaunch = false;
    public  bool hitOutside = false;
    public  bool hitOutsideEnemy = false;
    private bool isMecha = false;
    private bool isBocin = false;
    private bool isMonona = false;
    private bool isMechaEnemy = false;
    private bool isBocinEnemy = false;
    private bool isMononaEnemy = false;
    public  float distanciaTejo1 = 1000f;
    public  float distanciaTejo2 = 1000f;
    public  int score1 = 0;
    public  int score2 = 0;
    public int scoreTraining1 = 0;
    public int scoreTraining2 = 0;
    public int scoreTraining3 = 0;
    public int scoreTraining4 = 0;
    public int scoreTraining5 = 0;
    public int scoreTraining6 = 0;
    public  int currentCancha = 1;
    public  int step = 0;
    private bool turnoPlayer1 = true;
    public int initMaxPuntos = 11;
    public int maxPuntos = 11;
    private int turno = 1;
    private int turnoTraining = 0;
    public bool gameOver = false;
    [HideInInspector] public bool isPlaying = false;
    public bool isBoss = false;

    public int numManos = 0;
    public int numMechas = 0;
    public int numBocines = 0;
    public int numMononas = 0;

    private float impulsoTime = 0;
    private bool isTiming = false;

    private bool isTesting = true;
    public int tejosAfuera = 0;
    public int tejosAdentro = 0;

    private bool suerteEsQueLeDigo = false;
    public float distanciaTejoTraining = 1000f;
    public int puntosTraining = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartGame()
    {
        isPlaying = true;
    }

    public void SetTurno()
    {
        if (!gameOver)
        {
            
            switch (step)
            {
                case 0: // Mensaje Player 1
                    hitOutside = false;
                    hitOutsideEnemy = false;
                    if (tejoPrefabClone) Destroy(tejoPrefabClone.gameObject);
                    if (tejoEnemyPrefabClone) Destroy(tejoEnemyPrefabClone.gameObject);
                    line1.SetActive(false);
                    line2.SetActive(false);
                    canLaunch = false;
                    if ((score1 == 0) && (score2 == 0)) { uiManager.SetMessage(step, "Es el turno de:", GlobalVars.Instance.player1.nombre); }
                    else { canLaunch = true; step = 1; }
                    break;
                case 1: // Lanzamiento Player 1
                    Lanzamiento();
                    break;
                case 2: // Mensaje Player 2
                    flecha.SetActive(false);
                    canLaunch = false;
                    if ((score1 == 0) && (score2 == 0))
                    { 
                        if (isBoss) { uiManager.SetMessage(step, "Es el turno de:", boss.GetComponent<Boss>().nombre); }
                        else { uiManager.SetMessage(step, "Es el turno de:", GlobalVars.Instance.player2.nombre); }
                    }
                    else { step = 3; }
                break;
                case 3: // Lanzamiento Player 2
                    flecha.SetActive(false);
                    canLaunch = false;
                    impulsoTime = 0;
                    LanzamientoEnemy();
                break;
                case 4: // Cambio de Cancha
                    flecha.SetActive(false);
                    canLaunch = false;
                    if (currentCancha == 1) cameraManager.GoCancha2(); else cameraManager.GoCancha1();
                break;
            }
        }
        
    }

    public void SetTurnoTraining()
    {
        if (!gameOver)
        {
            switch (step)
            {
                case 0: // Mensaje
                    step = 1;
                    break;
                case 1: // Lanzamiento
                    canLaunch = true;
                    Lanzamiento();
                    break;
                case 2: // Zoom
                    flecha.gameObject.SetActive(false);
                    canLaunch = false;
                    if (currentCancha == 1) cameraManager.ZoomCancha1(); else cameraManager.ZoomCancha2();
                    break;
                case 3: // Cambio de Cancha
                    //Debug.Log("turnoTraining: " + turnoTraining);
                    if (turnoTraining < 6)
                    {
                        canLaunch = false;
                        if (currentCancha == 1) { cameraManager.GoCancha2(); } else { cameraManager.GoCancha1(); }
                        turnoPlayer1 = true;
                    }
                    else
                    {
                        cameraManager.isAnimating = false;
                        ShowResultado();
                    }
                break;
            }
        }
    }

    public void SetTurno2Players()
    {
        if (!gameOver)
        {
            switch (step)
            {
                case 0: // Mensaje Player 1
                    hitOutside = false;
                    hitOutsideEnemy = false;
                    if (tejoPrefabClone) Destroy(tejoPrefabClone.gameObject);
                    if (tejo2PlayerPrefabClone) Destroy(tejo2PlayerPrefabClone.gameObject);
                    line1.SetActive(false);
                    line2.SetActive(false);
                    canLaunch = false;
                    uiManager.SetMessage(step, "Es el turno de:", GlobalVars.Instance.player1.nombre);
                    break;
                case 1: // Lanzamiento Player 1
                    Lanzamiento();
                    break;
                case 2: // Mensaje Player 2
                    uiManager.SetMessage(step, "Es el turno de:", GlobalVars.Instance.player2.nombre);
                    break;
                case 3: // Lanzamiento Player 2
                    Lanzamiento2Player();
                    break;
                case 4: // Cambio de Cancha
                    flecha.SetActive(false);
                    canLaunch = false;
                    if (currentCancha == 1) cameraManager.GoCancha2(); else cameraManager.GoCancha1();
                    break;
            }
        }
    }

    public void Lanzamiento()
    {
        if (turnoPlayer1 && canLaunch)
        {
			if(!isLaunching) flecha.SetActive(true);
			if (Input.GetMouseButtonDown(0) && !isLaunching)
            {
                isTiming = true;
                flecha.SetActive(false);
                tejoPrefabClone = Instantiate(tejoPrefab, transform.position, Quaternion.identity);
                tejo = tejoPrefab.GetComponent<Tejo>();
                tejo.SetTejo();
                checkMouse.SetChecking(Input.mousePosition.x, Input.mousePosition.y);
                isLaunching = true;
            }
        }
    }

    public void LanzamientoEnemy()
    {
        if (!turnoPlayer1)
        {
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("TejoEnemy");
            if (gameObjects.Length == 0)
            {
                tejoEnemyPrefabClone = Instantiate(tejoEnemyPrefab, transform.position, Quaternion.identity);
                turnoPlayer1 = true;
            }
        }
    }

    public void Lanzamiento2Player()
    {
        Debug.Log("Lanzamiento2Player : " + canLaunch + " - isLaunching2P: " + isLaunching2P);
        if (canLaunch)
        {
            if (!isLaunching2P) flecha.SetActive(true);
            if (Input.GetMouseButtonDown(0) && !isLaunching2P)
            {
                isTiming = true;
                flecha.SetActive(false);
                tejo2PlayerPrefabClone = Instantiate(tejo2PlayerPrefab, transform.position, Quaternion.identity);
                tejo2Player = tejo2PlayerPrefab.GetComponent<Tejo2Player>();
                tejo2Player.SetTejo();
                tejo2Player.ShowTejoGold();
                tejo2PlayerPrefabClone.GetComponent<Tejo2Player>().ShowTejoGold();
                checkMouse.SetChecking(Input.mousePosition.x, Input.mousePosition.y, true);
                isLaunching2P = true;
            }
        }
    }

    public void LanzaTejo(float Xo, float Xi, float Yo, float Yi, bool _is2Player=false)
    {
        ////Debug.Log("LanzaTejo: " + _is2Player);
        audioManager.SetLanzamiento();
        canLaunch = false;
        isTiming = false;
        flecha.SetActive(false);
        float difX = (Xi - Xo);
        float difY = (Yi - Yo);
        float speed = (difY * 2.5f) / 1047;
        if (speed < 0) speed = -speed;
        float angle = (difX * 2.5f) / 690;
        angle = angle * 1.5f;
        float m_ForceX = 10.5f + speed;
        float m_ForceY = m_ForceX * 0.8f;
        float m_ForceZ;
        if (currentCancha == 1) m_ForceZ = -angle; else m_ForceZ = angle;
        if(impulsoTime > 80) m_ForceY *= 0.8f;
        if (suerteEsQueLeDigo)
        {
            float suerteZ = Random.Range(0.05f, 0.1f);
            float suerteY = Random.Range(0.05f, 0.1f);
            float dirSuerteZ = Random.Range(-1, 1);
            float dirSuerteY = Random.Range(-1, 1);
            if (dirSuerteZ >= 0) m_ForceZ += suerteZ; else m_ForceZ -= suerteZ;
            if (dirSuerteY >= 0) m_ForceY += suerteY; else m_ForceY -= suerteY;
        }
        if (!_is2Player) {
            tejoPrefabClone.GetComponent<Tejo>().Launch(m_ForceX, m_ForceY, m_ForceZ);
        }
        else {
            tejoPrefabClone.GetComponent<Tejo>().DisableHit();
            tejo2PlayerPrefabClone.GetComponent<Tejo2Player>().Launch(m_ForceX, m_ForceY, m_ForceZ);
        }
    }

    private void SetTimer() { StartCoroutine(Tic()); }
    IEnumerator Tic() { impulsoTime++; yield return new WaitForSeconds(0.1f); }

	public void SetTejoPosition(Vector3 _tejoPosition) { tejoPosition = _tejoPosition; }
	public void SetTejoEnemyPosition(Vector3 _tejoEnemyPosition) { tejoEnemyPosition = _tejoEnemyPosition;}

	public void SetPlayerStep()
	{
        //Debug.Log("SetPlayerStep");
        canLaunch = false;
        isLaunching = false;
        if (GlobalVars.Instance.gameType == "Training")
        {
            flecha.gameObject.SetActive(false);
            turnoPlayer1 = false;
            checkMouse.checking = false;
            step = 2;
        }
        else
        {
            StartCoroutine(WaitForPlayerStep());
        }
	}

	IEnumerator WaitForPlayerStep()
	{
        //Debug.Log("WaitForPlayerStep");
        yield return new WaitForSeconds(1f);
		turnoPlayer1 = false;
		step = 2;
	}

    public void SetEnemyStep()
    {
        //Debug.Log("SetEnemyStep");
        isLaunching = false;
        isLaunching2P = false;
        canLaunch = false;
        StartCoroutine(WaitForEnemyStep());
    }

    IEnumerator WaitForEnemyStep()
    {
        //Debug.Log("WaitForEnemyStep");
        yield return new WaitForSeconds(1f);
        turnoPlayer1 = false;
        step = 4;
    }

    public void Evaluate()
	{
        //Debug.Log("Evaluate");
        if (GlobalVars.Instance.gameType != "Training")
        {
            if (!isMecha && !isMechaEnemy && !isBocin && !isBocinEnemy && !isMonona && !isMononaEnemy)
            {
                if (distanciaTejo1 < distanciaTejo2)
                {
                    audioManager.SetWinMano();
                    score1++;
                    numManos++;
                    uiManager.LetreroMano.show(GlobalVars.Instance.player1.nombre);
                }
                else if (distanciaTejo1 > distanciaTejo2)
                {
                    audioManager.SetLoseMano();
                    score2++;
                    if (isBoss) { uiManager.LetreroMano.show(boss.GetComponent<Boss>().nombre); }
                    else { uiManager.LetreroMano.show(GlobalVars.Instance.player2.nombre); }
                }
                else
                {
                    audioManager.SetLoseMano();
                    uiManager.SetMessage(step, "", "Mano perdida", 4f);
                }
            }

            if (isMecha)
            {
                audioManager.SetApplause();
                score1 += 3;
                numMechas++;
                uiManager.LetreroMecha.show(GlobalVars.Instance.player1.nombre);
            }

            if (isBocin && !isMonona)
            {
                audioManager.SetApplause();
                score1 += 6;
                numBocines++;
                uiManager.LetreroBocin.show(GlobalVars.Instance.player1.nombre);
            }
            else if (isMonona)
            {
                audioManager.SetApplause();
                score1 += 9;
                numMononas++;
                uiManager.LetreroMonona.show(GlobalVars.Instance.player1.nombre);
            }

            if (isMechaEnemy)
            {
                audioManager.SetLoseMano();
                score2 += 3;
                if (isBoss) { uiManager.LetreroMecha.show(boss.GetComponent<Boss>().nombre); }
                else { uiManager.LetreroMecha.show(GlobalVars.Instance.player2.nombre); }
            }

            if (isBocinEnemy && !isMononaEnemy)
            {
                audioManager.SetLoseMano();
                score2 += 6;
                if (isBoss) { uiManager.LetreroBocin.show(boss.GetComponent<Boss>().nombre); }
                else { uiManager.LetreroBocin.show(GlobalVars.Instance.player2.nombre); }
            }
            else if (isMononaEnemy)
            {
                audioManager.SetLoseMano();
                score2 += 9;
                if (isBoss) { uiManager.LetreroMonona.show(boss.GetComponent<Boss>().nombre); }
                else { uiManager.LetreroMonona.show(GlobalVars.Instance.player2.nombre); }
            }
        }
        else
        {
            checkMouse.checking = false;
            isLaunching = false;
            isLaunching2P = false;
            canLaunch = false;
            if (!isMecha && !hitOutside && !isBocin && !isMonona)
            {
                distanciaTejoTraining = distanciaTejoTraining * 10;
                int puntos_lanzamiento = 0;
                puntos_lanzamiento = (int)distanciaTejoTraining;
                puntos_lanzamiento = 13 - puntos_lanzamiento;
                puntosTraining = puntosTraining + puntos_lanzamiento;
                uiManager.SetPuntosTraining(turnoTraining, puntos_lanzamiento);

                if (puntos_lanzamiento < 3) { uiManager.SetMessage(step, "Huy sumercé casi se descacha!", puntos_lanzamiento + " Puntos", 4f); }
                else if ((puntos_lanzamiento >= 3) && (puntos_lanzamiento < 6)) { uiManager.SetMessage(step, "Sumercé ahí va la cosa", puntos_lanzamiento + " Puntos", 4f); }
                else if ((puntos_lanzamiento >= 6) && (puntos_lanzamiento < 8)) { uiManager.SetMessage(step, "Por ahí es sumercé, que bien!", puntos_lanzamiento + " Puntos", 4f); }
                else if (puntos_lanzamiento >= 8) { uiManager.SetMessage(step, "Huy que lanzamiento!", puntos_lanzamiento + " Puntos", 4f); }
                audioManager.SetWinMano();
            }

            if (isMecha)
            {
                puntosTraining = puntosTraining + 20;
                uiManager.SetPuntosTraining(turnoTraining, 20);
                audioManager.SetApplause();
                uiManager.LetreroMecha.show(GlobalVars.Instance.player1.nombre);
                uiManager.SetMessage(step, "", "20 Puntos", 4f);
            }

            if (isBocin && !isMonona && !isMecha)
            {
                puntosTraining = puntosTraining + 30;
                uiManager.SetPuntosTraining(turnoTraining, 30);
                audioManager.SetWinMano();
                audioManager.SetApplause();
                uiManager.LetreroBocin.show(GlobalVars.Instance.player1.nombre);
                uiManager.SetMessage(step, "", "30 Puntos", 4f);
            }
            else if (isMonona)
            {
                puntosTraining = puntosTraining + 40;
                uiManager.SetPuntosTraining(turnoTraining, 40);
                audioManager.SetApplause();
                uiManager.LetreroMonona.show(GlobalVars.Instance.player1.nombre);
                uiManager.SetMessage(step, "", "40 Puntos", 4f);
            }

            if (hitOutside)
            {
                puntosTraining = puntosTraining + 0;
                uiManager.SetPuntosTraining(turnoTraining, 0);
                audioManager.SetLoseMano();
                uiManager.SetMessage(step, "Huy que descache, le falta pola!", "0 Puntos", 4f);
            }
            turnoTraining++;
            StartCoroutine(WaitForNextStepTraining());
        }
    }

    public void NuevoTurno()
	{
        //Debug.Log("=================== NuevoTurno");
        isLaunching = false;
        isLaunching2P = false;
        canLaunch = false;
        hitOutside = false;
        isMecha = false;
        isBocin = false;
        isMonona = false;
        turnoPlayer1 = true;
        if (GlobalVars.Instance.gameType == "Training")
        {
            checkMouse.checking = false;
            isPlaying = true;
            distanciaTejoTraining = 1000f;
            step = 0;
            if (currentCancha == 1) currentCancha = 2; else currentCancha = 1;
        }
        else
        {
            turno++;
            step = 0;
            hitOutsideEnemy = false;
            isMechaEnemy = false;
            isBocinEnemy = false;
            isMononaEnemy = false;
            distanciaTejo1 = 1000f;
            distanciaTejo2 = 1000f;
        }
        
    }

    public void SetMecha()
	{
        if (!isMecha) isMecha = true;

        if (GlobalVars.Instance.gameType == "Training")
        {
            isLaunching = false;
            canLaunch = false;
            flecha.gameObject.SetActive(false);
            turnoPlayer1 = false;
            checkMouse.checking = false;
            step = 2;
        }
        else
        {
            step = 4;
            if (currentCancha == 1)
            {
                cameraManager.ZoomCancha1();
                if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", true);
            }
            else
            {
                cameraManager.ZoomCancha2();
                if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", false);
            }
        }
	}

    public void SetBocin()
    {
        if (GlobalVars.Instance.gameType == "Training")
        {
            checkMouse.checking = false;
            if (!isMecha && !isBocin) isBocin = true;
            isLaunching = false;
            canLaunch = false;
            flecha.gameObject.SetActive(false);
            turnoPlayer1 = false;
            step = 2;
        }
        else
        {
            if (!isMecha)
            {
                step = 4;
                if (!isBocin) isBocin = true;
                if (currentCancha == 1)
                {
                    cameraManager.ZoomCancha1();
                    if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", true);
                }
                else
                {
                    cameraManager.ZoomCancha2();
                    if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", false);
                }
            }
        }
            
    }

    public void SetMonona()
    {
        if (GlobalVars.Instance.gameType == "Training")
        {
            if (!isMonona) isMonona = true;
            isLaunching = false;
            canLaunch = false;
            flecha.gameObject.SetActive(false);
            turnoPlayer1 = false;
            checkMouse.checking = false;
            step = 2;
        }
        else
        {
            step = 4;
            if (!isMonona) isMonona = true;
            if (currentCancha == 1)
            {
                cameraManager.ZoomCancha1();
                if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", true);
            }
            else
            {
                cameraManager.ZoomCancha2();
                if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", false);
            }
        }
    }

    public void SetAfuera()
    {
        audioManager.SetGolpe();
        isLaunching = false;
        canLaunch = false;
        flecha.gameObject.SetActive(false);
        turnoPlayer1 = false;
        checkMouse.checking = false;
        step = 2;
    }

    public void SetMechaEnemy()
	{
        step = 4;
        isLaunching2P = false;
        if (!isMechaEnemy) isMechaEnemy = true;
        if (currentCancha == 1) {
            cameraManager.ZoomCancha1();
            if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", true);
        } else {
            cameraManager.ZoomCancha2();
            if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", false);
        }
    }

    public void SetBocinEnemy()
    {
        if (!isMechaEnemy)
        {
            isLaunching2P = false;
            step = 4;
            if (!isBocinEnemy) isBocinEnemy = true;
            if (currentCancha == 1) {
                cameraManager.ZoomCancha1();
                if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", true);
            } else {
                cameraManager.ZoomCancha2();
                if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", false);
            }
        }
    }

    public void SetMononaEnemy()
    {
        step = 4;
        if (!isMononaEnemy) isMononaEnemy = true;
        isLaunching2P = false;
        if (currentCancha == 1) {
            cameraManager.ZoomCancha1();
            if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", true); 
        } else {
            cameraManager.ZoomCancha2();
            if (isBoss) boss.GetComponent<Animator>().SetBool("Cancha1", false);
        }
    }

    public void DrawLine()
    {
        ////Debug.Log("DrawLine");
        if (GlobalVars.Instance.gameType == "Training")
        {
            if (!isMecha && !isBocin && !isMonona && !hitOutside)
            {
                line1.SetActive(true);
                LineRenderer lRend = line1.GetComponent<LineRenderer>();
                lRend.SetPosition(0, tejoPosition);
                if (currentCancha == 1)
                {
                    lRend.SetPosition(1, tablero1.transform.position);
                    distanciaTejoTraining = Vector3.Distance(tejoPosition, tablero1.transform.position);
                }
                else
                {
                    lRend.SetPosition(1, tablero2.transform.position);
                    distanciaTejoTraining = Vector3.Distance(tejoPosition, tablero2.transform.position);
                }
            }
            checkMouse.checking = false;
        }
        else if ((GlobalVars.Instance.gameType == "Campeonato") || (GlobalVars.Instance.gameType == "Reto"))
        {
            if (!isMecha && !isMechaEnemy && !isBocin && !isBocinEnemy && !isMonona && !isMononaEnemy)
            {
                if (!hitOutside)
                {
                    line1.SetActive(true);
                    LineRenderer lRend = line1.GetComponent<LineRenderer>();
                    lRend.SetPosition(0, tejoPosition);
                    if (currentCancha == 1)
                    {
                        lRend.SetPosition(1, tablero1.transform.position);
                        distanciaTejo1 = Vector3.Distance(tejoPosition, tablero1.transform.position);
                    }
                    else
                    {
                        lRend.SetPosition(1, tablero2.transform.position);
                        distanciaTejo1 = Vector3.Distance(tejoPosition, tablero2.transform.position);
                    }
                }
                if (!hitOutsideEnemy)
                {
                    line2.SetActive(true);
                    LineRenderer lRend = line2.GetComponent<LineRenderer>();
                    lRend.SetPosition(0, tejoEnemyPosition);
                    if (currentCancha == 1)
                    {
                        lRend.SetPosition(1, tablero1.transform.position);
                        distanciaTejo2 = Vector3.Distance(tejoEnemyPosition, tablero1.transform.position);
                    }
                    else
                    {
                        lRend.SetPosition(1, tablero2.transform.position);
                        distanciaTejo2 = Vector3.Distance(tejoEnemyPosition, tablero2.transform.position);
                    }
                }
            }
        }
        else if (GlobalVars.Instance.gameType == "2Players")
        {
            if (!isMecha && !isMechaEnemy && !isBocin && !isBocinEnemy && !isMonona && !isMononaEnemy)
            {
                if (!hitOutside)
                {
                    line1.SetActive(true);
                    LineRenderer lRend = line1.GetComponent<LineRenderer>();
                    lRend.SetPosition(0, tejoPosition);
                    if (currentCancha == 1)
                    {
                        lRend.SetPosition(1, tablero1.transform.position);
                        distanciaTejo1 = Vector3.Distance(tejoPosition, tablero1.transform.position);
                    }
                    else
                    {
                        lRend.SetPosition(1, tablero2.transform.position);
                        distanciaTejo1 = Vector3.Distance(tejoPosition, tablero2.transform.position);
                    }
                }
                if (!hitOutsideEnemy)
                {
                    line2.SetActive(true);
                    LineRenderer lRend = line2.GetComponent<LineRenderer>();
                    lRend.SetPosition(0, tejoEnemyPosition);
                    if (currentCancha == 1)
                    {
                        lRend.SetPosition(1, tablero1.transform.position);
                        distanciaTejo2 = Vector3.Distance(tejoEnemyPosition, tablero1.transform.position);
                    }
                    else
                    {
                        lRend.SetPosition(1, tablero2.transform.position);
                        distanciaTejo2 = Vector3.Distance(tejoEnemyPosition, tablero2.transform.position);
                    }
                }
            }
        }
        turnoPlayer1 = false;
        Evaluate();
    }

    IEnumerator WaitForNextStepTraining()
    {
        yield return new WaitForSeconds(0.5f);
        step = 3;
    }

    public void CleanCanchaTraining()
    {
        checkMouse.checking = false;
        if (tejoPrefabClone) Destroy(tejoPrefabClone.gameObject);
        line1.SetActive(false);
    }

    public void CleanCancha()
    {
        if (tejoPrefabClone) Destroy(tejoPrefabClone.gameObject);
        if (tejoEnemyPrefabClone) Destroy(tejoEnemyPrefabClone.gameObject);
    }

    public bool HasWinner()
    {
        bool isWin = false;
        if ((score1 < maxPuntos) && (score2 < maxPuntos)) { isWin = false; }
        else { ShowResultado(); isWin = false;}
//        Debug.Log("HasWinner :: maxPuntos : " + maxPuntos + " score1:" + score1 + " score2:" + score2 + " isWin: " + isWin);
        return isWin;
    }

    public void ShowResultado() {
        Debug.Log("ShowResultado");
        cameraManager.ShowResultado();
        isPlaying = false;
    }
}
