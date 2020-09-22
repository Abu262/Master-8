using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeadUIDisplay : MonoBehaviour
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
        string head = "HEAD: <#ff0000>" + GM.HeadList[GM.headID].partName + "</color>";
        string spec = "SPEC: <#ff0000>";
        if (GM.HeadList[GM.headID].type == "blast")
        {
            spec += " Blast" + "</color>";
        }
        else if (GM.HeadList[GM.headID].type == "boost")
        {
            spec += " Boost" + "</color>";
        }
        else
        {
            spec += " None" + "</color>";
        }

        string weight = "WEIGHT: " + (GM.TorsoList[GM.torsoID].weight 
            + GM.LegList[GM.legsID].weight 
            + GM.WeaponLList[GM.gunLID].weight + +GM.WeaponRList[GM.gunRID].weight).ToString()
            + " + <#ff0000>" + (GM.HeadList[GM.headID].weight).ToString() + "</color>";

        string hp = "AP: " + (GM.TorsoList[GM.torsoID].hp
            + GM.LegList[GM.legsID].hp).ToString()
            + " + <#ff0000>" + (GM.HeadList[GM.headID].hp).ToString() + "</color>";

        string radar = "RADAR: <#ff0000> x" + (GM.HeadList[GM.headID].radar).ToString() + "</color>";
        Description.text = head + "\n" + spec + "\n" + "\n" + radar + "\n" + weight + "\n" + hp;

    }
    public void remove()
    {
        Description.text = "";
    }
}
