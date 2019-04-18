using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public abstract void Collect();

    public void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("player"))
        {
            updateScore();
        }
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
