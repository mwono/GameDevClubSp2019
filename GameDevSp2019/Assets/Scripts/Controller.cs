using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public abstract class Controller : MonoBehaviour
{
    private Vector2[] Distances;
    private Nodes Current, Next;
    // Start is called before the first frame update
    void Awake()
    {
        Distances = new Vector2[4];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Equals("Node"))
        {
            Nodes n = collision.GetComponent<Nodes>();
            Distances[0] = n.Director(Direction.up, Direction.up);
            Distances[1] = n.Director(Direction.left, Direction.left);
            Distances[2] = n.Director(Direction.down, Direction.down);
            Distances[3] = n.Director(Direction.right, Direction.right);
            Current = n;
        }
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

    public void Move(Vector2 Dist)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Dist);
        if (hit.collider != null)
        {
            SetNextNode(hit.collider.GetComponent<Nodes>());
        }
        transform.Translate(Dist * Time.deltaTime);
    }

    public abstract void MoveScheme();
}
