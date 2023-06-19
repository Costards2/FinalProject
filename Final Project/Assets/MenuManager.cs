using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void Sair()
    {
        Debug.Log("Sair");
        Application.Quit();
    }

}
