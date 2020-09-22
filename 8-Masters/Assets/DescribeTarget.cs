using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DescribeTarget : MonoBehaviour
{
    public int index;
    public GameManager GM;
    public string status;
    public string desc;
    public string name;
    public string location;
    public TextMeshProUGUI T;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (name != "MASTER" && GM.statusE[index] == true)
        {
            status = "DEFEATED";
        }
        else
        {
            status = "ALIVE";
        }
       
    }

    public void hover()
    {
        if (name != "MASTER")
        {
            GM.headIDEnemy = index;
            GM.legsIDEnemy = index;
            GM.torsoIDEnemy = index;
            GM.gunRIDEnemy = index;
            GM.gunLIDEnemy = index;

        }
        else
        {
            GM.headIDEnemy = -1;
            GM.legsIDEnemy = -1;
            GM.torsoIDEnemy = -1;
            GM.gunRIDEnemy = -1;
            GM.gunLIDEnemy = -1;
        }
        T.text = "Name: " + name + "\n\n" + "Location: " + location + "\n\n" + "Status: " + status + "\n\n" + desc;
    }

    public void hoverOff()
    {
        GM.headIDEnemy = -1;
        GM.legsIDEnemy = -1;
        GM.torsoIDEnemy = -1;
        GM.gunRIDEnemy = -1;
        GM.gunLIDEnemy = -1;
        T.text = "";
    }
}