using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : Collectible
{
    public ScoreManager manager;

    public override void Collect()
    {
        manager.updateScore(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("UI").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
