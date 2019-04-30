using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : Collectible
{
    public Invincibility pc;
    
    public override void Collect()
    {
        pc.setInvincible();
    }
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<Invincibility>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
