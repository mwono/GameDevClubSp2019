using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenMelon : Collectible
{
    public ScoreManager manager;

    public override void Collect()
    {
        manager.updateScore(-10);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
