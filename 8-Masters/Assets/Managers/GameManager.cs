using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public bool lockHP;
    public bool onFinalLevel1;
    public bool onFinalLevel2;
    public int slainEnemies;
    public List<LegClass> LegList;
    public List<WeaponClass> WeaponRList;
    public List<WeaponClass> WeaponLList;
    public List<HeadClass> HeadList;
    public List<TorsoClass> TorsoList;

    public List<bool> statusE;

    public List<int> statusPref;



    public static GameManager instance;

    public int headID;
    public int legsID;
    public int torsoID;
    public int gunRID;
    public int gunLID;


    public int headIDEnemy;
    public int legsIDEnemy;
    public int torsoIDEnemy;
    public int gunRIDEnemy;
    public int gunLIDEnemy;


    private void Awake()
    {
        slainEnemies = 0;
        PlayerPrefs.SetInt("statusPref_count", statusPref.Count);
        PlayerPrefs.GetInt("statusPref_survivor", 1);

        for (int i = 0; i < statusPref.Count; i++)
        {
            PlayerPrefs.GetInt("statusPref_" + i, 0);
            
        }


        PlayerPrefs.SetInt("statusPref_" + 0, 1);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        for (int i = 1; i < statusPref.Count; i++)
        {
          if (PlayerPrefs.GetInt("statusPref_" + i) == 1)
            {
                slainEnemies += 1;
                statusE[i] = true;
            }

        }


        DontDestroyOnLoad(instance);




    }

 


    void Update()
    {

        if (Application.targetFrameRate!= 60)
            Application.targetFrameRate = 60;
    }
}
