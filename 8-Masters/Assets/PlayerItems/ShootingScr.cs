using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootingScr : MonoBehaviour
{
    public GameManager GM;
    public AudioManager AM;

    public PlayerScr PS;
    WeaponClass WrC;
    WeaponClass WlC;
    HeadClass HC;
    bool LeftActivated = false;
    bool rightActivated = false;
    float timeStampR = 0.0f;
    float timeStampL = 0.0f;

    float ammoTimeStampR = 0.0f;
    float ammoTimeStampL = 0.0f;
    int currentAmmoR;
    int currentAmmoL;

    public Transform BarrelL;
    public Transform BarrelR;

    //referneces for UI
    public TextMeshProUGUI ammoTextR;
    public TextMeshProUGUI ammoTextL;

    public TextMeshProUGUI GunNameTextR;
    public TextMeshProUGUI GunNameTextL;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        AM = FindObjectOfType<AudioManager>();
        WrC = GM.WeaponRList[GM.gunRID];
        WlC = GM.WeaponLList[GM.gunLID];
        HC = GM.HeadList[GM.headID];
        BarrelL.position = new Vector2(BarrelL.position.x, BarrelL.position.y + WlC.barrelLength);
        BarrelR.position = new Vector2(BarrelR.position.x, BarrelR.position.y + WrC.barrelLength);
        currentAmmoL = WlC.ammo;
        currentAmmoR = WrC.ammo;

        GunNameTextR.text = WrC.partName;
        GunNameTextL.text = WlC.partName;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (PS.active)
        {

            if (Input.GetKey(KeyCode.Mouse1) && PS.dead == false)
            {

                WrC.fire = true;
            }
            else
            {
                WrC.fire = false;
            }


            if (WrC.fire == true && Time.time > timeStampR && currentAmmoR > 0 && PS.dead == false)
            {
                timeStampR = Time.time + WrC.fireRate;
                currentAmmoR -= 1;
                WrC.Atk(BarrelR, AM, true);
            }

            if (((WrC.fire == false && currentAmmoR < WrC.ammo) || currentAmmoR <= 0) && Time.time > ammoTimeStampR)
            {
                ammoTimeStampR = Time.time + WrC.reloadRate;
                currentAmmoR += 1;

            }
            ammoTextR.text = currentAmmoR.ToString() + "/" + WrC.ammo.ToString();


            if (Input.GetKey(KeyCode.Mouse0) && PS.dead == false)
            {

                WlC.fire = true;
            }
            else
            {
                WlC.fire = false;
            }

            if (HC.type == "blast" && Input.GetKeyDown(KeyCode.LeftShift) && PS.currentEnergy >= HC.cost && PS.dead == false)
            {
                PS.currentEnergy -= HC.cost;
                HC.Special(gameObject.transform, true);
            }


            if (WlC.fire == true && Time.time > timeStampL && currentAmmoL > 0 && PS.dead == false)
            {
                timeStampL = Time.time + WlC.fireRate;
                currentAmmoL -= 1;
                WlC.Atk(BarrelL, AM, true);
            }

            if (((WlC.fire == false && currentAmmoL < WlC.ammo) || currentAmmoL <= 0) && Time.time > ammoTimeStampL)
            {

                ammoTimeStampL = Time.time + WlC.reloadRate;
                currentAmmoL += 1;

            }
            ammoTextL.text = currentAmmoL.ToString() + "/" + WlC.ammo.ToString();
        }
    }
}
