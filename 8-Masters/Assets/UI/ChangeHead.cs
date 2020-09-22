using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeHead : MonoBehaviour
{
    public GameManager GM;
    public string type = "";
    public bool increase;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }




    public void click()
    {


        if (type == "head")
        {
            if (increase == true)
            {

                if (GM.headID + 1 >= GM.HeadList.Count)
                {
                    GM.headID = 0;
                }
                else
                {
                    GM.headID += 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.headID) == 0)
                {
                    if (GM.headID + 1 >= GM.HeadList.Count)
                    {
                        GM.headID = 0;
                    }
                    else
                    {
                        GM.headID += 1;
                    }
                }
            }
            else
            {
                if (GM.headID - 1 < 0)
                {
                    GM.headID = GM.HeadList.Count - 1;
                }
                else
                {
                    GM.headID -= 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.headID) == 0)
                {
                    if (GM.headID - 1 < 0)
                    {
                        GM.headID = GM.HeadList.Count - 1;
                    }
                    else
                    {
                        GM.headID -= 1;
                    }
                }             
            }
        }
        else if (type == "legs")
        {
            if (increase == true)
            {
                if (GM.legsID + 1 >= GM.LegList.Count)
                {
                    GM.legsID = 0;
                }
                else
                {
                    GM.legsID += 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.legsID) == 0)
                {
                    if (GM.legsID + 1 >= GM.LegList.Count)
                    {
                        GM.legsID = 0;
                    }
                    else
                    {
                        GM.legsID += 1;
                    }
                }
            }
            else
            {
                if (GM.legsID - 1 < 0)
                {
                    GM.legsID = GM.LegList.Count - 1;
                }
                else
                {
                    GM.legsID -= 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.legsID) == 0)
                {
                    if (GM.legsID - 1 < 0)
                    {
                        GM.legsID = GM.LegList.Count - 1;
                    }
                    else
                    {
                        GM.legsID -= 1;
                    }
                }
            }
        }
        else if (type == "torso")
        {
            if (increase == true)
            {
                if (GM.torsoID + 1 >= GM.TorsoList.Count)
                {
                    GM.torsoID = 0;
                }
                else
                {
                    GM.torsoID += 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.torsoID) == 0)
                {
                    if (GM.torsoID + 1 >= GM.TorsoList.Count)
                    {
                        GM.torsoID = 0;
                    }
                    else
                    {
                        GM.torsoID += 1;
                    }
                }
            }
            else
            {
                if (GM.torsoID - 1 < 0)
                {
                    GM.torsoID = GM.TorsoList.Count - 1;
                }
                else
                {
                    GM.torsoID -= 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.torsoID) == 0)
                {
                    if (GM.torsoID - 1 < 0)
                    {
                        GM.torsoID = GM.TorsoList.Count - 1;
                    }
                    else
                    {
                        GM.torsoID -= 1;
                    }
                }
            }
        }
        else if (type == "lgun")
        {
            if (increase == true)
            {
                if (GM.gunLID + 1 >= GM.WeaponLList.Count)
                {
                    GM.gunLID = 0;
                }
                else
                {
                    GM.gunLID += 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.gunLID) == 0)
                {
                    if (GM.gunLID + 1 >= GM.WeaponLList.Count)
                    {
                        GM.gunLID = 0;
                    }
                    else
                    {
                        GM.gunLID += 1;
                    }
                }
            }
            else
            {
                if (GM.gunLID - 1 < 0)
                {
                    GM.gunLID = GM.WeaponLList.Count - 1;
                }
                else
                {
                    GM.gunLID -= 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.gunLID) == 0)
                {
                    if (GM.gunLID - 1 < 0)
                    {
                        GM.gunLID = GM.WeaponLList.Count - 1;
                    }
                    else
                    {
                        GM.gunLID -= 1;
                    }
                }
            }
        }
        else if (type == "rgun")
        {
            if (increase == true)
            {
                if (GM.gunRID + 1 >= GM.WeaponRList.Count)
                {
                    GM.gunRID = 0;
                }
                else
                {
                    GM.gunRID += 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.gunRID) == 0)
                {
                    if (GM.gunRID + 1 >= GM.WeaponRList.Count)
                    {
                        GM.gunRID = 0;
                    }
                    else
                    {
                        GM.gunRID += 1;
                    }
                }
            }
            else
            {
                if (GM.gunRID - 1 < 0)
                {
                    GM.gunRID = GM.WeaponRList.Count - 1;
                }
                else
                {
                    GM.gunRID -= 1;
                }
                while (PlayerPrefs.GetInt("statusPref_" + GM.gunRID) == 0)
                {
                    if (GM.gunRID - 1 < 0)
                    {
                        GM.gunRID = GM.WeaponRList.Count - 1;
                    }
                    else
                    {
                        GM.gunRID -= 1;
                    }
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
