using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempLegPart2 : LegClass
{
    

    // Start is called before the first frame update
    void Start()
    {
        partName = "TempLegs1";
        ID = 1;
        //part = Resources.Load("TempLegs1") as Sprite;
        weight = 100;
        hp = 1000;
        carryCap = 20000;
        walkSpd = 5;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
