using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invincibility : MonoBehaviour
{
    public float invincibleTime = 3.0f;
    bool isInvincible;
    bool alive = true, flashing;
    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible && !flashing)
        {
            StartCoroutine("Flash");
        }
    }
    public void setInvincible()
    {
        isInvincible = true;
        Invoke("resetInvulnerability", invincibleTime);
    }
    public bool getInvincible()
    {
        return isInvincible;
    }
    public void resetInvulnerability()
    {
        isInvincible = false;
    }

    IEnumerator Flash()
    {
        flashing = true;
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.05f);
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
        flashing = false;
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
