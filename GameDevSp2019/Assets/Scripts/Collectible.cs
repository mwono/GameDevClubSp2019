using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public abstract void Collect();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name.Equals("Player"))
        {
            Collect();
            this.gameObject.SetActive(false);
        }
    }
}
