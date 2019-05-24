using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonSpawner : MonoBehaviour
{
    public MelonPool mp;
    bool spawned, active;

    private void Start()
    {
        StartCoroutine("timer");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int r = Random.Range(0, 100);
        if (r < 15f && (mp.activeRottens < mp.totalRottens) && active && !spawned)
        {
            GameObject rottenMelon = mp.GetRottenMelon();
            if (rottenMelon != null) {
                rottenMelon.transform.position = this.transform.position;
                rottenMelon.GetComponent<RottenMelon>().SetSpawner(this);
                mp.activeRottens++;
                spawned = true;
            }
        } else if (r < 35f && (mp.activeMelons < mp.totalMelons) && active && !spawned) {
            GameObject melon = mp.GetMelon();
            if (melon != null) {
                melon.transform.position = this.transform.position;
                melon.GetComponent<Melon>().SetSpawner(this);
                mp.activeMelons++;
                spawned = true;
            }
        } else if (active && !spawned) {
            StartCoroutine("timer");
        }
    }

    IEnumerator timer()
    {
        active = false;
        int r = Random.Range(10, 30);
        yield return new WaitForSeconds(r);
        active = true;
    }

    public void CollectedMelon()
    {
        mp.activeMelons--;
        spawned = false;
        StartCoroutine("timer");
    }

    public void CollectedRotten()
    {
        mp.activeRottens--;
        spawned = false;
        StartCoroutine("timer");
    }
}
