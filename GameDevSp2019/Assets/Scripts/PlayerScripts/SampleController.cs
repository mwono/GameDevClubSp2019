using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public class SampleController : Controller
{
    protected override void MoveScheme()
    {
        Move(GetDistance(Direction.up));
    }

    // Update is called once per frame
    void Update()
    {
        MoveScheme();
    }
}
