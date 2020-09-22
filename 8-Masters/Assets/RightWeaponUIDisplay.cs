using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RightWeaponUIDisplay : MonoBehaviour
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
        string LW = "RIGHT WEAPON: <#ff0000>" + GM.WeaponRList[GM.gunRID].partName + "</color>";

        string weight = "WEIGHT: " + (GM.LegList[GM.legsID].weight
            + GM.HeadList[GM.headID].weight
            + GM.TorsoList[GM.torsoID].weight + GM.WeaponLList[GM.gunLID].weight).ToString()
            + " + <#ff0000>" + (GM.WeaponRList[GM.gunRID].weight).ToString() + "</color>";

        string ammo = "AMMO: <#ff0000>" + GM.WeaponRList[GM.gunRID].ammo.ToString() + "</color>";

        string RR = "RELOAD SPEED: <#ff0000>" + GM.WeaponRList[GM.gunRID].reloadRate.ToString() + " seconds" + "</color>";

        string range = "Range: <#ff0000>" + GM.WeaponRList[GM.gunRID].range.ToString() + "</color>";

        string FR = "FIRE RATE: <#ff0000>" + GM.WeaponRList[GM.gunRID].fireRate.ToString() + " seconds" + "</color>";

        string damage = "DAMAGE: <#ff0000>" + GM.WeaponRList[GM.gunRID].damage.ToString() + "</color>";

        string BS = "BULLET SPEED: <#ff0000>" + GM.WeaponRList[GM.gunRID].bulletSpeed.ToString() + "</color>";


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
