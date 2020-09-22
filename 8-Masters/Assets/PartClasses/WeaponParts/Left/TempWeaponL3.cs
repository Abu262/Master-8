using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeaponL3 : WeaponClass
{
    // Start is called before the first frame update
    void Start()
    {
        partName = "TempWeaponL1";
        ID = 1;
        weight = 500;
        ammo = 300;
        reloadRate = 2.0f;
        rightHand = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Atk(Transform barrel, AudioManager AM, bool isPlayer)
    {

        Vector2 barrelV = new Vector2(barrel.position.x, barrel.position.y);
        GameObject bullet = Instantiate(bulletPrefab, barrelV, barrel.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        MachineBullet MB = bullet.GetComponent<MachineBullet>();
        DroneAttack DA = bullet.GetComponent<DroneAttack>();
        DA.isPlayer = isPlayer;
        MB.damage = damage;
        MB.range = range;
        MB.isPlayer = isPlayer;

    }
}
