﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invincibility : MonoBehaviour
{
    public float invincibleTime = 3.0f;
    bool isInvincible;
    bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void setInvincible()
    {
        isInvincible = true;
        Invoke("resetInvincible", invincibleTime);
    }
    public bool getInvincible()
    {
        return isInvincible;
    }
    public void resetInvulnerability()
    {
        isInvincible = false;
    }
    public void damaged()
    {
        if (!isInvincible)
        {
            Scene x = SceneManager.GetActiveScene();
            SceneManager.LoadScene(x.name);
        }
    }
}
