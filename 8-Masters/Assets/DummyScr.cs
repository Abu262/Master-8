using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DummyScr : EnemyScr
{

   
    private void Awake()
    {
        AM = FindObjectOfType<AudioManager>();
        GM = FindObjectOfType<GameManager>();
        if (AM.Playing("MenuSong"))
        {
            AM.Stop("MenuSong");
        }
      
        if (Boosters.isPlaying)
        {
            Boosters.Stop();
        }
        if (overBoosters.isPlaying)
        {
            overBoosters.Stop();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ID = 1;
        Hit.enabled = false;
        HitImage.enabled = false;
        seeker = GetComponent<Seeker>();
        AM = FindObjectOfType<AudioManager>();
        GM = FindObjectOfType<GameManager>();
        //GM = GameObject.FindGameObjectWithTag("GameManager");
        LC = GM.LegList[0];
        HC = GM.HeadList[0];
        TC = GM.TorsoList[0];
        WrC = GM.WeaponRList[0];
        WlC = GM.WeaponLList[0];

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
        Anim = legsChildren.GetComponent<Animator>();
        Anim.SetInteger("ArmorID", 0);
        SRLegs.sprite = LC.part;
        Anim.speed = 0;
        currentHP = 9999;
        maxHP = HC.hp + TC.hp + LC.hp;
        maxEnergy = TC.energy;
        currentEnergy = maxEnergy;
        currentAmmoL = WlC.ammo;
        currentAmmoR = WrC.ammo;
        BarrelL.position = new Vector2(BarrelL.position.x, BarrelL.position.y + WlC.barrelLength);
        BarrelR.position = new Vector2(BarrelR.position.x, BarrelR.position.y + WrC.barrelLength);
        //isBoosting = true;


        if (AM.Playing("MenuSong"))
        {
            AM.Stop("MenuSong");
        }
        if (Boosters.isPlaying)
        {
            Boosters.Stop();
        }
        if (overBoosters.isPlaying)
        {
            overBoosters.Stop();
        }


    }
   
    void UpdatePath()
    {


    }


    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }



    // Update is called once per frame
    void Update()
    {
        currentHP = 9999;

        if (Input.GetKey(KeyCode.Escape))
        {
            StartCoroutine(Reload());
        }
    }

    void FixedUpdate()
    {
        

    }

    IEnumerator Reload()
    {
        

        SceneManager.LoadScene(1);
        
        yield return null;
    }

}
