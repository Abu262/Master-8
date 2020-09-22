using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBody : MonoBehaviour
{
    LegClass LC;
    HeadClass HC;
    TorsoClass TC;
    WeaponClass WrC;
    WeaponClass WlC;
    public GameManager GM;
    public SpriteRenderer SRLegs;
    public SpriteRenderer SRHead;
    public SpriteRenderer SRWeaponL;
    public SpriteRenderer SRWeaponR;
    public SpriteRenderer SRTorso;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        LC = GM.LegList[GM.legsID];
        HC = GM.HeadList[GM.headID];
        TC = GM.TorsoList[GM.torsoID];
        WrC = GM.WeaponRList[GM.gunRID];
        WlC = GM.WeaponLList[GM.gunLID];
        SRLegs.sprite = LC.part;
        SRLegs.material = LC.Emitter;
        SRHead.sprite = HC.part;
        SRHead.material = HC.Emitter;
        SRTorso.sprite = TC.part;
        SRTorso.material = TC.Emitter;
        SRWeaponR.sprite = WrC.part;
        SRWeaponR.material = WrC.Emitter;
        SRWeaponL.sprite = WlC.part;
        SRWeaponL.material = WlC.Emitter;
    }
}
