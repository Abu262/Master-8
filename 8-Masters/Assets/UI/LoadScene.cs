using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public int scene;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    public void click()
    {
        int weight = GM.LegList[GM.legsID].weight
+ GM.HeadList[GM.headID].weight
+ GM.TorsoList[GM.torsoID].weight + GM.WeaponLList[GM.gunLID].weight + GM.WeaponRList[GM.gunRID].weight;

        if (weight <= GM.LegList[GM.legsID].carryCap)
        {
            if (scene == 12)
            {
                GM.onFinalLevel1 = true;
            }
            else
            {
                GM.onFinalLevel1 = false;
            }
            SceneManager.LoadScene(scene);
        
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
