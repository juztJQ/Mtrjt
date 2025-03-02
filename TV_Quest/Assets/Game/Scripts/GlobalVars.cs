using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GlobalVars : MonoBehaviour
{
	public static GlobalVars Instance; //{ get; private set;}
    public AudioSource backgroundMusic;

    [NonSerialized] public string URL_HOST = "https://www.virtualtejo.com/";
    [NonSerialized] public string androidVersion    = "3.3.1";
    [NonSerialized] public string iosVersion        = "3.3.2";
    [NonSerialized] public string store_android     = "https://play.google.com/store/apps/details?id=me.alexsosa.virtualtejo";
    [NonSerialized] public string store_ios         = "https://apps.apple.com/co/app/virtual-tejo/id1484371222";

    //[NonSerialized] public string device = "Android";
    [NonSerialized] public string device = "iOs";

    [NonSerialized] public bool isBack = false;
    [NonSerialized] public bool showPromo = true;
    [NonSerialized] public int currentMundo;
    [NonSerialized] public int nivel = 0;
    [NonSerialized] public string invitadoSelection = "";
    [NonSerialized] public int currentNivel = 0;
    [NonSerialized] public int numWord = 1;
    [NonSerialized] public int progress;
    [NonSerialized] public int progress_init;
    [NonSerialized] public int progress_end;

    [NonSerialized] public string gameType;

    //Current Reto
    [NonSerialized] public string reto_avatar;
    [NonSerialized] public string reto_municipio;
    [NonSerialized] public string reto_departamento;
    [NonSerialized] public int reto_idRegion;
    [NonSerialized] public int reto_number;
    [NonSerialized] public int reto_level;
    //

    [NonSerialized] public bool punteando = true;
    [NonSerialized] public bool jump = false;
    [NonSerialized] public string jumpTo = "";

    public List<int> wordStars;
    [NonSerialized] public string starsString = "";
    [NonSerialized] public string[] niveles = { "Zona Centro", "Llanos Orientales", "Amazonía", "Pacífico", "Eje Cafetero", "Valle de Aburrá", "Caribe", "Santanderes", "Boyacá" };
    [NonSerialized] public List<Player> nivel1 = new List<Player>();
    [NonSerialized] public Player[] enemy2;
    [NonSerialized] public Player[] enemy3;
    [NonSerialized] public Player[] enemy4;
    [NonSerialized] public Player[] enemy5;
    [NonSerialized] public Player[] enemy6;

    [NonSerialized] public Player player1 = new Player();
    [NonSerialized] public Player player2 = new Player();

    [NonSerialized] public int coins                = 0;
    [NonSerialized] public int points               = 0;
    [NonSerialized] public int idZona               = 0;
    [NonSerialized] public int reto                 = 1;
    [NonSerialized] public int reto_jugadas         = 0;
    [NonSerialized] public int backgroundMusicON    = 1;
    [NonSerialized] public int soundEffectsON       = 1;
    [NonSerialized] public int vibracionON          = 1;
    [NonSerialized] public int hasTraining          = 0;
    [NonSerialized] public int has2Players          = 0;

    [NonSerialized] public int hasPolaOro       = 0;
    [NonSerialized] public int hasMechaOro      = 0;
    [NonSerialized] public int hasSuperBocin    = 0;
    [NonSerialized] public int hasGallina       = 0;
    [NonSerialized] public int hasPetacoOro     = 0;
    [NonSerialized] public int hasCabezaLechona = 0;
    [NonSerialized] public int hasCariador      = 0;
    [NonSerialized] public int hasFritanga      = 0;
    [NonSerialized] public int hasBofeOro       = 0;

    [NonSerialized] public int ganados = 0;
    [NonSerialized] public int perdidos = 0;

    [NonSerialized] public Cancha cancha = new Cancha();

    [NonSerialized] public int canchaSeleccionada = 0;


    void Awake()
	{
        Screen.sleepTimeout = (int)SleepTimeout.NeverSleep;
        if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
    }

    public void SaveGlobalUserVars(JSONObject result)
    {
        player1.idUser = result.GetField("idUser").str;
        player1.idFacebook = result.GetField("idFacebook").str;
        player1.nombre = result.GetField("nombre").str;
        player1.email = result.GetField("email").str;
        idZona = int.Parse(result.GetField("idZona").str);
        coins = int.Parse(result.GetField("coins").str);
        points = int.Parse(result.GetField("points").str);

        string avatar_str = result.GetField("avatar").str;
        string[] avatar = avatar_str.Split(char.Parse("|"));

        player1.genero = int.Parse(avatar[0]);
        player1.cuerpo = int.Parse(avatar[1]);
        player1.cara = int.Parse(avatar[2]);
        player1.cabello = int.Parse(avatar[3]);
        player1.pantalon = int.Parse(avatar[4]);
        player1.ropa = int.Parse(avatar[5]);
        player1.sombrero = int.Parse(avatar[6]);

        reto = int.Parse(result.GetField("reto").str);
        reto_jugadas = int.Parse(result.GetField("reto_jugadas").str);
        currentMundo = int.Parse(result.GetField("currentMundo").str);
        nivel = int.Parse(result.GetField("nivel").str);
        numWord = int.Parse(result.GetField("numWord").str);
        progress = int.Parse(result.GetField("progress").str);
        progress_init = int.Parse(result.GetField("progress_init").str);
        progress_end = int.Parse(result.GetField("progress_end").str);

        string trofeos_str = result.GetField("trofeos").str;
        string[] trofeos = trofeos_str.Split(char.Parse("|"));

        hasPolaOro = int.Parse(trofeos[0]);
        hasMechaOro = int.Parse(trofeos[1]);
        hasSuperBocin = int.Parse(trofeos[2]);
        hasGallina = int.Parse(trofeos[3]);
        hasPetacoOro = int.Parse(trofeos[4]);
        hasCabezaLechona = int.Parse(trofeos[5]);
        hasCariador = int.Parse(trofeos[6]);
        hasBofeOro = int.Parse(trofeos[7]);
        hasFritanga = int.Parse(trofeos[8]);

        starsString = result.GetField("starsString").str;
        if ((starsString != null)&& (starsString != ""))
        {
            string[] aWordStars = starsString.Split(char.Parse("|"));
            wordStars.Clear();
            for (int i = 0; i < aWordStars.Length; i++)
            {
                int temp = Convert.ToInt32(aWordStars[i]);
                wordStars.Add(temp);
            }
        }

        PlayerPrefs.SetString("idUser", player1.idUser);
        PlayerPrefs.Save();
    }

    public void SaveInvitadoUserVars()
    {
        player1.idUser = "";
        player1.nombre = "Player 1";
        player1.email = "";
        idZona = 0;
        coins = 0;
        points = 0;

        /*
        string avatar_str = "0|0|0|0|0|0|0";
        string[] avatar = avatar_str.Split(char.Parse("|"));

        player1.genero = int.Parse(avatar[0]);
        player1.cuerpo = int.Parse(avatar[1]);
        player1.cara = int.Parse(avatar[2]);
        player1.cabello = int.Parse(avatar[3]);
        player1.pantalon = int.Parse(avatar[4]);
        player1.ropa = int.Parse(avatar[5]);
        player1.sombrero = int.Parse(avatar[6]);
        */

        reto = (int)UnityEngine.Random.Range(0, 100);

        reto_jugadas = 0;
        currentMundo = 1;
        nivel = 1;
        numWord = 1;
        progress = 0;
        progress_init = 0;
        progress_end = 0;

        string trofeos_str = "0|0|0|0|0|0|0|0|0";
        string[] trofeos = trofeos_str.Split(char.Parse("|"));

        hasPolaOro = int.Parse(trofeos[0]);
        hasMechaOro = int.Parse(trofeos[1]);
        hasSuperBocin = int.Parse(trofeos[2]);
        hasGallina = int.Parse(trofeos[3]);
        hasPetacoOro = int.Parse(trofeos[4]);
        hasCabezaLechona = int.Parse(trofeos[5]);
        hasCariador = int.Parse(trofeos[6]);
        hasBofeOro = int.Parse(trofeos[7]);
        hasFritanga = int.Parse(trofeos[8]);

        starsString = "";

        PlayerPrefs.SetString("idUser", player1.idUser);
        PlayerPrefs.Save();
    }

    public void GetCache()
    {
        Debug.Log("GetCache . Exist: " + PlayerPrefs.HasKey("backgroundMusicON"));
        if (PlayerPrefs.HasKey("backgroundMusicON"))
        {
            backgroundMusicON = PlayerPrefs.GetInt("backgroundMusicON");
            soundEffectsON = PlayerPrefs.GetInt("soundEffectsON");
            vibracionON = PlayerPrefs.GetInt("vibracionON");
            hasTraining = PlayerPrefs.GetInt("hasTraining");
            has2Players = PlayerPrefs.GetInt("has2Players");
        }
        backgroundMusic = this.gameObject.GetComponent<AudioSource>();
        if ((backgroundMusicON == 1) && (!backgroundMusic.isPlaying)) backgroundMusic.Play();
    }

    public void SetCache()
    {
        PlayerPrefs.SetInt("backgroundMusicON", backgroundMusicON);
        PlayerPrefs.SetInt("soundEffectsON", soundEffectsON);
        PlayerPrefs.SetInt("vibracionON", vibracionON);
        PlayerPrefs.SetInt("hasTraining", hasTraining);
        PlayerPrefs.SetInt("has2Players", has2Players);
        PlayerPrefs.Save();
    }

    public void ResetAll()
    {
        currentMundo = 0;
        nivel = 0;
        numWord = 1;
        coins = 0;
    }

    public void deleteData()
    {
        player1.idUser = "";
        player1.idFacebook = "";
        player1.nombre = "Player 1";
        player1.email = "";
        idZona = 0;
        points = 0;
        coins = 0;
        player1.genero = 0;
        player1.cuerpo = 0;
        player1.cara = 0;
        player1.cabello = 0;
        player1.pantalon = 0;
        player1.ropa = 0;
        player1.sombrero = 0;
        currentMundo = 0;
        nivel = 0;
        numWord = 1;
        starsString = "";
        hasPolaOro = 0;
        hasMechaOro = 0;
        hasSuperBocin = 0;
        hasGallina = 0;
        hasPetacoOro = 0;
        hasCabezaLechona = 0;
        hasCariador = 0;
        hasBofeOro = 0;
        hasFritanga = 0;
        PlayerPrefs.SetString("idUser", "");
    }

    public void SetNivel()
    {
        Player enemy1 = new Player();
        Player enemy2 = new Player();
        Player enemy3 = new Player();
        Player enemy4 = new Player();
        Player enemy5 = new Player();
        Player enemy6 = new Player();
        Player enemy7 = new Player();
        Player enemy8 = new Player();
        Player enemyBoss1 = new Player();

        Player enemy9 = new Player();
        Player enemy10 = new Player();
        Player enemy11 = new Player();
        Player enemy12 = new Player();
        Player enemy13 = new Player();
        Player enemy14 = new Player();
        Player enemy15 = new Player();
        Player enemy16 = new Player();
        Player enemyBoss2 = new Player();

        Player enemy17 = new Player();
        Player enemy18 = new Player();
        Player enemy19 = new Player();
        Player enemy20 = new Player();
        Player enemy21 = new Player();
        Player enemy22 = new Player();
        Player enemy23 = new Player();
        Player enemy24 = new Player();
        Player enemyBoss3 = new Player();

        Player enemy25 = new Player();
        Player enemy26 = new Player();
        Player enemy27 = new Player();
        Player enemy28 = new Player();
        Player enemy29 = new Player();
        Player enemy30 = new Player();
        Player enemy31 = new Player();
        Player enemy32 = new Player();
        Player enemyBoss4 = new Player();

        Player enemy33 = new Player();
        Player enemy34 = new Player();
        Player enemy35 = new Player();
        Player enemy36 = new Player();
        Player enemy37 = new Player();
        Player enemy38 = new Player();
        Player enemy39 = new Player();
        Player enemy40 = new Player();
        Player enemyBoss5 = new Player();

        Player enemy41 = new Player();
        Player enemy42 = new Player();
        Player enemy43 = new Player();
        Player enemy44 = new Player();
        Player enemy45 = new Player();
        Player enemy46 = new Player();
        Player enemy47 = new Player();
        Player enemy48 = new Player();
        Player enemyBoss6 = new Player();

        Player enemy49 = new Player();
        Player enemy50 = new Player();
        Player enemy51 = new Player();
        Player enemy52 = new Player();
        Player enemy53 = new Player();
        Player enemy54 = new Player();
        Player enemy55 = new Player();
        Player enemy56 = new Player();
        Player enemyBoss7 = new Player();

        Player enemy57 = new Player();
        Player enemy58 = new Player();
        Player enemy59 = new Player();
        Player enemy60 = new Player();
        Player enemy61 = new Player();
        Player enemy62 = new Player();
        Player enemy63 = new Player();
        Player enemy64 = new Player();
        Player enemyBoss8 = new Player();

        Player enemy65 = new Player();
        Player enemy66 = new Player();
        Player enemy67 = new Player();
        Player enemy68 = new Player();
        Player enemy69 = new Player();
        Player enemy70 = new Player();
        Player enemy71 = new Player();
        Player enemy72 = new Player();
        Player enemyBoss9 = new Player();

        enemy1.SetPlayer(0, 0, 7, 0, 0, 5, 5, "Zipaquirá");
        enemy2.SetPlayer(1, 2, 3, 4, 0, 1, 3, "Chía");
        enemy3.SetPlayer(0, 2, 6, 4, 2, 1, 0, "Nemocón");
        enemy4.SetPlayer(0, 1, 1, 6, 5, 6, 1, "Sopó");
        enemy5.SetPlayer(1, 3, 1, 6, 7, 6, 1, "La Vega");
        enemy6.SetPlayer(0, 0, 1, 1, 1, 0, 4, "Villapinzón");
        enemy7.SetPlayer(1, 0, 1, 3, 4, 2, 0, "Cota");
        enemy8.SetPlayer(1, 0, 4, 0, 1, 3, 5, "Bogotá");
        enemyBoss1.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Don Chucho", true);

        enemy9.SetPlayer(1, 3, 0, 2, 4, 4, 2, "Granada");
        enemy10.SetPlayer(0, 3, 5, 4, 0, 4, 6, "Saravena");
        enemy11.SetPlayer(0, 3, 2, 7, 4, 6, 2, "Puerto Carreño");
        enemy12.SetPlayer(1, 1, 2, 0, 0, 1, 3, "Acacías");
        enemy13.SetPlayer(1, 1, 5, 1, 3, 3, 5, "Arauca");
        enemy14.SetPlayer(0, 4, 3, 2, 6, 6, 2, "Yopal");
        enemy15.SetPlayer(1, 1, 3, 3, 1, 7, 2, "Aguazul");
        enemy16.SetPlayer(0, 3, 0, 0, 0, 4, 6, "Villavicencio");
        enemyBoss2.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Don Arnulfo", true);

        enemy17.SetPlayer(1, 3, 5, 7, 5, 6, 3, "Tarapacá");
        enemy18.SetPlayer(1, 1, 6, 6, 2, 4, 1, "La Pedrera");
        enemy19.SetPlayer(0, 4, 5, 1, 3, 1, 3, "Puerto Nariño");
        enemy20.SetPlayer(0, 2, 7, 3, 5, 4, 1, "El Encanto");
        enemy21.SetPlayer(0, 0, 0, 6, 2, 4, 2, "Puerto Santander");
        enemy22.SetPlayer(1, 1, 4, 5, 4, 3, 5, "La Victoria");
        enemy23.SetPlayer(1, 2, 2, 4, 1, 4, 6, "La Chorrera");
        enemy24.SetPlayer(1, 4, 3, 5, 4, 1, 2, "Leticia");
        enemyBoss3.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Doña Tungurahua", true);

        enemy25.SetPlayer(1, 7, 2, 5, 1, 4, 5, "Juradó");
        enemy26.SetPlayer(1, 6, 7, 3, 1, 6, 3, "Timbiquí");
        enemy27.SetPlayer(0, 7, 2, 3, 4, 4, 1, "Tumaco");
        enemy28.SetPlayer(1, 7, 4, 5, 0, 3, 7, "Bahía Solano");
        enemy29.SetPlayer(0, 1, 7, 6, 1, 1, 4, "Popayán");
        enemy30.SetPlayer(0, 2, 0, 4, 2, 5, 5, "Pasto");
        enemy31.SetPlayer(0, 7, 1, 0, 2, 3, 3, "Buenaventura");
        enemy32.SetPlayer(0, 6, 3, 1, 0, 4, 1, "Cali");
        enemyBoss4.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Don Cársito", true);

        enemy33.SetPlayer(0, 2, 3, 4, 2, 1, 0, "Riosucio");
        enemy34.SetPlayer(0, 1, 2, 3, 5, 2, 2, "Chinchiná");
        enemy35.SetPlayer(1, 1, 6, 7, 0, 3, 3, "Dosquebradas");
        enemy36.SetPlayer(1, 0, 7, 0, 5, 1, 5, "Salento");
        enemy37.SetPlayer(1, 2, 6, 3, 5, 2, 5, "Circasia");
        enemy38.SetPlayer(0, 0, 6, 5, 0, 2, 1, "Manizales");
        enemy39.SetPlayer(1, 3, 5, 0, 1, 6, 3, "Pereira");
        enemy40.SetPlayer(0, 1, 4, 1, 2, 2, 2, "Armenia");
        enemyBoss5.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Don Cosiaca", true);

        enemy41.SetPlayer(1, 1, 0, 7, 1, 4, 7, "La Estrella");
        enemy42.SetPlayer(0, 1, 7, 6, 5, 2, 2, "Copacabana");
        enemy43.SetPlayer(1, 3, 5, 4, 4, 4, 5, "Sabaneta");
        enemy44.SetPlayer(0, 0, 2, 1, 4, 2, 1, "Bello");
        enemy45.SetPlayer(1, 4, 2, 6, 1, 3, 2, "Barbosa");
        enemy46.SetPlayer(1, 2, 4, 3, 4, 1, 3, "Itagüí");
        enemy47.SetPlayer(0, 0, 0, 5, 3, 1, 1, "Envigado");
        enemy48.SetPlayer(1, 0, 5, 6, 7, 6, 3, "Medellín");
        enemyBoss6.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Don Cosiánfilo", true);

        enemy49.SetPlayer(0, 5, 7, 7, 4, 3, 3, "San Pelayo");
        enemy50.SetPlayer(1, 6, 1, 5, 2, 6, 7, "Montería");
        enemy51.SetPlayer(0, 6, 6, 2, 5, 3, 1, "Plato");
        enemy52.SetPlayer(0, 3, 5, 1, 4, 4, 1, "Valledupar");
        enemy53.SetPlayer(0, 6, 0, 0, 4, 3, 2, "Riohacha");
        enemy54.SetPlayer(1, 7, 5, 5, 0, 3, 5, "Cartagena");
        enemy55.SetPlayer(1, 5, 7, 3, 6, 3, 3, "Santa Marta");
        enemy56.SetPlayer(0, 5, 1, 4, 1, 7, 7, "Barranquilla");
        enemyBoss7.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Doña Olinda", true);

        enemy57.SetPlayer(0, 1, 0, 1, 2, 1, 2, "San Gil");
        enemy58.SetPlayer(1, 0, 6, 1, 2, 4, 0, "Floridablanca");
        enemy59.SetPlayer(0, 6, 2, 2, 6, 4, 6, "Barrancabermeja");
        enemy60.SetPlayer(0, 4, 3, 0, 4, 1, 0, "Chinácota");
        enemy61.SetPlayer(0, 0, 6, 4, 5, 4, 1, "Bochalema");
        enemy62.SetPlayer(1, 4, 3, 4, 5, 3, 2, "Barichara");
        enemy63.SetPlayer(0, 3, 2, 5, 1, 4, 3, "Cúcuta");
        enemy64.SetPlayer(1, 2, 5, 7, 6, 1, 1, "Bucaramanga");
        enemyBoss8.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Doña Diosa", true);

        enemy65.SetPlayer(1, 6, 2, 5, 7, 5, 5, "Berbeo");
        enemy66.SetPlayer(0, 1, 4, 5, 0, 0, 1, "Somondoco");
        enemy67.SetPlayer(0, 2, 0, 6, 1, 5, 5, "Sogamoso");
        enemy68.SetPlayer(1, 0, 4, 4, 5, 2, 4, "Chiquinquirá");
        enemy69.SetPlayer(1, 2, 0, 0, 1, 0, 0, "Duitama");
        enemy70.SetPlayer(1, 0, 7, 1, 0, 5, 4, "Samacá");
        enemy71.SetPlayer(0, 0, 2, 4, 2, 5, 1, "Turmequé");
        enemy72.SetPlayer(0, 2, 1, 1, 0, 5, 0, "Tunja");
        enemyBoss9.SetPlayer(0, 0, 0, 0, 0, 0, 0, "Doña Bere", true);

        nivel1.Add(enemy1);
        nivel1.Add(enemy2);
        nivel1.Add(enemy3);
        nivel1.Add(enemy4);
        nivel1.Add(enemy5);
        nivel1.Add(enemy6);
        nivel1.Add(enemy7);
        nivel1.Add(enemy8);
        nivel1.Add(enemyBoss1);

        nivel1.Add(enemy9);
        nivel1.Add(enemy10);
        nivel1.Add(enemy11);
        nivel1.Add(enemy12);
        nivel1.Add(enemy13);
        nivel1.Add(enemy14);
        nivel1.Add(enemy15);
        nivel1.Add(enemy16);
        nivel1.Add(enemyBoss2);

        nivel1.Add(enemy17);
        nivel1.Add(enemy18);
        nivel1.Add(enemy19);
        nivel1.Add(enemy20);
        nivel1.Add(enemy21);
        nivel1.Add(enemy22);
        nivel1.Add(enemy23);
        nivel1.Add(enemy24);
        nivel1.Add(enemyBoss3);

        nivel1.Add(enemy25);
        nivel1.Add(enemy26);
        nivel1.Add(enemy27);
        nivel1.Add(enemy28);
        nivel1.Add(enemy29);
        nivel1.Add(enemy30);
        nivel1.Add(enemy31);
        nivel1.Add(enemy32);
        nivel1.Add(enemyBoss4);

        nivel1.Add(enemy33);
        nivel1.Add(enemy34);
        nivel1.Add(enemy35);
        nivel1.Add(enemy36);
        nivel1.Add(enemy37);
        nivel1.Add(enemy38);
        nivel1.Add(enemy39);
        nivel1.Add(enemy40);
        nivel1.Add(enemyBoss5);

        nivel1.Add(enemy41);
        nivel1.Add(enemy42);
        nivel1.Add(enemy43);
        nivel1.Add(enemy44);
        nivel1.Add(enemy45);
        nivel1.Add(enemy46);
        nivel1.Add(enemy47);
        nivel1.Add(enemy48);
        nivel1.Add(enemyBoss6);

        nivel1.Add(enemy49);
        nivel1.Add(enemy50);
        nivel1.Add(enemy51);
        nivel1.Add(enemy52);
        nivel1.Add(enemy53);
        nivel1.Add(enemy54);
        nivel1.Add(enemy55);
        nivel1.Add(enemy56);
        nivel1.Add(enemyBoss7);

        nivel1.Add(enemy57);
        nivel1.Add(enemy58);
        nivel1.Add(enemy59);
        nivel1.Add(enemy60);
        nivel1.Add(enemy61);
        nivel1.Add(enemy62);
        nivel1.Add(enemy63);
        nivel1.Add(enemy64);
        nivel1.Add(enemyBoss8);

        nivel1.Add(enemy65);
        nivel1.Add(enemy66);
        nivel1.Add(enemy67);
        nivel1.Add(enemy68);
        nivel1.Add(enemy69);
        nivel1.Add(enemy70);
        nivel1.Add(enemy71);
        nivel1.Add(enemy72);
        nivel1.Add(enemyBoss9);
    }

    public void SoundEffectsToggle()
    {
        if (soundEffectsON==1) { soundEffectsON = 0; }
        else { soundEffectsON = 1; }
        SetCache();
    }

    public void VibracionToggle()
    {
        if (vibracionON == 1) { vibracionON = 0;
        } else { vibracionON = 1; }
        SetCache();
    }

    public void SetTransparent(GameObject objeto, bool _transparent)
    {
        if (_transparent)
        {
            var tempColor = objeto.GetComponent<Image>().color;
            tempColor.a = 0.2f;
            objeto.GetComponent<Image>().color = tempColor;
        }
        else
        {
            var tempColor = objeto.GetComponent<Image>().color;
            tempColor.a = 1f;
            objeto.GetComponent<Image>().color = tempColor;
        }
    }

    public void SetTransparentText(GameObject objeto, bool _transparent)
    {
        if (_transparent)
        {
            var tempColor = objeto.GetComponent<Text>().color;
            tempColor.a = 0.2f;
            objeto.GetComponent<Text>().color = tempColor;
        }
        else
        {
            var tempColor = objeto.GetComponent<Text>().color;
            tempColor.a = 1f;
            objeto.GetComponent<Text>().color = tempColor;
        }
    }

    public void SetBlack(GameObject objeto, float _val)
    {
        var tempColor = objeto.GetComponent<Image>().color;
        tempColor.r = _val;
        tempColor.g = _val;
        tempColor.b = _val;
        objeto.GetComponent<Image>().color = tempColor;
    }

    public void SetBackgroundMusic(bool _opc)
    {
        backgroundMusic = this.gameObject.GetComponent<AudioSource>();
        if (_opc)
        {
            if ((backgroundMusicON == 1) && (!backgroundMusic.isPlaying)) backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Stop();
        }
        SetCache();
    }
}
