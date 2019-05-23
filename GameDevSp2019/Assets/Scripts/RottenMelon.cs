using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RottenMelon : Collectible
{
    public ScoreManager manager;
    MelonSpawner ms;

    public override void Collect()
    {
        manager.updateScore(-10);
        ms.CollectedRotten();
        ms = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("UI").GetComponent<ScoreManager>();
    }

    private void Update()
    {
        if (ms != null)
        {
            transform.position = ms.transform.position;
        }
    }

    public void SetSpawner(MelonSpawner spawner)
    {
        ms = spawner;
    }
}
