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
    
    private RaycastHit2D raycastHit;

    private void Start()
    {
        LayerMask layerMask = LayerMask.GetMask("Node", "Wall");
        float castDist = Mathf.Infinity;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, 1), castDist, layerMask);
        if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
        {
            Up = true;
        }
        hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), castDist, layerMask);
        if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
        {
            Down = true;
        }
        hit = Physics2D.Raycast(transform.position, new Vector2(1, 0), castDist, layerMask);
        if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
        {
            Right = true;
        }
        hit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), castDist, layerMask);
        if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
        {
            Left = true;
        }
    }

    public Vector2 Director(Direction v, Direction defaultv)
    {
        LayerMask layerMask = LayerMask.GetMask("Node");
        Vector2 returnVector = new Vector2(0, 0);

        if (v == Direction.up && Up)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(0,1), Mathf.Infinity, layerMask);
            returnVector = raycastHit.transform.position - transform.position;
        }
        else if (v == Direction.down && Down)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), Mathf.Infinity, layerMask);
            returnVector = raycastHit.transform.position - transform.position;
        }
        else if (v == Direction.right && Right)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(1,0), Mathf.Infinity, layerMask);
            returnVector = raycastHit.transform.position - transform.position;
        }
        else if (v == Direction.left && Left)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), Mathf.Infinity, layerMask);
            returnVector = raycastHit.transform.position - transform.position;
        }
        else if (defaultv == Direction.up && Up)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(0, 1), Mathf.Infinity, layerMask);
            returnVector = raycastHit.transform.position - transform.position;
        }
        else if (defaultv == Direction.down && Down)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), Mathf.Infinity, layerMask);
            returnVector = raycastHit.transform.position - transform.position;
        }
        else if (defaultv == Direction.right && Right)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(1,0), Mathf.Infinity, layerMask);
            returnVector = raycastHit.transform.position - transform.position;
        }
        else if (defaultv == Direction.left && Left)
        {
            raycastHit = Physics2D.Raycast(transform.position, new Vector2(-1,0), Mathf.Infinity, layerMask);
            returnVector = raycastHit.transform.position - transform.position;
        }
        return returnVector;
    }
}
