using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetStats()
    {
        for (int i = 1; i < GM.statusPref.Count; i++)
        {
            PlayerPrefs.SetInt("statusPref_" + i, 0);

            GM.slainEnemies = 0;
            GM.statusE[i] = false;


        }
        GM.headID = 0;
        GM.legsID = 0;
        GM.torsoID = 0;
        GM.gunRID = 0;
        GM.gunLID = 0;

    }
}
