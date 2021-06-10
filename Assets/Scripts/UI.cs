using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    GameObject pnlTB, pnlGameOver;
    

    public void pnlTB_Goster()
    {
        pnlTB.SetActive(true);
    }
    public void pnlGameOver_Goster()
    {
        pnlGameOver.SetActive(true);
    }

    public void devamEt()
    {
        int simdikilvl = PlayerPrefs.GetInt("level");

        simdikilvl++;
        PlayerPrefs.SetInt("level", simdikilvl);

        SceneManager.LoadScene(0);
    }
    public void TekrarOyna()
    {
        
        SceneManager.LoadScene(0);
    }
}
