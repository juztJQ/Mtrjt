using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entrada_UIManager : TejoScene
{
    public LogManager oLogManager;
    public BackgroundManager backgroundManager;
    public GameObject loading;
    public Communicator communicator;
    public ADmob oADmob;
    public GameObject popupDisclaimer;
    public GameObject popupLogin;
    public GameObject popupRegistro;
    public GameObject popupInvitado;
    public GameObject popupPromo;
    public PromoManager promoManager;
    public PopupJugarClasificacion popupTraining;

    public AvatarWeb AvatarVersus1;
    public AvatarWeb AvatarVersus2;
    public GameObject enemyBoss;
    public Text userName_txt;
    public Text enemyName_txt;
    public Text departamento_txt;
    public Text letrero_txt;

    public GameObject background_01;
    public GameObject background_02;
    public GameObject background_03;

    public GameObject tabBar;

    public GameObject logo;
    public GameObject jugar;
    public GameObject botoneraEnter;

    public Header header;
    public RetoBox retoBox;
    public GameObject botoneraReto;

    public GameObject niveles;
    public GameObject letrero;
    public GameObject volverNiveles;
    public ScrollSnapRect nivelScrollSnap;
    public int currentNivel = 0;
    private int mundo_selected;

    public GameObject versus_rojo;
    public GameObject versus_azul;
    public GameObject versus_hexagono;
    public GameObject retoTitulo;

    public GameObject ayudaChucho;
    public GameObject ayudaInfo;

    public AvatarManager avatarManager;
    public GameObject banio;
    public GameObject cambioContrasenaBtn;

    public TrofeosManager trofeos;
    public GameObject AvatarWeb;
    public Header headerLite;

    public ClasificacionManager clasificacion;
    public GameObject ClasifScoreboard;
    public GameObject ClasifJugar;

    public GameObject Gracias;
    public CreditosManager Creditos;

    public GameObject versus_liston_rojo;
    public GameObject versus_liston_azul;
    public GameObject liston2Players;
    public GameObject players1;
    public GameObject players2;
    public Text players1_nombre;
    public InputField players2_nombre;
    public AvatarWeb playersAvatar1;
    public AvatarWeb playersAvatar2;

    private string state = "Backgrounds";


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        /*
        PlayerPrefs.SetString("idUser", "38930");
        PlayerPrefs.SetString("nombre", "Virtual tejo Móvil");
        PlayerPrefs.SetInt("genero", 1);
        PlayerPrefs.SetInt("cuerpo", 1);
        PlayerPrefs.SetInt("cara", 1);
        PlayerPrefs.SetInt("cabello", 1);
        PlayerPrefs.SetInt("pantalon", 1);
        PlayerPrefs.SetInt("ropa", 1);
        PlayerPrefs.SetInt("sombrero", 1);

        PlayerPrefs.SetInt("currentMundo", 7);
        PlayerPrefs.SetInt("nivel", 0);
        PlayerPrefs.SetInt("numWord", 8);
        PlayerPrefs.SetString("starsString", "1|2|3|1|2|3|1");

        PlayerPrefs.SetInt("hasPolaOro", 1);
        PlayerPrefs.SetInt("hasMechaOro", 1);
        PlayerPrefs.SetInt("hasSuperBocin", 0);
        PlayerPrefs.SetInt("hasGallina", 1);
        PlayerPrefs.SetInt("hasPetacoOro", 1);
        PlayerPrefs.SetInt("hasCabezaLechona", 0);
        PlayerPrefs.SetInt("hasCariador", 1);
        PlayerPrefs.SetInt("hasBofeOro", 1);
        PlayerPrefs.SetInt("hasFritanga", 0);

        PlayerPrefs.Save();
        */
        CheckInternet();
        Init();
    }

    public override void Init()
    {
        if (InternetOn())
        {
            loading.SetActive(true);
            GlobalVars.Instance.GetCache();
            GlobalVars.Instance.SetNivel();
            CheckCache();
        }
    }

    public void CheckCache()
    {
        loading.SetActive(true);
        if (PlayerPrefs.GetString("idUser") != "") // hay caché
        {
            if (PlayerPrefs.HasKey("currentMundo"))
            {
                communicator.SetCacheUser(PlayerPrefs.GetString("idUser"));
                Debug.Log("Hay Mucho Cache: " + PlayerPrefs.GetString("idUser"));
            }
            else
            {
                Debug.Log("Hay Cache: " + PlayerPrefs.GetString("idUser"));
                communicator.getUser(PlayerPrefs.GetString("idUser"));
            }
        }
        else
        {
            Debug.Log("No Hay Cache: " + PlayerPrefs.GetString("idUser"));
            retoBox.SetRetoBox();
            header.SetHeader();
            header.SetHeaderLite();
            avatarManager.SetAvatarManager();
        }
        backgroundManager.SetLoadBack();
    }

    public void setUserAvatar()
    {
        AvatarVersus1.setAvatar(GlobalVars.Instance.player1.genero, GlobalVars.Instance.player1.cuerpo, GlobalVars.Instance.player1.cara, GlobalVars.Instance.player1.cabello, GlobalVars.Instance.player1.pantalon, GlobalVars.Instance.player1.ropa, GlobalVars.Instance.player1.sombrero);
        playersAvatar1.setAvatar(GlobalVars.Instance.player1.genero, GlobalVars.Instance.player1.cuerpo, GlobalVars.Instance.player1.cara, GlobalVars.Instance.player1.cabello, GlobalVars.Instance.player1.pantalon, GlobalVars.Instance.player1.ropa, GlobalVars.Instance.player1.sombrero);
        userName_txt.text = GlobalVars.Instance.player1.nombre;
        players1_nombre.text = GlobalVars.Instance.player1.nombre;
        avatarManager.SetAvatarManager();
    }
    public void setEnemyAvatar(int _genero, int _cuerpo, int _cara, int _cabello, int _pantalon, int _ropa, int _sombrero, string _nombre)
    {
        AvatarVersus2.setAvatar(_genero, _cuerpo, _cara, _cabello, _pantalon, _ropa, _sombrero);
        enemyName_txt.text = _nombre;
    }

    public void SetNivel()
    {
        niveles.SetActive(true);
        nivelScrollSnap.startingPage = GlobalVars.Instance.nivel;
        //currentNivel = nivelScrollSnap.startingPage;
        letrero_txt.text = GlobalVars.Instance.niveles[GlobalVars.Instance.nivel];
    }

    public void SetLetreroNivel()
    {
        letrero_txt.text = GlobalVars.Instance.niveles[nivelScrollSnap._currentPage];
    }

    public void ClickNivel(int _mundo)
    {
        Debug.Log("XX :: ClickNivel - player1.idUser: " + GlobalVars.Instance.player1.idUser);
        mundo_selected = _mundo;
        audioManager.SetClick();
        departamento_txt.text = "";

        if (GlobalVars.Instance.player1.idUser != "")
        { //
            GoNivel();
        }
        else
        {
            GlobalVars.Instance.invitadoSelection = "campeonato";
            popupLogin.gameObject.SetActive(true);
        }
    }

    public void GoNivel()
    {
        Debug.Log("XX :: GoNivel - mundo_selected: " + mundo_selected);
        if ((mundo_selected + 1) <= GlobalVars.Instance.numWord){
            audioManager.SetClick();
            GlobalVars.Instance.currentMundo = mundo_selected;
            if ((mundo_selected + 1) == GlobalVars.Instance.numWord) GlobalVars.Instance.punteando = true; else GlobalVars.Instance.punteando = false;
        }

        if (mundo_selected <= 8){ GlobalVars.Instance.currentNivel = 0;}
        else if ((mundo_selected > 8) && (mundo_selected <= 17)) { GlobalVars.Instance.currentNivel = 1;}
        else if ((mundo_selected > 17) && (mundo_selected <= 26)){ GlobalVars.Instance.currentNivel = 2;}
        else if ((mundo_selected > 26) && (mundo_selected <= 35)){ GlobalVars.Instance.currentNivel = 3;}
        else if ((mundo_selected > 35) && (mundo_selected <= 44)){ GlobalVars.Instance.currentNivel = 4;}
        else if ((mundo_selected > 44) && (mundo_selected <= 53)){ GlobalVars.Instance.currentNivel = 5;}
        else if ((mundo_selected > 53) && (mundo_selected <= 62)){ GlobalVars.Instance.currentNivel = 6;}
        else if ((mundo_selected > 62) && (mundo_selected <= 71)){ GlobalVars.Instance.currentNivel = 7;}
        else if (mundo_selected > 71){ GlobalVars.Instance.currentNivel = 8; }

        if ((GlobalVars.Instance.currentMundo == 8) || (GlobalVars.Instance.currentMundo == 17) || (GlobalVars.Instance.currentMundo == 26) || (GlobalVars.Instance.currentMundo == 35) || (GlobalVars.Instance.currentMundo == 44) || (GlobalVars.Instance.currentMundo == 53) || (GlobalVars.Instance.currentMundo == 62) || (GlobalVars.Instance.currentMundo == 71) || (GlobalVars.Instance.currentMundo == 80))
        {
            AvatarVersus2.gameObject.SetActive(false);
            enemyName_txt.gameObject.SetActive(false);
            enemyBoss.SetActive(true);
            enemyBoss.GetComponent<Boss>().SetBoss(GlobalVars.Instance.currentNivel);
        }
        else
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

            setEnemyAvatar(genero, cuerpo, cara, cabello, pantalon, ropa, sombrero, nombre);
            GlobalVars.Instance.player2 = new Player();
            GlobalVars.Instance.player2.SetPlayer(genero, cuerpo, cara, cabello, pantalon, ropa, sombrero, nombre);
        }
        GlobalVars.Instance.gameType = "Campeonato";
        GoVersus();
    }

    public void ClickReto()
    {
        if (GlobalVars.Instance.player1.idUser != "")
        {
            GoReto();
        }
        else
        {
            GoMainMenu();
            GlobalVars.Instance.invitadoSelection = "reto";
            popupLogin.gameObject.SetActive(true);
        }
    }

    public void GoReto()
    {
        GlobalVars.Instance.invitadoSelection = "";
        string[] avatar = GlobalVars.Instance.reto_avatar.Split(char.Parse("|"));
        GlobalVars.Instance.player2 = new Player();
        GlobalVars.Instance.player2.SetPlayer(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]), GlobalVars.Instance.reto_municipio);
        GlobalVars.Instance.gameType = "Reto";
        departamento_txt.text = GlobalVars.Instance.reto_departamento;
        setEnemyAvatar(int.Parse(avatar[0]), int.Parse(avatar[1]), int.Parse(avatar[2]), int.Parse(avatar[3]), int.Parse(avatar[4]), int.Parse(avatar[5]), int.Parse(avatar[6]), GlobalVars.Instance.reto_municipio);
        GoVersus();
    }

    // ----------------------------- POPUPS ------------------------------//

    public void setPopupLogin() { popupLogin.SetActive(true); }
    public void setPopupRegistro() { popupRegistro.SetActive(true); }
    public void setPopupInvitado() { popupInvitado.SetActive(true); }
    public void cancelPopupInvitado() { popupInvitado.SetActive(false); }

    // ----------------------------- COMUNICATION ------------------------------//

    public void onSetCacheUserResult(JSONObject dataJSON)
    {
        
        JSONObject result = dataJSON[0];
        Debug.Log(result.GetField("status").str);

        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.SaveGlobalUserVars(result);

            retoBox.SetRetoBox();
            header.SetHeader();
            header.SetHeaderLite();
            avatarManager.SetAvatarManager();
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("idUser", GlobalVars.Instance.player1.idUser);
            PlayerPrefs.Save();
        }
        else
        {
            popupLogin.SetActive(true);
        }
        header.SetAvatar();
        setUserAvatar();
    }

    public void onGetUserResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        Debug.Log(result.GetField("status").str);

        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.SaveGlobalUserVars(result);

            header.SetDefaultData();
            retoBox.SetRetoBox();
            avatarManager.SetAvatarManager();
        }
        else
        {
            popupLogin.SetActive(true);
        }
        header.SetAvatar();
        setUserAvatar();
    }

    public void onSetUserResult(JSONObject dataJSON)
    {
        loading.SetActive(false);
        JSONObject result = dataJSON[0];
        if (result.GetField("status").str == "existe")
        {
            popupRegistro.SetActive(false);
            popupLogin.SetActive(false);

            GlobalVars.Instance.SaveGlobalUserVars(result);

            header.SetDefaultData();
            header.SetAvatar();
            setUserAvatar();
            retoBox.SetRetoBox();

        } else if (result.GetField("status").str == "yaExiste") { SetError("Error", "Ya existe un jugador con ese email \n Intente con otro!");
        } else if (result.GetField("status").str == "errorLogin") { SetError("Hay sumercé", "No lo encontré registrado \n Revise sus datos!");
        } else if (result.GetField("status").str == "error") { SetError("Error", "Hay sumercé se totió la conexión \n intente de nuevo!");
        } else { SetInternetError(); }
    }

    // ----------------------------- NAVIGATION ------------------------------//
    public void GoBackgrounds()
    {
        loading.SetActive(false);
        moveBackground("enter");
    }

    public void CheckJump()
    {
        //GlobalVars.Instance.jumpTo = "Gracias";
        switch (GlobalVars.Instance.jumpTo)
        {
            case ""             : GoEnter();        break;
            case "MainMenu"     : GoMainMenu();     break;
            case "Campeonato"   : GoCampeonato();   break;
            case "Avatar"       : GoAvatar();       break;
            case "Trofeos"      : GoTrofeos();      break;
            case "Gracias"      : GoGracias();      break;
        }
    }

    public void loadPromo()
    {
        if (GlobalVars.Instance.showPromo) promoManager.loadPromo();
    }

    public void GoEnter()
    {
        header.nivel.SetNivel();
        header.GetComponent<Animator>().SetBool("enter", false);
        retoBox.GetComponent<Animator>().SetBool("enter", false);
        botoneraReto.GetComponent<Animator>().SetBool("enter", false);

        trofeos.GetComponent<Animator>().SetBool("enter", false);
        AvatarWeb.GetComponent<Animator>().SetBool("trofeos", false);
        headerLite.GetComponent<Animator>().SetBool("enter", false);

        ayudaChucho.GetComponent<Animator>().SetBool("enter", false);
        ayudaInfo.GetComponent<Animator>().SetBool("enter", false);

        Gracias.GetComponent<Animator>().SetBool("enter", false);
        Creditos.GetComponent<Animator>().SetBool("enter", false);

        logo.GetComponent<Animator>().SetBool("enter", true);
        jugar.GetComponent<Animator>().SetBool("enter", true);
        botoneraEnter.GetComponent<Animator>().SetBool("enter", true);
        tabBar.GetComponent<Animator>().SetBool("enter", true);
    }

    public void GoMainMenu()
    {
        state = "MainMenu";
        logo.GetComponent<Animator>().SetBool("enter", false);
        jugar.GetComponent<Animator>().SetBool("enter", false);
        botoneraEnter.GetComponent<Animator>().SetBool("enter", false);

        niveles.GetComponent<Animator>().SetBool("enter", false);
        letrero.GetComponent<Animator>().SetBool("enter", false);
        volverNiveles.GetComponent<Animator>().SetBool("enter", false);

        versus_rojo.GetComponent<Animator>().SetBool("enter", false);
        versus_azul.GetComponent<Animator>().SetBool("enter", false);
        versus_hexagono.GetComponent<Animator>().SetBool("enter", false);

        ClasifScoreboard.GetComponent<Animator>().SetBool("enter", false);
        ClasifJugar.GetComponent<Animator>().SetBool("enter", false);

        retoTitulo.GetComponent<Animator>().SetBool("enter", false);

        tabBar.GetComponent<Animator>().SetBool("enter", true);
        header.GetComponent<Animator>().SetBool("enter", true);
        retoBox.GetComponent<Animator>().SetBool("enter", true);
        botoneraReto.GetComponent<Animator>().SetBool("enter", true);

        if (GlobalVars.Instance.jump)
        {
            moveBackground("enter");
            GlobalVars.Instance.jump = false;
        }
        else
        {
            moveBackground("right");
        }
    }

    public void GoCampeonato()
    {
        //if (GlobalVars.Instance.player1.idUser != "") // hay caché
        //{
            state = "Campeonato";
            SetNivel();
            header.GetComponent<Animator>().SetBool("enter", true);
            retoBox.GetComponent<Animator>().SetBool("enter", false);
            botoneraReto.GetComponent<Animator>().SetBool("enter", false);
            tabBar.GetComponent<Animator>().SetBool("enter", false);

            niveles.GetComponent<Animator>().SetBool("enter", true);
            letrero.GetComponent<Animator>().SetBool("enter", true);
            volverNiveles.GetComponent<Animator>().SetBool("enter", true);

            moveBackground("left");
        //}
        //else
        //{
        //    GoMainMenu();
        //    popupLogin.gameObject.SetActive(true);
        //}
    }

    public void GoVersus()
    {
        oADmob.ShowVideo();
        state = "Versus";
        versus_rojo.GetComponent<Animator>().SetBool("enter", true);
        versus_azul.GetComponent<Animator>().SetBool("enter", true);
        versus_hexagono.GetComponent<Animator>().SetBool("enter", true);
        if(GlobalVars.Instance.gameType=="Reto") retoTitulo.GetComponent<Animator>().SetBool("enter", true);
    }

    public void CloseVersus()
    {
        versus_rojo.GetComponent<Animator>().SetBool("enter", false);
        versus_azul.GetComponent<Animator>().SetBool("enter", false);
        versus_hexagono.GetComponent<Animator>().SetBool("enter", false);
        retoTitulo.GetComponent<Animator>().SetBool("enter", false);
    }

    public void GoAyuda()
    {
        state = "Ayuda";
        logo.GetComponent<Animator>().SetBool("enter", false);
        jugar.GetComponent<Animator>().SetBool("enter", false);
        botoneraEnter.GetComponent<Animator>().SetBool("enter", false);
        header.GetComponent<Animator>().SetBool("enter", false);
        tabBar.GetComponent<Animator>().SetBool("enter", false);

        ayudaChucho.GetComponent<Animator>().SetBool("enter", true);
        ayudaInfo.GetComponent<Animator>().SetBool("enter", true);

        moveBackground("left");
    }

    public void GoAvatar()
    {
        if (GlobalVars.Instance.player1.idUser != "") // hay caché
        {
            state = "Avatar";
            logo.GetComponent<Animator>().SetBool("enter", false);
            jugar.GetComponent<Animator>().SetBool("enter", false);
            botoneraEnter.GetComponent<Animator>().SetBool("enter", false);
            header.GetComponent<Animator>().SetBool("enter", false);
            tabBar.GetComponent<Animator>().SetBool("enter", false);
            if (GlobalVars.Instance.player1.idFacebook != "") cambioContrasenaBtn.SetActive(false);
            banio.GetComponent<Animator>().SetBool("enter", true);
        }
        else
        {
            GoMainMenu();
            popupLogin.gameObject.SetActive(true);
        }
    }

    public void CloseAvatar()
    {
        banio.GetComponent<Animator>().SetBool("enter", false);
    }

    public void GoTrofeos()
    {
        if (GlobalVars.Instance.player1.idUser != "") // hay caché
        {
            state = "Trofeos";
            trofeos.SetTrofeos();
            logo.GetComponent<Animator>().SetBool("enter", false);
            jugar.GetComponent<Animator>().SetBool("enter", false);
            botoneraEnter.GetComponent<Animator>().SetBool("enter", false);
            header.GetComponent<Animator>().SetBool("enter", false);
            tabBar.GetComponent<Animator>().SetBool("enter", false);

            trofeos.GetComponent<Animator>().SetBool("enter", true);
            AvatarWeb.GetComponent<Animator>().SetBool("trofeos", true);
            headerLite.GetComponent<Animator>().SetBool("enter", true);
        }
        else
        {
            GoMainMenu();
            popupLogin.gameObject.SetActive(true);
        }
    }

    public void GoClasificacion()
    {
        state = "Clasificacion";
        retoBox.GetComponent<Animator>().SetBool("enter", false);
        botoneraReto.GetComponent<Animator>().SetBool("enter", false);
        tabBar.GetComponent<Animator>().SetBool("enter", false);

        ClasifScoreboard.GetComponent<Animator>().SetBool("enter", true);
        ClasifJugar.GetComponent<Animator>().SetBool("enter", true);

        moveBackground("left");
    }

    public void GoGracias()
    {
        state = "Gracias";

        logo.GetComponent<Animator>().SetBool("enter", false);
        jugar.GetComponent<Animator>().SetBool("enter", false);
        botoneraEnter.GetComponent<Animator>().SetBool("enter", false);
        tabBar.GetComponent<Animator>().SetBool("enter", false);

        retoBox.GetComponent<Animator>().SetBool("enter", false);
        botoneraReto.GetComponent<Animator>().SetBool("enter", false);

        header.GetComponent<Animator>().SetBool("enter", true);
        Gracias.GetComponent<Animator>().SetBool("enter", true);
        moveBackground("left");
    }

    public void GoCreditos()
    {
        state = "Creditos";
        Creditos.SetCreditos();
        logo.GetComponent<Animator>().SetBool("enter", false);
        jugar.GetComponent<Animator>().SetBool("enter", false);
        botoneraEnter.GetComponent<Animator>().SetBool("enter", false);
        header.GetComponent<Animator>().SetBool("enter", false);
        tabBar.GetComponent<Animator>().SetBool("enter", false);

        Creditos.GetComponent<Animator>().SetBool("enter", true);
        moveBackground("left");
    }

    public void GoGame()
    {
        navigationManager.goGame();
    }

    public void SetPopupTraining()
    {
        popupTraining.gameObject.SetActive(true);
    }

    public void GoTraining()
    {
        int precio = 100 + GlobalVars.Instance.progress;
        header.Debitar(precio, "Training");
    }

    public void Go2Players()
    {
        state = "2Players";
        SetEnemyVersus();
        header.GetComponent<Animator>().SetBool("enter", false);
        versus_liston_rojo.GetComponent<Animator>().SetBool("enter", true);
        versus_liston_azul.GetComponent<Animator>().SetBool("enter", true);
        liston2Players.GetComponent<Animator>().SetBool("enter", true);
        players1.GetComponent<Animator>().SetBool("enter", true);
        players2.GetComponent<Animator>().SetBool("enter", true);
        if (PlayerPrefs.HasKey("2Player_nombre")) players2_nombre.text = PlayerPrefs.GetString("2Player_nombre");
    }

    public void Click2Players()
    {
        GlobalVars.Instance.player2 = new Player();
        GlobalVars.Instance.player2.SetPlayer(playersAvatar2.genero, playersAvatar2.cuerpo, playersAvatar2.cara, playersAvatar2.cabello, playersAvatar2.pantalon, playersAvatar2.ropa, playersAvatar2.sombrero, players2_nombre.text);
        GlobalVars.Instance.gameType = "2Players";
        PlayerPrefs.SetString("2Player_nombre", players2_nombre.text);
        PlayerPrefs.Save();
        GoGame();
    }

    public void Close2Players()
    {
        versus_liston_rojo.GetComponent<Animator>().SetBool("enter", false);
        versus_liston_azul.GetComponent<Animator>().SetBool("enter", false);
        liston2Players.GetComponent<Animator>().SetBool("enter", false);
        header.GetComponent<Animator>().SetBool("enter", true);
        players1.GetComponent<Animator>().SetBool("enter", false);
        players2.GetComponent<Animator>().SetBool("enter", false);
    }

    public void SetEnemyVersus()
    {
        if (PlayerPrefs.HasKey("2Player_genero"))
        {
            playersAvatar2.setAvatar(PlayerPrefs.GetInt("2Player_genero"),
                                     PlayerPrefs.GetInt("2Player_cuerpo"),
                                     PlayerPrefs.GetInt("2Player_cara"),
                                     PlayerPrefs.GetInt("2Player_cabello"),
                                     PlayerPrefs.GetInt("2Player_pantalon"),
                                     PlayerPrefs.GetInt("2Player_ropa"),
                                     PlayerPrefs.GetInt("2Player_sombrero")
                                     );
        }
        else
        {
            RandomVersus();
        }

    }

    public void RandomVersus()
    {
        playersAvatar2.RandomAvatar();
        PlayerPrefs.SetInt("2Player_genero",    playersAvatar2.genero);
        PlayerPrefs.SetInt("2Player_cuerpo",    playersAvatar2.cuerpo);
        PlayerPrefs.SetInt("2Player_cara",      playersAvatar2.cara);
        PlayerPrefs.SetInt("2Player_cabello",   playersAvatar2.cabello);
        PlayerPrefs.SetInt("2Player_pantalon",  playersAvatar2.pantalon);
        PlayerPrefs.SetInt("2Player_ropa",      playersAvatar2.ropa);
        PlayerPrefs.SetInt("2Player_sombrero",  playersAvatar2.sombrero);
        PlayerPrefs.Save();       
    }

    // ----------------------------- BACKGROUND ------------------------------//

    public void moveBackground(string _direction)
    {
        switch (_direction)
        {
            case "enter":
                background_01.GetComponent<Animator>().SetInteger("state", 1);
                background_02.GetComponent<Animator>().SetInteger("state", 1);
                background_03.GetComponent<Animator>().SetInteger("state", 1);
            break;
            case "right":
                background_01.GetComponent<Animator>().SetInteger("state", 2);
                background_02.GetComponent<Animator>().SetInteger("state", 2);
                background_03.GetComponent<Animator>().SetInteger("state", 2);
            break;
            case "left":
                background_01.GetComponent<Animator>().SetInteger("state", 3);
                background_02.GetComponent<Animator>().SetInteger("state", 3);
                background_03.GetComponent<Animator>().SetInteger("state", 3);
            break;
        }
    }

    
}

