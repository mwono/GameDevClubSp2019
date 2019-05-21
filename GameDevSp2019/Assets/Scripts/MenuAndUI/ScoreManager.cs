using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int s;
    int cornCollected;
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
    }

    // Update is called once per frame
    void Update()
    {
        sc.text = s.ToString();
        if (cornCollected == 74)
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
