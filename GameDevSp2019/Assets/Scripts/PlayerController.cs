using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public class PlayerController : Controller
{
    Direction d;
    // CanMove = true;
    public override void MoveScheme()
    {
        if (Input.GetAxis("Vertical") > 0 && CanMove)
        {
            d = Direction.up;
        } else if (Input.GetAxis("Vertical") < 0 && CanMove)
        {
            d = Direction.down;
        } else if (Input.GetAxis("Horizontal") > 0 && CanMove)
        {
            d = Direction.right;
        } else if (Input.GetAxis("Horizontal") < 0 && CanMove)
        {
            d = Direction.left;
        }
        else if (Input.GetAxis("Vertical") > 0 && !CanMove && d == Direction.down)
        {
            d = Direction.up;
        }
        else if (Input.GetAxis("Vertical") < 0 && !CanMove && d == Direction.up)
        {
            d = Direction.down;
        }
        else if (Input.GetAxis("Horizontal") > 0 && !CanMove && d == Direction.left)
        {
            d = Direction.right;
        }
        else if (Input.GetAxis("Horizontal") < 0 && !CanMove && d == Direction.right)
        {
            d = Direction.left;
        }
        Vector2 dist = GetDistance(d);
        if (dist.magnitude == 0 && !CanMove) {
            dist = GetCurrentNode().transform.position - this.transform.position;
        } else if ((dist.magnitude == 0 && CanMove) || dist.magnitude == Mathf.Infinity)
        {
            dist = new Vector2(0, 0);
        }
        Move(dist);
    }

    // Update is called once per frame
    void Update()
    {
        MoveScheme();
    }
}