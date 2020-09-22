﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeaponL1 : WeaponClass
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
    void Update()
    {
     
        if (fire == true)
        {
            activated = true;
        }
        else
        {
            activated = false;
        }
    }
    public override void Atk(Transform barrel, AudioManager AM, bool isPlayer)
    {

        AM.Play("Machinegun");
        Vector2 barrelV = new Vector2(barrel.position.x, barrel.position.y);
        GameObject bullet = Instantiate(bulletPrefab, barrelV, barrel.rotation);
        MachineBullet MB = bullet.GetComponent<MachineBullet>();
        MB.damage = damage;
        MB.range = range;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(barrel.up * bulletSpeed, ForceMode2D.Impulse);
        MB.isPlayer = isPlayer;

    }
}
