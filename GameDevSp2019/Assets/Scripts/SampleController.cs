using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public class SampleController : Controller
{
    public override void Move(Vector2 Dist)
    {
        if (!isMoving)
        {
            isMoving = true;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Dist);
            if (hit.collider != null)
            {
                SetNextNode(hit.collider.GetComponent<Nodes>());
            }
            transform.Translate(Dist * Time.deltaTime);
            isMoving = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(GetDistance(Direction.up));
    }
}
