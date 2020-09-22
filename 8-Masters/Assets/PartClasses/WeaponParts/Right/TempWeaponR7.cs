using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeaponR7 : WeaponClass
{
    // Start is called before the first frame update
    void Start()
    {
        partName = "TempWeaponR1";
        ID = 1;
        weight = 500;
        ammo = 300;
        reloadRate = 2.0f;
        rightHand = true;
}

    // Update is called once per frame
    void Update()
    {

    }
    public override void Atk(Transform barrel, AudioManager AM, bool isPlayer)
    {

        AM.Play("Rifle");
        Vector2 barrelV = new Vector2(barrel.position.x, barrel.position.y);
        GameObject bullet = Instantiate(bulletPrefab, barrelV, barrel.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(barrel.up * bulletSpeed, ForceMode2D.Impulse);
        MachineBullet MB = bullet.GetComponent<MachineBullet>();
        MB.damage = damage;
        MB.range = range;
        MB.isPlayer = isPlayer;
    }
}
