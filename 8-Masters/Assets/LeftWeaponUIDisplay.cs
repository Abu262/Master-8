using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LeftWeaponUIDisplay : MonoBehaviour
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
        string LW = "LEFT WEAPON: <#ff0000>" + GM.WeaponLList[GM.gunLID].partName + "</color>";

        string weight = "WEIGHT: " + (GM.LegList[GM.legsID].weight
            + GM.HeadList[GM.headID].weight
            + GM.TorsoList[GM.torsoID].weight + GM.WeaponRList[GM.gunRID].weight).ToString()
            + " + <#ff0000>" + (GM.WeaponLList[GM.gunLID].weight).ToString() + "</color>";

        string ammo = "AMMO: <#ff0000>" + GM.WeaponLList[GM.gunLID].ammo.ToString() + "</color>";

        string RR = "RELOAD SPEED: <#ff0000>" + GM.WeaponLList[GM.gunLID].reloadRate.ToString() + " seconds" + "</color>";

        string range = "Range: <#ff0000>" + GM.WeaponLList[GM.gunLID].range.ToString() + "</color>";

        string FR = "FIRE RATE: <#ff0000>" + GM.WeaponLList[GM.gunLID].fireRate.ToString() + " seconds" + "</color>";

        string damage = "DAMAGE: <#ff0000>" + GM.WeaponLList[GM.gunLID].damage.ToString() + "</color>";

        string BS = "BULLET SPEED: <#ff0000>" + GM.WeaponLList[GM.gunLID].bulletSpeed.ToString() + "</color>";


        Description.text = LW + "\n" + ammo + "\n" 
            + RR + "\n" + range + "\n" 
            + FR + "\n" + damage + "\n" 
            + BS + "\n" + weight;

    }
    public void remove()
    {
        Description.text = "";
    }
}
