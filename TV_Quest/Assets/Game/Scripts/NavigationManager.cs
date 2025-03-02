using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public GameObject loading;
    public Header header;
    public AudioManager audioManager;

    private void Start()
    {
        GlobalVars.Instance.isBack = true;
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                switch (SceneManager.GetActiveScene().name)
                {
                    case "01_MainMenu"      : goSalirJuego();       break;
                    case "04_Game"          : header = GameObject.Find("Header").GetComponent<Header>(); header.SalirJuego();     break;
                    case "10_GamePuntos"    : header = GameObject.Find("Header").GetComponent<Header>(); header.SalirJuego(); break;
                    case "11_Retos"         : goEntrada();         break;
                    case "12_GameReto"      : header = GameObject.Find("Header").GetComponent<Header>(); header.SalirJuego(); break;
                }               
            }
        }
    }
    public void goSplash()
    {
        audioManager.SetClick();
        //GlobalVars.Instance.PauseAudio();
        if (GlobalVars.Instance.isBack) audioManager.SetClick();
        StartCoroutine(LoadScene("00_SplashScreen"));
    }

    public void goEntrada()
    {
        audioManager.SetClick();
        Debug.Log("aqui");
        if (GlobalVars.Instance.isBack) audioManager.SetClick();
        StartCoroutine(LoadScene("01_Entrada"));
    }

    public void goFinJuego()
    {
        //deeplink to fin juego pending
        goEntrada();
    }

    public void goTrofeos()
    {
        //deeplink to trofeos pending
        goEntrada();
    }

    public void goGame()
    {   audioManager.SetClick();
        loading.SetActive(true);
        StartCoroutine(LoadScene("04_Game"));
    }

    public void goGamePuntos()
    {
        audioManager.SetClick();
        loading.SetActive(true);
        StartCoroutine(LoadScene("10_GamePuntos"));
    }

    public void goGameReto()
    {
        Debug.Log("goGameReto");
        audioManager.SetClick();
        loading.SetActive(true);
        StartCoroutine(LoadScene("12_GameReto"));
    }

    public void goSalirJuego()
    {
        audioManager.SetClick();
        Application.Quit();
    }

    public void goTerminosCondiciones()
    {
        Application.OpenURL("https://www.virtualtejo.com/terminos-condiciones.php");
    }

    IEnumerator LoadScene(string _sceneName)
    {
        AsyncOperation operation =  SceneManager.LoadSceneAsync(_sceneName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            yield return null;
        }
        if (operation.isDone)
        {
            loading.SetActive(false);
        }
    }

}
