using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public bool willSpeedUp = true;
    public float vol = .5f;
    public Slider vl;

    private static Options options;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (options == null)
        {
            options = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void Speed()
    {
        willSpeedUp = !willSpeedUp;
    }

    public void SetVol()
    {
        vol = vl.value;
    }
}
