using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public GameObject c;
    public int s;
    int cornCollected, totalCorn;
    static float timescaler = 1f;
    public Text sc;
    public GameObject menu;
    public Options op;

    private static ScoreManager scoreManager;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Time.timeScale = timescaler;
        if (scoreManager == null)
        {
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
    }

    public void updateScore(int score)
    {
        s += score;
        if (score == 1)
        {
            cornCollected++;
        }
    }

    public float GetTimeScale()
    {
        return timescaler;
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
            timescaler += .5f;
        }
        SceneManager.LoadScene("Level");
    }
}
