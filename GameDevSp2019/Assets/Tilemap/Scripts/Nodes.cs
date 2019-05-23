using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

namespace WASD
{
    public enum Direction { up,down, left,right };
}

public class Nodes : MonoBehaviour
{
    public bool Up, Down, Left, Right;
    private Vector2[] directions;
    
    private RaycastHit2D raycastHit;

    private void Start()
    {
        directions = new Vector2[] { new Vector2(), new Vector2(), new Vector2(), new Vector2() };
        LayerMask layerMask = LayerMask.GetMask("Node", "Wall");
        float castDist = Mathf.Infinity;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, 1), castDist, layerMask);
        if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
        {
            Up = true;
            directions[0] = hit.transform.position - transform.position;
        }
        hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), castDist, layerMask);
        if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
        {
            Down = true;
            directions[2] = hit.transform.position - transform.position;
        }
        hit = Physics2D.Raycast(transform.position, new Vector2(1, 0), castDist, layerMask);
        if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
        {
            Right = true;
            directions[3] = hit.transform.position - transform.position;
        }
        hit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), castDist, layerMask);
        if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
        {
            Left = true;
            directions[1] = hit.transform.position - transform.position;
        }
    }

    public Vector2 Director(Direction v, Direction defaultv)
    {
        LayerMask layerMask = LayerMask.GetMask("Node");
        Vector2 returnVector = new Vector2(0, 0);

        if (v == Direction.up && Up)
        {
            returnVector = directions[0];
        }
        else if (v == Direction.down && Down)
        {
            returnVector = directions[2];
        }
        else if (v == Direction.right && Right)
        {
            returnVector = directions[3];
        }
        else if (v == Direction.left && Left)
        {
            returnVector = directions[1];
        }
        else if (defaultv == Direction.up && Up)
        {
            returnVector = directions[0];
        }
        else if (defaultv == Direction.down && Down)
        {
            returnVector = directions[2];
        }
        else if (defaultv == Direction.right && Right)
        {
            returnVector = directions[3];
        }
        else if (defaultv == Direction.left && Left)
        {
            returnVector = directions[1];
        }
        return returnVector;
    }
}
