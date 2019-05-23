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

    public GameObject pt1, pt2;
    bool toPt1, toPt2, spawning;

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
            if (possibleDistances[i].magnitude != 0)
            {
                possibleDistances[i] = new Vector2(target.transform.position.x - possibleDistances[i].x
                    , target.transform.position.y - possibleDistances[i].y);
            }
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
        Move(dist);
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        toPt1 = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!awake)
        {
            StartCoroutine("Sleep");
        } else if (spawning)
        {
            SpawnRoutine();
        } else {
            MoveScheme();
            
        }
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSeconds(2);
        spawning = true;
        awake = true;
    }

    public void SpawnRoutine()
    {
        if (toPt1)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, pt1.transform.position, speed * Time.deltaTime);
            if (transform.position == pt1.transform.position)
            {
                toPt1 = false;
                toPt2 = true;
            }
        } else if (toPt2)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, pt2.transform.position, speed * Time.deltaTime);
            if (transform.position == pt2.transform.position)
            {
                toPt2 = false;
            }
        }
        if (!toPt1 && !toPt2)
        {
            toPt1 = true;
            spawning = false;
        }
    }

    public void SetSpawningToTrue()
    {
        spawning = true;
    }
}