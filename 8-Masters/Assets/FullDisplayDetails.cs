using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class FullDisplayDetails : MonoBehaviour
{
    public GameManager GM;
    public TextMeshProUGUI Description1;
    public TextMeshProUGUI Description2;
    public TextMeshProUGUI over;
    public Image I1;
    public Image I2;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        I2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        int weight = GM.LegList[GM.legsID].weight
       + GM.HeadList[GM.headID].weight
       + GM.TorsoList[GM.torsoID].weight + GM.WeaponLList[GM.gunLID].weight + GM.WeaponRList[GM.gunRID].weight;

        if (weight > GM.LegList[GM.legsID].carryCap)
        {
            over.text = "OVERWEIGHT!";
        }
        else
        {
            over.text = "";
        }
    }


    public void Hover()
    {
        string RW = "RIGHT WEAPON: " + GM.WeaponRList[GM.gunRID].partName  ;

        string weight = "WEIGHT: " + (GM.LegList[GM.legsID].weight
            + GM.HeadList[GM.headID].weight
            + GM.TorsoList[GM.torsoID].weight + GM.WeaponLList[GM.gunLID].weight + GM.WeaponRList[GM.gunRID].weight).ToString();

        string ammor = "AMMO: " + GM.WeaponRList[GM.gunRID].ammo.ToString();

        string RRr = "RELOAD SPEED: " + GM.WeaponRList[GM.gunRID].reloadRate.ToString() + " seconds";

        string ranger = "Range: " + GM.WeaponRList[GM.gunRID].range.ToString();

        string FRr = "FIRE RATE: " + GM.WeaponRList[GM.gunRID].fireRate.ToString() + " seconds";

        string damager = "DAMAGE: " + GM.WeaponRList[GM.gunRID].damage.ToString();

        string BS = "BULLET SPEED: " + GM.WeaponRList[GM.gunRID].bulletSpeed.ToString();

      

        string LW = "LEFT WEAPON: " + GM.WeaponLList[GM.gunLID].partName  ;

        string ammol = "AMMO: " + GM.WeaponLList[GM.gunLID].ammo.ToString();

        string RRl = "RELOAD SPEED: " + GM.WeaponLList[GM.gunLID].reloadRate.ToString() + " seconds";

        string rangel = "Range: " + GM.WeaponLList[GM.gunLID].range.ToString();

        string FRl = "FIRE RATE: " + GM.WeaponLList[GM.gunLID].fireRate.ToString() + " seconds";

        string damagel = "DAMAGE: " + GM.WeaponLList[GM.gunLID].damage.ToString();

        string BSl = "BULLET SPEED: " + GM.WeaponLList[GM.gunLID].bulletSpeed.ToString();




        string torso = "TORSO: " + GM.TorsoList[GM.torsoID].partName  ;

        string hp = "AP: " + (GM.LegList[GM.legsID].hp
            + GM.HeadList[GM.headID].hp + GM.TorsoList[GM.torsoID].hp).ToString();


        string Energy = "ENERGY: " + GM.TorsoList[GM.torsoID].energy.ToString()  ;

        string CR = "CHARGE RATE: " + GM.TorsoList[GM.torsoID].chargeRate.ToString() + " seconds";






        string legs = "LEGS: " + GM.LegList[GM.legsID].partName  ;


 

        string carryCap = "CARRY CAP: " + GM.LegList[GM.legsID].carryCap.ToString()  ;

        string walkSpd = "WALK SPD: " + GM.LegList[GM.legsID].walkSpd.ToString()  ;

        string Booster = "BOOSTER SPD: " + GM.LegList[GM.legsID].boosters.ToString()  ;

        string Consumption = "CONSUMPTION RATE: " + GM.LegList[GM.legsID].consumptionRate.ToString() + " seconds";





        string head = "HEAD: " + GM.HeadList[GM.headID].partName  ;
        string spec = "SPEC: ";
        if (GM.HeadList[GM.headID].type == "blast")
        {
            spec += " Blast"  ;
        }
        else if (GM.HeadList[GM.headID].type == "boost")
        {
            spec += " Boost"  ;
        }
        else
        {
            spec += " None"  ;
        }

    

        string radar = "RADAR: x" + (GM.HeadList[GM.headID].radar).ToString()  ;
        I1.enabled = false;
        I2.enabled = true;
        Description1.text = RW + "\n" + ammor + "\n" + RRr + "\n" + ranger + "\n" + FRr + "\n" + damager + "\n" + BS + "\n\n";
        Description1.text += LW + "\n" + ammol + "\n" + RRl + "\n" + rangel + "\n" + FRl + "\n" + damagel + "\n" + BSl + "\n\n"; 
        Description2.text = torso + "\n" + Energy + "\n" + CR + "\n\n";
        Description2.text += legs + "\n" + carryCap + "\n" + walkSpd + "\n" + Booster + "\n" + Consumption + "\n\n";
        Description2.text += head + "\n" + spec + "\n" + radar + "\n\n" + weight + "\n" + hp;


    }

    public void remove()
    {
        I2.enabled = false;
        I1.enabled = true;
        Description1.text = "";
        Description2.text = "";
    }
}
