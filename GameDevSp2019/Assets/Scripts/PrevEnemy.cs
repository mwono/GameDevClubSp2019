using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public class PrevEnemy : Controller
{
    Direction d, prevd = Direction.up;
    public PlayerController player;
    bool awake = false;
    Vector2 dist;

    protected override void MoveScheme()
    {
        transform.Translate(new Vector2(0, 0));
        Vector2[] possibleDistances = GetNeighbors();
        float minDist = float.MaxValue;
        int dir = -1;
        Nodes target = player.GetCurrentNode();
        if (player.GetNextNode() != null)
        {
            target = player.GetNextNode();
        }
        for (int i = 0; i < 4; i++)
        {
            if (possibleDistances[i] != new Vector2(0, 0))
                possibleDistances[i] = new Vector2(target.transform.position.x - possibleDistances[i].x
                    , target.transform.position.y - possibleDistances[i].y);
            if (possibleDistances[i].magnitude < minDist)
            {
                minDist = possibleDistances[i].magnitude;
                dir = i;
                //Debug.Log(dir);
            }
        }
        if (dir == 0)
            d = Direction.up;
        else if (dir == 1)
            d = Direction.left;
        else if (dir == 2)
            d = Direction.down;
        else if (dir == 3)
            d = Direction.right;
        else
            d = prevd;
        dist = GetDistance(d);
        prevd = d;
        if ((dist.magnitude == 0) || dist.magnitude == Mathf.Infinity)
        {
            dist = new Vector2(0, 0);
        }
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!awake)
        {
            StartCoroutine("Sleep");
        } else
        {
            MoveScheme();
            Move(dist);
        }
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(2);
        MoveScheme();
        awake = true;
    }
}