using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollectible : MonoBehaviour
{
    public ScoreManager sc;
    public int val;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sc.getScore());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            sc.setScore(val);
            Debug.Log(sc.getScore());
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
