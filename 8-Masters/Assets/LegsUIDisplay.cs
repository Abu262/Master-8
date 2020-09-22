using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LegsUIDisplay : MonoBehaviour
{
    public GameManager GM;
    public TextMeshProUGUI Description;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Hover()
    {
        string legs = "LEGS: <#ff0000>" + GM.LegList[GM.legsID].partName + "</color>";

        string weight = "WEIGHT: " + (GM.TorsoList[GM.torsoID].weight
            + GM.HeadList[GM.headID].weight
            + GM.WeaponLList[GM.gunLID].weight + +GM.WeaponRList[GM.gunRID].weight).ToString()
            + " + <#ff0000>" + (GM.LegList[GM.legsID].weight).ToString() + "</color>";

        string hp = "AP: " + (GM.TorsoList[GM.torsoID].hp
            + GM.HeadList[GM.headID].hp).ToString()
            + " + <#ff0000>" + (GM.LegList[GM.legsID].hp).ToString() + "</color>";

        string carryCap = "CARRY CAP: <#ff0000>" + GM.LegList[GM.legsID].carryCap.ToString() + "</color>";

        string walkSpd = "WALK SPD: <#ff0000>" + GM.LegList[GM.legsID].walkSpd.ToString() + "</color>";

        string BS = "BOOSTER SPD: <#ff0000>" + GM.LegList[GM.legsID].boosters.ToString() + "</color>";

        string CR = "CONSUMPTION RATE: <#ff0000>" + GM.LegList[GM.legsID].consumptionRate.ToString() + " seconds" + "</color>";



        Description.text = legs + "\n" + carryCap + "\n" + walkSpd + "\n" + BS + "\n" + CR + "\n" + weight + "\n" + hp;

    }
    public void remove()
    {
        Description.text = "";
    }
}
