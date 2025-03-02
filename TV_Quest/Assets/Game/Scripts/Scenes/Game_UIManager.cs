using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.iOS;
//using Google.Play.Review;

public class Game_UIManager : TejoScene
{
    public LogManager oLogManager;
    public PopupFinJuego popupFinJuego;
    public PopupJugarClasificacion popupTraining;

    private CameraManager cameraManager;
    public ADmob oADmob;
    public Communicator communicator;
    public GameObject loading;

    public Header header;
    public SponsorManager sponsorManager;
    public SpawnManager spawnManager;
    public AmbientManager ambientManager;
    public GameObject versusRojo;
    public GameObject versusAzul;
    public GameObject versusHexa;
    public AvatarWeb AvatarVersus1;
    public AvatarWeb AvatarVersus2;
    public GameObject enemyBoss;
    public Text userName_txt;
    public Text enemyName_txt;
    public Text departamento_txt;

    public AvatarWeb player1;
    public AvatarWeb player2;
    public GameObject boss;
    public AvatarWeb playerTraining;

    public Text player1_txt;
    public Text score1_txt;
    
    public Text player2_txt;
    public Text player2_departamento_txt;
    public Text score2_txt;

    public Text playerTraining_txt;
    public Text[] tablero;
    private int puntosTraining;

    public GameObject message;
    public Sprite[] avatarImages;
    private bool stepable = true;

    public GameObject juego;
    public GameObject juegoTraining;
    public FinChico finChico;
    
    public GameObject popupSalida;
    public GameObject popupPausa;
    public GameObject AyudaLanzamiento;
    public GameObject AyudaTraining;
    public GameObject Ayuda2Players;

    public Letrero LetreroMano;
    public Letrero LetreroMecha;
    public Letrero LetreroBocin;
    public Letrero LetreroMonona;
    public Letrero LetreroAlargue;

    public Text AgainBtn_text;
    public Text AlargarBtn_text;
    public GameObject AgainBtn;
    public GameObject AlargarBtn;
    public GameObject AlargarLoading;
    public GameObject MenuBtn;
    private int puntos_alargue = 4;

    public GameObject AgainTrainingBtn;
    public GameObject MenuTrainingBtn;

    private bool winner1 = false;
    private bool showResultado = false;

    private int currentStep = 0;
    public bool isBoss = false;

    private int nivelAJugar;

    //private ReviewManager oReviewManager;
    //private PlayReviewInfo oPlayReviewInfo;

    void Start()
    {
        
    }

    public override void Init()
    {
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
    }

    private void CargaAvatars()
    {
        oLogManager.Log("Game UI Manager: CargaAvatars() : " + GlobalVars.Instance.gameType);
        if (GlobalVars.Instance.gameType == "Campeonato")
        {
            player1_txt.text = GlobalVars.Instance.player1.nombre;
            player1.setAvatar(
                GlobalVars.Instance.player1.genero,
                GlobalVars.Instance.player1.cuerpo,
                GlobalVars.Instance.player1.cara,
                GlobalVars.Instance.player1.cabello,
                GlobalVars.Instance.player1.pantalon,
                GlobalVars.Instance.player1.ropa,
                GlobalVars.Instance.player1.sombrero
                );

            if ((GlobalVars.Instance.currentMundo == 8) || (GlobalVars.Instance.currentMundo == 17) || (GlobalVars.Instance.currentMundo == 26) || (GlobalVars.Instance.currentMundo == 35) || (GlobalVars.Instance.currentMundo == 44) || (GlobalVars.Instance.currentMundo == 53) || (GlobalVars.Instance.currentMundo == 62) || (GlobalVars.Instance.currentMundo == 71) || (GlobalVars.Instance.currentMundo == 80)) isBoss = true;
            if (isBoss)
            {
                player2.gameObject.SetActive(false);
                player2_txt.text = "";
                boss.SetActive(true);
                boss.GetComponent<Boss>().SetBoss(GlobalVars.Instance.currentNivel);
            }
            else
            {
                player2_txt.text = GlobalVars.Instance.player2.nombre;
                player2_departamento_txt.text = "";
                player2.setAvatar(
                    GlobalVars.Instance.player2.genero,
                    GlobalVars.Instance.player2.cuerpo,
                    GlobalVars.Instance.player2.cara,
                    GlobalVars.Instance.player2.cabello,
                    GlobalVars.Instance.player2.pantalon,
                    GlobalVars.Instance.player2.ropa,
                    GlobalVars.Instance.player2.sombrero
                    );
            }
        }else if (GlobalVars.Instance.gameType == "Reto")
        {
            player1_txt.text = GlobalVars.Instance.player1.nombre;
            player1.setAvatar(
                GlobalVars.Instance.player1.genero,
                GlobalVars.Instance.player1.cuerpo,
                GlobalVars.Instance.player1.cara,
                GlobalVars.Instance.player1.cabello,
                GlobalVars.Instance.player1.pantalon,
                GlobalVars.Instance.player1.ropa,
                GlobalVars.Instance.player1.sombrero
                );

            player2_txt.text = GlobalVars.Instance.player2.nombre;
            player2_departamento_txt.text = GlobalVars.Instance.reto_departamento;
            player2.setAvatar(
                GlobalVars.Instance.player2.genero,
                GlobalVars.Instance.player2.cuerpo,
                GlobalVars.Instance.player2.cara,
                GlobalVars.Instance.player2.cabello,
                GlobalVars.Instance.player2.pantalon,
                GlobalVars.Instance.player2.ropa,
                GlobalVars.Instance.player2.sombrero
                );
        }
        else if (GlobalVars.Instance.gameType == "Training")
        {
            playerTraining_txt.text = GlobalVars.Instance.player1.nombre;
            playerTraining.setAvatar(
                GlobalVars.Instance.player1.genero,
                GlobalVars.Instance.player1.cuerpo,
                GlobalVars.Instance.player1.cara,
                GlobalVars.Instance.player1.cabello,
                GlobalVars.Instance.player1.pantalon,
                GlobalVars.Instance.player1.ropa,
                GlobalVars.Instance.player1.sombrero
                );
        }else if (GlobalVars.Instance.gameType == "2Players")
        {
            player1_txt.text = GlobalVars.Instance.player1.nombre;
            player1.setAvatar(
                GlobalVars.Instance.player1.genero,
                GlobalVars.Instance.player1.cuerpo,
                GlobalVars.Instance.player1.cara,
                GlobalVars.Instance.player1.cabello,
                GlobalVars.Instance.player1.pantalon,
                GlobalVars.Instance.player1.ropa,
                GlobalVars.Instance.player1.sombrero
                );
            player2_txt.text = GlobalVars.Instance.player2.nombre;
            player2_departamento_txt.text = "";
            player2.setAvatar(
                GlobalVars.Instance.player2.genero,
                GlobalVars.Instance.player2.cuerpo,
                GlobalVars.Instance.player2.cara,
                GlobalVars.Instance.player2.cabello,
                GlobalVars.Instance.player2.pantalon,
                GlobalVars.Instance.player2.ropa,
                GlobalVars.Instance.player2.sombrero
                );
        }
    }

    public void AceptaAyuda()
    {
        audioManager.SetClick();
        cameraManager.PauseAnim(false);
        switch (GlobalVars.Instance.gameType)
        {
            case "Campeonato":
                juego.SetActive(true);
                AyudaLanzamiento.SetActive(false);
            break;
            case "Reto":
                juego.SetActive(true);
                AyudaLanzamiento.SetActive(false);
            break;
            case "Training":
                juegoTraining.SetActive(true);
                AyudaTraining.SetActive(false);
            break;
            case "2Players":
                juego.SetActive(true);
                Ayuda2Players.SetActive(false);
            break;
        }
        CargaAvatars();
    }

    private void Update()
    {
        if (GlobalVars.Instance.gameType != "Training")
        {
            score1_txt.text = spawnManager.score1.ToString();
            score2_txt.text = spawnManager.score2.ToString();
        }
        audioManager.SetNivel(true);
    }

    public void SetMessage(int _currentstep, string _titulo, string _mensaje, float _duration = 1f, bool _stepable = true)
    {
        currentStep = _currentstep;
        stepable = _stepable;
        message.SetActive(true);
        message.GetComponent<Message>().SetMessage(_titulo, _mensaje, _duration);
    }

    public void HideMessage()
    {
        message.SetActive(false);
        if (stepable)
        {
            spawnManager.step = currentStep + 1;
            stepable = false;
        }
        spawnManager.canLaunch = true;
    }

    public void SetPuntosTraining(int turno, int valor)
    {
        puntosTraining = puntosTraining + valor;
        tablero[turno].text = valor.ToString();
    }

    // ----------------------------- RESULTADO ------------------------------//

    private void SetWinner(int _score1, int _score2, int _numManos, int _numMechas, int _numBocines, int _numMononas)
    {
        if (_score1 > _score2)
        {
            winner1 = true;
        }
        else
        {
            puntos_alargue = _score2 + (_score2 - _score1);
        }
        finChico.SetFinChico(_score1, _score2, _numManos, _numMechas, _numBocines, _numMononas);
    }

    public void ShowResultado()
    {
        if (!showResultado)
        {
            //Debug.Log("ShowResultado");
            if ((GlobalVars.Instance.gameType == "Campeonato") || (GlobalVars.Instance.gameType == "Reto"))
            {
                SetWinner(spawnManager.score1, spawnManager.score2, spawnManager.numManos, spawnManager.numMechas, spawnManager.numBocines, spawnManager.numMononas);
            }
            else if (GlobalVars.Instance.gameType == "2Players")
            {
                finChico.SetFinChico2Players();
            }
            else if (GlobalVars.Instance.gameType == "Training")
            {
                finChico.SetFinChicoTraining();
            }
            showResultado = true;
        }
        
    }

    public void SetAdWinner() {
        if(GlobalVars.Instance.player1.idUser != "")
        {
            SetPopupFinJuego();
        }
        else
        {
            SetSiguiente();
        }
    }

    public void SetAdLoser() {
        //oADmob.ShowVideo();
        SetRevancha();
    }

    public void SetRevancha()
    {
        Debug.Log("Game_UIManager :: SetRevancha");
        AgainBtn.SetActive(true);
        MenuBtn.SetActive(true);
        AlargarLoading.SetActive(true);
        AgainBtn_text.text = "Revancha!";
        AlargarBtn_text.text = "a " + (puntos_alargue) + " puntos";
        if (oADmob.rewardedOK)
        {
            AlargarBtn.SetActive(true);
        }
    }

    public void CleanUI()
    {
        AgainBtn.SetActive(false);
        MenuBtn.SetActive(false);
        AlargarBtn.SetActive(false);
        AlargarLoading.SetActive(false);
        finChico.loser_text.text = "";
    }

    public void AlargarChico()
    {
        if (spawnManager.currentCancha == 1)
        {
            cameraManager.animator.SetInteger("GoAnim", 2);
            spawnManager.currentCancha = 2;
        }
        else
        {
            cameraManager.animator.SetInteger("GoAnim", 4);
            spawnManager.currentCancha = 1;
        }
        
        //isAlargandoChico = true;
        spawnManager.maxPuntos = puntos_alargue;
        LetreroAlargue.show("A " + puntos_alargue + " PUNTOS!");
        cameraManager.animator.SetBool("Resultado", false);
        juego.SetActive(true);
        spawnManager.step = 0;
        spawnManager.CleanCancha();
        spawnManager.isPlaying = true;
        finChico.AlargarChico();
        showResultado = false;
    }

    private void SetPopupFinJuego()
    {
        if (GlobalVars.Instance.gameType == "Training") { finChico.SetPopupFinJuegoTraining(puntosTraining); }
        else { finChico.SetPopupFinJuego(); }
    }

    public void SetSiguiente()
    {
        Debug.Log("SetSiguiente");
        setUserAvatar();
        setEnemyAvatar();

        if (GlobalVars.Instance.gameType == "Campeonato")
        {
            if (GlobalVars.Instance.player1.idUser != "")
            {
                if (GlobalVars.Instance.numWord <= 81)
                {
                    communicator.UpdateCampeonatoUser(GlobalVars.Instance.player1.idUser);
                }
                else
                {
                    communicator.UpdateCampeonatoUser(GlobalVars.Instance.player1.idUser);
                    GoGracias();
                }
            }
            else
            {
                AgainBtn.SetActive(true);
                AgainBtn_text.text = "Siguiente";
                MenuBtn.SetActive(true);
            }
        }
        else if (GlobalVars.Instance.gameType == "Reto")
        {
            AgainBtn.SetActive(true);
            AgainBtn_text.text = "Siguiente";
            MenuBtn.SetActive(true);
        }
        else if (GlobalVars.Instance.gameType == "Training")
        {
            AgainTrainingBtn.SetActive(true);
            MenuTrainingBtn.SetActive(true);
        }
        else if (GlobalVars.Instance.gameType == "2Players")
        {
            //AgainTrainingBtn.SetActive(true);
            //MenuTrainingBtn.SetActive(true);
        }
    }

    // ----------------------------- SIGUIENTE ------------------------------//

    public void AgainClick()
    {
        //ADmob.Instance.DeleteVideo();
        audioManager.SetClick();
        oADmob.ShowVideo();
        if (GlobalVars.Instance.gameType == "2Players")
        {
            navigationManager.goGame();
        }
        else
        {
            if (winner1)
            {
                finChico.CloseFinJuego();
                NextEnemy();
            }
            else
            {
                navigationManager.goGame();
            }
        }
        
    }

    private void NextEnemy()
    {
        if (GlobalVars.Instance.gameType == "Campeonato")
        {
            departamento_txt.text = "";
            if ((GlobalVars.Instance.currentMundo == 8) || (GlobalVars.Instance.currentMundo == 17) || (GlobalVars.Instance.currentMundo == 26) || (GlobalVars.Instance.currentMundo == 35) || (GlobalVars.Instance.currentMundo == 44) || (GlobalVars.Instance.currentMundo == 53) || (GlobalVars.Instance.currentMundo == 62) || (GlobalVars.Instance.currentMundo == 71) || (GlobalVars.Instance.currentMundo == 80))
            {
                AvatarVersus2.gameObject.SetActive(false);
                enemyName_txt.gameObject.SetActive(false);
                enemyBoss.SetActive(true);
                enemyBoss.GetComponent<Boss>().SetBoss(GlobalVars.Instance.currentNivel);
            }
        }
        else if (GlobalVars.Instance.gameType == "Reto")
        {
            loading.SetActive(true);
            communicator.refreshReto(GlobalVars.Instance.reto_number.ToString());
        }
        versusRojo.GetComponent<Animator>().SetBool("enter", true);
        versusAzul.GetComponent<Animator>().SetBool("enter", true);
        versusHexa.GetComponent<Animator>().SetBool("enter", true);
    }

    public void setUserAvatar()
    {
        AvatarVersus1.setAvatar(GlobalVars.Instance.player1.genero, GlobalVars.Instance.player1.cuerpo, GlobalVars.Instance.player1.cara, GlobalVars.Instance.player1.cabello, GlobalVars.Instance.player1.pantalon, GlobalVars.Instance.player1.ropa, GlobalVars.Instance.player1.sombrero);
        userName_txt.text = GlobalVars.Instance.player1.nombre;
    }
    public void setEnemyAvatar()
    {
        AvatarVersus2.gameObject.SetActive(true);

        int genero = GlobalVars.Instance.nivel1[GlobalVars.Instance.currentMundo].genero;
        int cuerpo = GlobalVars.Instance.nivel1[GlobalVars.Instance.currentMundo].cuerpo;
        int cara = GlobalVars.Instance.nivel1[GlobalVars.Instance.currentMundo].cara;
        int cabello = GlobalVars.Instance.nivel1[GlobalVars.Instance.currentMundo].cabello;
        int pantalon = GlobalVars.Instance.nivel1[GlobalVars.Instance.currentMundo].pantalon;
        int ropa = GlobalVars.Instance.nivel1[GlobalVars.Instance.currentMundo].ropa;
        int sombrero = GlobalVars.Instance.nivel1[GlobalVars.Instance.currentMundo].sombrero;
        string nombre = GlobalVars.Instance.nivel1[GlobalVars.Instance.currentMundo].nombre;

        AvatarVersus2.setAvatar(genero, cuerpo, cara, cabello, pantalon, ropa, sombrero);
        GlobalVars.Instance.player2 = new Player();
        GlobalVars.Instance.player2.SetPlayer(genero, cuerpo, cara, cabello, pantalon, ropa, sombrero, nombre);
        enemyName_txt.text = nombre;
    }

    public void AgainTraining()
    {
        popupTraining.gameObject.SetActive(true);
    }

    // ----------------------------- COMUNICATION ------------------------------//

    public void OnRefreshRetoResult(JSONObject dataJSON)
    {
        loading.SetActive(false);
        JSONObject result = dataJSON[0];
        Debug.Log(result.GetField("status").str);

        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.reto_avatar = result.GetField("avatar").str;
            GlobalVars.Instance.reto_municipio = result.GetField("municipio").str;
            GlobalVars.Instance.reto_departamento = result.GetField("departamento").str;
            GlobalVars.Instance.reto_idRegion = int.Parse(result.GetField("idRegion").str);
            GlobalVars.Instance.reto_number = int.Parse(result.GetField("game_order").str);
            GlobalVars.Instance.reto_level = int.Parse(result.GetField("level").str);

            string[] avatar = GlobalVars.Instance.reto_avatar.Split(char.Parse("|"));

            AvatarVersus2.setAvatar(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]));
            GlobalVars.Instance.player2 = new Player();
            GlobalVars.Instance.player2.SetPlayer(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]), GlobalVars.Instance.reto_municipio);
            enemyName_txt.text = GlobalVars.Instance.reto_municipio;
            departamento_txt.text = GlobalVars.Instance.reto_departamento;
        }
    }
    public void OnSetCampeonato(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        Debug.Log(result.GetField("status").str);

        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.SaveGlobalUserVars(result);
        }
        AgainBtn.SetActive(true);
        AgainBtn_text.text = "Siguiente";
        MenuBtn.SetActive(true);
    }

    // ----------------------------- NAVIGATION ------------------------------//

    public void GoTraining()
    {
        int precio = 100 + GlobalVars.Instance.progress;
        header.Debitar(precio, "Training");
    }

    public void GoGame()
    {
        if (GlobalVars.Instance.numWord <= 9) { GlobalVars.Instance.currentNivel = 0;
        } else if ((GlobalVars.Instance.numWord > 9) && (GlobalVars.Instance.numWord <= 18)) { GlobalVars.Instance.currentNivel = 1;
        } else if ((GlobalVars.Instance.numWord > 18) && (GlobalVars.Instance.numWord <= 27)) { GlobalVars.Instance.currentNivel = 2;
        } else if ((GlobalVars.Instance.numWord > 27) && (GlobalVars.Instance.numWord <= 36)) { GlobalVars.Instance.currentNivel = 3;
        } else if ((GlobalVars.Instance.numWord > 36) && (GlobalVars.Instance.numWord <= 45)) { GlobalVars.Instance.currentNivel = 4;
        } else if ((GlobalVars.Instance.numWord > 45) && (GlobalVars.Instance.numWord <= 54)) { GlobalVars.Instance.currentNivel = 5;
        } else if ((GlobalVars.Instance.numWord > 54) && (GlobalVars.Instance.numWord <= 63)) { GlobalVars.Instance.currentNivel = 6;
        } else if ((GlobalVars.Instance.numWord > 63) && (GlobalVars.Instance.numWord <= 72)) { GlobalVars.Instance.currentNivel = 7;
        } else if (GlobalVars.Instance.numWord > 72) { GlobalVars.Instance.currentNivel = 8; }
        
        navigationManager.goGame();
    }

    public void GoEntrada()
    {
        GlobalVars.Instance.jumpTo = "MainMenu";
        navigationManager.goEntrada();
    }

    public void GoMenu()
    {
        switch (GlobalVars.Instance.gameType)
        {
            case "Campeonato"   : GoCampeonato();   break;
            case "Reto"         : GoEntrada();      break;
            case "Training"     : GoEntrada();      break;
            case "2Players"     : GoEntrada();      break;
            default             : GoEntrada();      break;
        }
    }

    public void GoCampeonato()
    {
        GlobalVars.Instance.jumpTo = "Campeonato";
        navigationManager.goEntrada();
    }

    public void GoAvatar()
    {
        GlobalVars.Instance.jumpTo = "Avatar";
        navigationManager.goEntrada();
    }

    public void GoTrofeos()
    {
        if (GlobalVars.Instance.currentMundo > 80)
        {
            GlobalVars.Instance.jumpTo = "Gracias";
            navigationManager.goEntrada();
        }
        else
        {
            GlobalVars.Instance.jumpTo = "Trofeos";
            navigationManager.goEntrada();
        }
    }

    public void GoGracias()
    {
        GlobalVars.Instance.jumpTo = "Gracias";
        navigationManager.goEntrada();
    }

    // ADS

    public void ShowRewardedVideo()
    {
        oADmob.ShowRewardedVideo();
    }

    // ------------------------------ RATE ------------------------- //

    private void SetupAndroidReview()
    {
        //var requestFlowOperation = oReviewManager.RequestReviewFlow();
        //if (requestFlowOperation.Error != ReviewErrorCode.NoError) { Debug.Log(requestFlowOperation.Error.ToString()); }
        //oPlayReviewInfo = requestFlowOperation.GetResult();
    }
    public void ShowRateUs()
    {
        Debug.Log("ShowRateUs : " + GlobalVars.Instance.device);
        if (GlobalVars.Instance.device == "Android")
        {
            try
            {
                //var launchFlowOperation = oReviewManager.LaunchReviewFlow(oPlayReviewInfo);
                //oPlayReviewInfo = null; // Reset the object
                //if (launchFlowOperation.Error != ReviewErrorCode.NoError) { Debug.Log(launchFlowOperation.Error.ToString()); }
            }
            catch (Exception e) { Debug.Log(e); }

        }
        else
        {
            //Device.RequestStoreReview();
        }

    }

}
