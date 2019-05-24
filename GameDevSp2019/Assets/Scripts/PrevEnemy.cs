using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WASD;

public class PrevEnemy : Controller
{
    Direction d, prevd = Direction.up;
    public PlayerController player;
    bool awake = false;
    public int id;


    public GameObject pt1, pt2;
    bool toPt1, toPt2, spawning;

    protected override void MoveScheme()
    {
        /*
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
        }*/
        Vector2 dist;
        if (CanMove)
        {
            int r = Random.Range(0, 100);//directions old order: 1, 2, 3, 4, based on int dir
            if (r < 25f && GetDistance(Direction.up).magnitude != 0)
            {
                d = Direction.up;
                sprite.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            }
            else if (r < 50f && GetDistance(Direction.left).magnitude != 0)
            {
                d = Direction.left;
                sprite.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            }
            else if (r < 75f && GetDistance(Direction.down).magnitude != 0)
            {
                d = Direction.down;
                sprite.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            }
            else if (r <= 100 && GetDistance(Direction.right).magnitude != 0)
            {
                d = Direction.right;
                sprite.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            }
        }
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
        gameObject.GetComponentInChildren<Animator>().SetInteger("Farmer", id);
        speed = speed + GameObject.Find("UI").GetComponent<ScoreManager>().GetSpeedMod();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!toPt1 && !toPt2)
        {
            spawning = false;
        }
        if (!awake) {
            StartCoroutine("Sleep");
        } else if (spawning) {
            SpawnRoutine();
        } else {
            MoveScheme();
        }
    }
    IEnumerator Sleep()
    {
        sprite.GetComponent<SpriteRenderer>().enabled = false;
        int r = Random.Range(1, 4);
        yield return new WaitForSeconds(r + id);
        toPt1 = true;
        spawning = true;
        awake = true;
        sprite.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void SpawnRoutine()
    {
        if (toPt1)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, pt1.transform.position, speed * Time.deltaTime);
            if ((transform.position.x == pt1.transform.position.x) && (transform.position.y == pt1.transform.position.y))
            {
                toPt1 = false;
                toPt2 = true;
            }
        } else if (toPt2)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, pt2.transform.position, speed * Time.deltaTime);
            if ((transform.position.x == pt2.transform.position.x) && (transform.position.y == pt2.transform.position.y))
            {
                toPt2 = false;
            }
        }
    }

    public void SetSpawningToTrue()
    {
        spawning = true;
    }

    public void ToSleep()
    {
        this.gameObject.transform.position = spawn.transform.position;
        awake = false;
    }
}