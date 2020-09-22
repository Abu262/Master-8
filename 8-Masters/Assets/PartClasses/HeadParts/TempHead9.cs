using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHead9 : HeadClass
{
    public GameObject OA;
    // Start is called before the first frame update
    void Start()
    {
        partName = "TempHead1";
        ID = 1;
        weight = 1000;
        hp = 500;
        radar = 4;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Special(Transform pos, bool isPlayer)
    {
        Vector2 T = new Vector2(pos.position.x, pos.position.y);
        GameObject blast = Instantiate(Override, T, pos.rotation);



        OverrideAtk OA = blast.GetComponent<OverrideAtk>();
        OA.damage = damage;

        OA.isPlayer = isPlayer;


    }
}