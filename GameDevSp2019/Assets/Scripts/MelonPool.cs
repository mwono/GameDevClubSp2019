using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelonPool : MonoBehaviour
{
    public GameObject[] melons;
    public GameObject[] rottenMelons;

    public int activeMelons, activeRottens, totalMelons, totalRottens;

    private void Start()
    {
        totalMelons = 3;
        totalRottens = 3;
    }

    public GameObject GetMelon()
    {
        GameObject m = null;
        for (int i = 0; i < melons.Length; i++)
        {
            if (!melons[i].activeInHierarchy)
            {
                m = melons[i];
                melons[i].SetActive(true);
                break;
            }
        }
        return m;
    }

    public GameObject GetRottenMelon()
    {
        GameObject m = null;
        for (int i = 0; i < rottenMelons.Length; i++)
        {
            if (!rottenMelons[i].activeInHierarchy)
            {
                m = rottenMelons[i];
                rottenMelons[i].SetActive(true);
                break;
            }
        }
        return m;
    }
}
