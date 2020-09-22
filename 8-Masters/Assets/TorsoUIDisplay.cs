using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TorsoUIDisplay : MonoBehaviour
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
        string torso = "TORSO: <#ff0000>" + GM.TorsoList[GM.torsoID].partName + "</color>";

        string weight = "WEIGHT: " + (GM.LegList[GM.legsID].weight
            + GM.HeadList[GM.headID].weight
            + GM.WeaponLList[GM.gunLID].weight + +GM.WeaponRList[GM.gunRID].weight).ToString()
            + " + <#ff0000>" + (GM.TorsoList[GM.torsoID].weight).ToString() + "</color>";

        string hp = "AP: " + (GM.LegList[GM.legsID].hp
            + GM.HeadList[GM.headID].hp).ToString()
            + " + <#ff0000>" + (GM.TorsoList[GM.torsoID].hp).ToString() + "</color>";

        string Energy = "ENERGY: <#ff0000>" + GM.TorsoList[GM.torsoID].energy.ToString() + "</color>";

        string CR = "CHARGE RATE: <#ff0000>" + GM.TorsoList[GM.torsoID].chargeRate.ToString() + " seconds" + "</color>";

        Description.text = torso + "\n" + Energy + "\n" + CR + "\n" + weight + "\n" + hp;

    }

    public void remove()
    {
        Description.text = "";
    }
}
