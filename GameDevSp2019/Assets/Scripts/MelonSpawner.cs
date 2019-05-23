using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonSpawner : MonoBehaviour
{
    public MelonPool mp;
    bool active;

    private void Start()
    {
        StartCoroutine("timer");
    }

    // Update is called once per frame
    void Update()
    {
        float r = Random.Range(0, 1);
        if (r < .15f && (mp.activeRottens < mp.totalRottens) && active)
        {
            GameObject rottenMelon = mp.GetRottenMelon();
            if (rottenMelon != null) {
                rottenMelon.transform.position = this.transform.position;
                rottenMelon.GetComponent<RottenMelon>().SetSpawner(this);
                mp.activeRottens++;
                StartCoroutine("timer");
            }
        } else if (r < .35f && (mp.activeMelons < mp.totalMelons) && active) {
            GameObject melon = mp.GetMelon();
            if (melon != null) {
                melon.transform.position = this.transform.position;
                melon.GetComponent<Melon>().SetSpawner(this);
                mp.activeMelons++;
                StartCoroutine("timer");
            }
        } else
        {
            StartCoroutine("timer");
        }
    }

    IEnumerator timer()
    {
        active = false;
        yield return new WaitForSeconds(10);
        active = true;
    }

    public void CollectedMelon()
    {
        mp.activeMelons--;
    }

    public void CollectedRotten()
    {
        mp.activeRottens--;
    }
}
