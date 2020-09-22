using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeaponL5 : WeaponClass
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
        AM.Play("Machinegun");
        



        Vector3 barrelV = new Vector3(barrel.position.x, barrel.position.y)  + (barrel.right * 0.2f);
        Vector2 barrelV1 = new Vector3(barrel.position.x, barrel.position.y) + (barrel.right * 0.1f);
        Vector2 barrelV2 = new Vector3(barrel.position.x, barrel.position.y) + (barrel.right * -0.2f);
        Vector2 barrelV3 = new Vector3(barrel.position.x, barrel.position.y) + (barrel.right * -0.1f);


        GameObject bullet = Instantiate(bulletPrefab, barrelV, barrel.rotation);


        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(barrel.up * bulletSpeed, ForceMode2D.Impulse);

        GameObject bullet1 = Instantiate(bulletPrefab, barrelV1, barrel.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(barrel.up * bulletSpeed, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, barrelV2, barrel.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(barrel.up * bulletSpeed, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab, barrelV3, barrel.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(barrel.up * bulletSpeed, ForceMode2D.Impulse);

        MachineBullet MB = bullet.GetComponent<MachineBullet>();
        MB.damage = damage;
        MB.range = range;
        MB.isPlayer = isPlayer;

        MachineBullet MB1 = bullet1.GetComponent<MachineBullet>();
        MB1.damage = damage;
        MB1.range = range;
        MB1.isPlayer = isPlayer;

        MachineBullet MB2 = bullet2.GetComponent<MachineBullet>();
        MB2.damage = damage;
        MB2.range = range;
        MB2.isPlayer = isPlayer;

        MachineBullet MB3 = bullet3.GetComponent<MachineBullet>();
        MB3.damage = damage;
        MB3.range = range;
        MB3.isPlayer = isPlayer;
    }
}
