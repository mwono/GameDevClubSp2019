using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public class SampleController : Controller
{
    public override void MoveScheme()
    {
        Move(GetDistance(Direction.up));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveScheme();
    }
}
