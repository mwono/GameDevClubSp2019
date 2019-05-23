using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public abstract class Controller : MonoBehaviour
{
    public GameObject menu, spawn;
    private Vector2[] Distances;
    private Nodes Current, Next;
    protected bool CanMove = true;

    public Transform sprite;

    public float speed;
    // Start is called before the first frame update
    void Awake()
    {
        Distances = new Vector2[4];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Equals("Node"))
        {
            CanMove = true;
            Nodes n = collision.GetComponent<Nodes>();
            Distances = new Vector2[4];
            Distances[0] = n.Director(Direction.up, Direction.up);
            Distances[1] = n.Director(Direction.left, Direction.left);
            Distances[2] = n.Director(Direction.down, Direction.down);
            Distances[3] = n.Director(Direction.right, Direction.right);
            Current = n;
            MoveScheme();
        } else if (collision.name.Equals("Player"))
        {
            if (!collision.GetComponent<Invincibility>().getInvincible())
            {
                menu.SetActive(true);
            } else
            {
                this.gameObject.transform.position = spawn.transform.position;
                this.gameObject.SetActive(false);
            }
                
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanMove = false;
    }

    public Nodes GetCurrentNode()
    {
        return Current;
    }

    public Nodes GetNextNode()
    {
        return Next;
    }

    public void SetNextNode(Nodes n)
    {
        Next = n;
    }

    public Vector2[] GetDistances()
    {
        return Distances;
    }

    public Vector2[] GetNeighbors()
    {
        Vector2[] neighbors = new Vector2[4];
        LayerMask layerMask = LayerMask.GetMask("Node");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, 1), Mathf.Infinity, layerMask);
        if (hit.collider != null)
            neighbors[0] = hit.collider.transform.position;
        hit = Physics2D.Raycast(transform.position, new Vector2(-1, 0), Mathf.Infinity, layerMask);
        if (hit.collider != null)
            neighbors[1] = hit.collider.transform.position;
        hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), Mathf.Infinity, layerMask);
        if (hit.collider != null)
            neighbors[2] = hit.collider.transform.position;
        hit = Physics2D.Raycast(transform.position, new Vector2(1, 0), Mathf.Infinity, layerMask);
        if (hit.collider != null)
            neighbors[3] = hit.collider.transform.position;
        return neighbors;
    }

    public Vector2 GetDistance(Direction d)
    {
        switch (d)
        {
            case Direction.up: return Distances[0];
            case Direction.left: return Distances[1];
            case Direction.down: return Distances[2];
            case Direction.right: return Distances[3];
        }
        return new Vector2();
    }

    protected void Move(Vector2 Dist)
    {
        
        if (Dist.magnitude > 0)
        {
            LayerMask layerMask = LayerMask.GetMask("Node", "Wall");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Dist * Mathf.Infinity, layerMask);
            if (hit.collider != null && !hit.collider.name.Equals("CornFields"))
            {
                SetNextNode(hit.collider.GetComponent<Nodes>());
            }

            transform.Translate((Dist / Dist.magnitude) * Time.deltaTime * speed);
        }
    }

    protected abstract void MoveScheme();
}
