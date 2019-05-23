using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public class PlayerController : Controller
{
    Direction d, prevd;
    private Vector2 dist;

    protected override void MoveScheme()
    {
        if (Input.GetAxis("Vertical") > 0 && CanMove && GetCurrentNode().Up)
        {
            d = Direction.up;
            sprite.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        } else if (Input.GetAxis("Vertical") < 0 && CanMove && GetCurrentNode().Down)
        {
            d = Direction.down;
            sprite.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        } else if (Input.GetAxis("Horizontal") > 0 && CanMove && GetCurrentNode().Right)
        {
            d = Direction.right;
            sprite.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        } else if (Input.GetAxis("Horizontal") < 0 && CanMove && GetCurrentNode().Left)
        {
            d = Direction.left;
            sprite.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
        else if (Input.GetAxis("Vertical") > 0 && !CanMove && d == Direction.down && GetCurrentNode().Up)
        {
            d = Direction.up;
            sprite.rotation = Quaternion.AngleAxis(90, Vector3.forward);
        }
        else if (Input.GetAxis("Vertical") < 0 && !CanMove && d == Direction.up && GetCurrentNode().Down)
        {
            d = Direction.down;
            sprite.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
        }
        else if (Input.GetAxis("Horizontal") > 0 && !CanMove && d == Direction.left && GetCurrentNode().Right)
        {
            d = Direction.right;
            sprite.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
        else if (Input.GetAxis("Horizontal") < 0 && !CanMove && d == Direction.right && GetCurrentNode().Left)
        {
            d = Direction.left;
            sprite.rotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
        dist = GetDistance(d);
        if (dist.magnitude == 0 && !CanMove) {
            dist = GetCurrentNode().transform.position - this.transform.position;
        } else if ((dist.magnitude == 0 && CanMove) || dist.magnitude == Mathf.Infinity)
        {
            dist = new Vector2(0, 0);
        }
        Move(dist);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveScheme();
    }
}