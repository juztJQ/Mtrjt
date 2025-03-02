using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Header : MonoBehaviour
{
    public Entrada_UIManager entrada_UIManager;
    public PopupFinJuego popupFinJuego;
    public GameObject CoinJumpPrefab;
    public GameObject XPJumpPrefab;
    public GameObject Coin;
    public GameObject xp;
    public Text coins_txt;
    public Nivel nivel;
    public Text userName_txt;
    
    public AudioManager audioManager;
    public GameObject popupPausa;
    public AvatarWeb avatar;
    public Game_UIManager uiManager;
    public Communicator communicator;
    public GameObject loading;
    public ErrorMessage errorMessage;
    public NavigationManager navigationManager;

    public bool isTiming = false;
    public bool isTimingXP = false;
    public bool counting = false;
    public bool countingCoin = false;
    public bool countingXP = false;
    public int count = 0;
    public int countXP = 0;
    public int max = 0;
    public int maxXP = 0;

    public int currentNivel;

    private string returnWindow;


    public void Start()
    {
        currentNivel = GlobalVars.Instance.progress;
    }

    private void Update()
    {
        if (!isTiming && countingCoin)
        {
            UpdateNum();
            isTiming = true;
        }

        if (!isTimingXP && countingXP)
        {
            UpdateNumXP();
            isTimingXP = true;
        }
    }

    public void SetHeader()
    {
        count = GlobalVars.Instance.coins;
        countXP = GlobalVars.Instance.points;
        coins_txt.text = count.ToString();

        coins_txt.text = GlobalVars.Instance.coins.ToString();
        SetAvatar();
    }

    public void SetHeaderLite()
    {
        count = GlobalVars.Instance.coins;
        countXP = GlobalVars.Instance.points;
        coins_txt.text = count.ToString();

        coins_txt.text = GlobalVars.Instance.coins.ToString();
    }

    public void updateUserAll()
    {
        communicator.getUserHeader(GlobalVars.Instance.player1.idUser);
    }

    public void SetDefaultData()
    {
        coins_txt.text  = GlobalVars.Instance.coins.ToString();
        SetAvatar();
    }

    // -------------------------------- COINS --------------------------------- //

    public void SetCoins(int _coins)
    {
        //Debug.Log("header :: SetCoins: " + _coins);
        returnWindow = "";
        count = GlobalVars.Instance.coins;
        max = _coins + GlobalVars.Instance.coins;
        countingCoin = true;
    }

    public void UpdateNum()
    {
        //Debug.Log("header :: UpdateNum: count:" + count + " - max: " + max);
        if (count < max)
        {
            //Debug.Log("count: "+ count);
            count += 5;
            StartCoroutine(SetPulse());
        }
        else
        {
            counting = false;
            GlobalVars.Instance.coins = max;
            communicator.updateUserCoins();
        }
    }

    IEnumerator SetPulse()
    {
        GameObject CoinAnim = Instantiate(CoinJumpPrefab, transform.position, Quaternion.identity);
        CoinAnim.transform.SetParent(Coin.transform);
        coins_txt.text = count.ToString();
        yield return new WaitForSeconds(0.1f);
        isTiming = false;
    }

    public void Debitar(int _num, string _returnWindow)
    {
        if(GlobalVars.Instance.coins >= _num)
        {
            GlobalVars.Instance.coins = GlobalVars.Instance.coins - _num;
            returnWindow = _returnWindow;
            communicator.updateUserCoins();
        }
    }

    // -------------------------------- POINTS --------------------------------- //

    public void SetXP(int _xp)
    {
        Debug.Log("SetXP: " + _xp);
        countXP = GlobalVars.Instance.points;
        maxXP = _xp + GlobalVars.Instance.points;
        isTimingXP = false;
        countingXP = true;
    }

    public void UpdateNumXP()
    {
        Debug.Log("UpdateNumXP : countXP:" + countXP+ " - maxXP:"+ maxXP);
        if (countXP < maxXP)
        {
            countXP += 5;
            StartCoroutine(SetPulseXP());
        }
        else
        {
            counting = false;
            GlobalVars.Instance.points = maxXP;
            communicator.updateUserPoints();
        }
        nivel.Blink182();
    }

    IEnumerator SetPulseXP()
    {
        if (countXP <= maxXP)
        {
            nivel.Blink182();
            //GameObject XPAnim = Instantiate(XPJumpPrefab, transform.position, Quaternion.identity);
            //XPAnim.transform.parent = xp.transform;
        }
        yield return new WaitForSeconds(0.02f);
        isTimingXP = false;
    }

    // -------------------------------- AVATAR --------------------------------- //

    public void SetAvatar()
    {
        if (GlobalVars.Instance.player1.nombre == "")
        {
            int genero = Random.Range(0, 1);
            int cuerpo = Random.Range(0, 8);
            int cara = Random.Range(0, 8);
            int cabello = Random.Range(0, 8);
            int pantalon = Random.Range(0, 2);
            int ropa = Random.Range(0, 2);
            int sombrero = Random.Range(0, 2);

            GlobalVars.Instance.player1.genero = genero;
            GlobalVars.Instance.player1.cuerpo = cuerpo;
            GlobalVars.Instance.player1.cara = cara;
            GlobalVars.Instance.player1.cabello = cabello;
            GlobalVars.Instance.player1.pantalon = pantalon;
            GlobalVars.Instance.player1.ropa = ropa;
            GlobalVars.Instance.player1.sombrero = sombrero;
            GlobalVars.Instance.player1.nombre = "Jugador 1";

            avatar.setAvatar(genero, cuerpo, cara, cabello, pantalon, ropa, sombrero);
            entrada_UIManager.setUserAvatar();
            userName_txt.text = "Jugador 1";
            GlobalVars.Instance.player1.SetPlayer(genero, cuerpo, cara, cabello, pantalon, ropa, sombrero, "Jugador 1");
        }
        else
        {
            userName_txt.text = GlobalVars.Instance.player1.nombre;
            avatar.setAvatar(GlobalVars.Instance.player1.genero, GlobalVars.Instance.player1.cuerpo, GlobalVars.Instance.player1.cara, GlobalVars.Instance.player1.cabello, GlobalVars.Instance.player1.pantalon, GlobalVars.Instance.player1.ropa, GlobalVars.Instance.player1.sombrero);
        }
    }

    public void UpdateAvatar()
    {
        loading.SetActive(true);
        communicator.setUserAvatar();
    }

    // -------------------------------- POPUPS --------------------------------- //

    public void SetMenuPausa()
    {
        audioManager.SetClick();
        popupPausa.SetActive(true);
        Time.timeScale = 0;
    }

    public void SalirJuego()
    {
        audioManager.SetClick();
        popupPausa.SetActive(false);
    }

    public void exitScene()
    {
        audioManager.SetClick();
        Time.timeScale = 1;
    }

    public void ContinuarJuego()
    {
        audioManager.SetClick();
        Time.timeScale = 1;
        popupPausa.SetActive(false);
    }

    // -------------------------------- COMUNICATION --------------------------------- //

    public void onCoinsResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        Debug.Log("result Header:" + result);
        GlobalVars.Instance.SaveGlobalUserVars(result);
        if(returnWindow == "Training")
        {
            GlobalVars.Instance.gameType = "Training";
            returnWindow = "";
            navigationManager.goGame();
        }
        else
        {
            popupFinJuego.SetPopupNext();
        }
    }

    public void onPointsResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        Debug.Log("result Header:" + result);
        GlobalVars.Instance.SaveGlobalUserVars(result);
        Debug.Log("GlobalVars.Instance.points: " + GlobalVars.Instance.points);
        Debug.Log("actual nivel: " + currentNivel);
        Debug.Log("nuevo nivel: " + GlobalVars.Instance.progress);
        Debug.Log("waitAsset");
        if(GlobalVars.Instance.progress > currentNivel)
        {
            popupFinJuego.SetNuevoNivel();
        }
        else
        {
            popupFinJuego.SetPopupAsset();
        }
    }

    public void onSetUserResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.SaveGlobalUserVars(result);
            this.SetDefaultData();
            loading.SetActive(false);
            entrada_UIManager.CloseAvatar();
        }
    }

    public void onGetUserResult(JSONObject dataJSON)
    {
        JSONObject result = dataJSON[0];
        if (result.GetField("status").str == "existe")
        {
            GlobalVars.Instance.SaveGlobalUserVars(result);
            this.SetDefaultData();
        }
    }
}
