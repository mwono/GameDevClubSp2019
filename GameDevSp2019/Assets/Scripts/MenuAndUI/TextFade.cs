using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public Text txt;

    // Update is called once per frame
    void Update()
    {
        txt.CrossFadeAlpha(0f, 3f, false);
    }
}
