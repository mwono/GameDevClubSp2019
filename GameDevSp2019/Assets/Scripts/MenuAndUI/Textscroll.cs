using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Textscroll : MonoBehaviour
{
    float speed = .05f;
    public AudioSource starwars;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(new Vector3(0, 10, 5.5f) * Time.deltaTime * speed);
        if (transform.position.y >= 75f)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Level");
        }
        if (Input.GetAxis("Jump") > 0)
        {
            Time.timeScale = 10f;
        } else
        {
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Level");
        }
    }
}
