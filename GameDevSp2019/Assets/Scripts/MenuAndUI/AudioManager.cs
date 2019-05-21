using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Options op;
    public AudioSource m;

    private void Awake()
    {
        op = GameObject.Find("OptionsManager").GetComponent<Options>();
        m.volume = op.vol;
    }

    private void Update()
    {
        m.volume = op.vol;
    }
}
