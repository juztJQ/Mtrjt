using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public Game_UIManager uiManager;
    public GameObject chepe;
    public GameObject milton;
    public Animator animator;
    public bool isAnimating = false;
    public int newCanchaTraining = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnEntrada()
    {
        int isMilton = Random.Range(0,2);
        int isChepe = Random.Range(0, 2);
        
        if (isMilton == 1)  milton.SetActive(true);
        if (isChepe == 1)   chepe.SetActive(true);
        
        isAnimating = false;
        spawnManager.StartGame();
    }

    public void PauseAnim(bool _pause)
    {
        if (_pause)
        {
            animator.speed = 0;
        }
        else
        {
            animator.speed = 1;
        }
        
    }

    public void ZoomCancha1()
    {
        if (!isAnimating)
        {
            animator.SetInteger("GoAnim", 1);
            isAnimating = true;
        }
    }

    public void ZoomCancha2()
    {
        if (!isAnimating)
        {
            animator.SetInteger("GoAnim", 3);
            isAnimating = true;
        }
    }

    public void GoCancha1()
    {
        //Debug.Log("ADMob :: GoCancha1() - isAnimating:"+ isAnimating);
        if (GlobalVars.Instance.gameType == "Training")
        {
            newCanchaTraining = 1;
            animator.SetInteger("GoAnim", 4);
            isAnimating = true;
        }
        else
        {
            if (!isAnimating)
            {
                animator.SetInteger("GoAnim", 4);
                isAnimating = true;
                spawnManager.currentCancha = 1;
            }
        }
        
    }

    public void GoCancha2()
    {
        if (GlobalVars.Instance.gameType == "Training")
        {
            newCanchaTraining = 2;
            animator.SetInteger("GoAnim", 2);
            isAnimating = true;
        }
        else
        {
            if (!isAnimating)
            {
                animator.SetInteger("GoAnim", 2);
                spawnManager.currentCancha = 2;
                isAnimating = true;
            }
        }
            
    }

    public void ShowResultado()
    {
        Debug.Log("ShowResultado: isAnimating:"+ isAnimating);
        
        if (!isAnimating)
        {
            animator.SetBool("Resultado", true);
            isAnimating = true;
        }
        
    }


    public void DrawLine()
    {
        spawnManager.DrawLine();
    }

    public void NuevoTurno()
    {
        spawnManager.NuevoTurno();
    }

    public void goCancha()
    {

    }

    public void FinishAnimation()
    {
        if (GlobalVars.Instance.gameType == "Training")
        {
            Debug.Log("Camera :: FinishAnimation");
            isAnimating = false;
        }
        else
        {
            isAnimating = false;
            if (spawnManager.HasWinner())
            {
                spawnManager.gameOver = true;
                ShowResultado();
            }
        }
    }

    public void NuevaRonda()
    {
        if (GlobalVars.Instance.gameType == "Training")
        {
            spawnManager.CleanCanchaTraining();
        }
        else
        {
            uiManager.SetMessage(0, "", "Nueva ronda", 3f, false);
        }
    }

    public void FinishAnimationResultado()
    {
        isAnimating = false;
        uiManager.ShowResultado();
    }

}
