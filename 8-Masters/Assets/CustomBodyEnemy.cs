using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBodyEnemy : MonoBehaviour
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
        SRLegs.enabled = false;
        SRHead.enabled = false;
        SRWeaponL.enabled = false;
        SRWeaponR.enabled = false;
        SRTorso.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.legsIDEnemy != -1)
        {
            SRLegs.enabled = true;
            SRHead.enabled = true;
            SRWeaponL.enabled = true;
            SRWeaponR.enabled = true;
            SRTorso.enabled = true;
            LC = GM.LegList[GM.legsIDEnemy];
            HC = GM.HeadList[GM.headIDEnemy];
            TC = GM.TorsoList[GM.torsoIDEnemy];
            WrC = GM.WeaponRList[GM.gunRIDEnemy];
            WlC = GM.WeaponLList[GM.gunLIDEnemy];
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
        else
        {
            SRLegs.enabled = false;
            SRHead.enabled = false;
            SRWeaponL.enabled = false;
            SRWeaponR.enabled = false;
            SRTorso.enabled = false;
        }
    }
}