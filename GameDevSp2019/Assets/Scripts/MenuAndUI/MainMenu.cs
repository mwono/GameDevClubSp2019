using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject options, credits;

    public void Play() 
    {
        SceneManager.LoadScene("Opening");
    }

    public void Options()
    {
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
    }

    public void Credits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
