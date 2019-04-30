using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int s;
    public Text sc;

    public void updateScore(int score)
    {
        s += score;
    }

    // Update is called once per frame
    void Update()
    {
        sc.text = s.ToString();
        if (s == 75)
        {
            Application.Quit();
        }
    }
}
