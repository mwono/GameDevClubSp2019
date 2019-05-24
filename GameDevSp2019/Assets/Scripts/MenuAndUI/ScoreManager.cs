using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject c;
    int s;
    int cornCollected, totalCorn;
    static float FarmerSpeedMod = 1f;
    public Text sc;
    public GameObject menu;
    public Options op;

    private static ScoreManager scoreManager;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Time.timeScale = 1;
        op = GameObject.Find("OptionsManager").GetComponent<Options>();
        if (scoreManager == null)
        {
            GameObject.Find("UI").GetComponent<ScoreManager>().updateScore(-100);
            scoreManager = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
        totalCorn = c.GetComponentsInChildren<Corn>().Length;
    }

    // Update is called once per frame
    void Update()
    {
        sc.text = s.ToString();
        if (cornCollected == totalCorn)
        {
            menu.SetActive(true);
        }
        if (Input.GetAxis("Pause") > 0 && !menu.activeInHierarchy)
        {
            menu.SetActive(true);
        } else if (Input.GetAxis("Pause") > 0 && menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
    }

    public void updateScore(int score)
    {
        s += score;
        if (score == 1)
        {
            cornCollected++;
        }
    }

    public float GetSpeedMod()
    {
        return FarmerSpeedMod;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        menu.SetActive(false);
        cornCollected = 0;
        if (op.willSpeedUp) {
            FarmerSpeedMod += .05f;
        }
        SceneManager.LoadScene("Level");
    }

    public void QuitToMenu()
    {
        s = 0;
        menu.SetActive(false);
        SceneManager.LoadScene("Title");
    }
}
