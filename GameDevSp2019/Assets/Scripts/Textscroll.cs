using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Textscroll : MonoBehaviour
{
    float speed = .05f;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(new Vector3(0, 10, 5) * Time.deltaTime * speed);
        if (transform.position.y >= 70f)
        {
            SceneManager.LoadScene("Level");
        }
        if (Input.GetAxis("Jump") > 0)
        {
            speed = 1f;
        } else
        {
            speed = .05f;
        }
    }
}
