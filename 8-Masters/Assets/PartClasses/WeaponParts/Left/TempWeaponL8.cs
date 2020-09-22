using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWeaponL8 : WeaponClass
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
        AM.Play("Shotgun");
        Transform barrel1 = Instantiate(barrel, barrel.position, barrel.rotation);
        Transform barrel2 = Instantiate(barrel, barrel.position, barrel.rotation);
        Transform barrel3 = Instantiate(barrel, barrel.position, barrel.rotation);
        Transform barrel4 = Instantiate(barrel, barrel.position, barrel.rotation);
        barrel1.rotation *= Quaternion.Euler(new Vector3(0, 0, 5));
        barrel2.rotation *= Quaternion.Euler(new Vector3(0, 0, 10));
        barrel3.rotation *= Quaternion.Euler(new Vector3(0, 0, -10));
        barrel4.rotation *= Quaternion.Euler(new Vector3(0, 0, -5));

        Vector2 barrelV = new Vector2(barrel.position.x, barrel.position.y);

        GameObject bullet = Instantiate(bulletPrefab, barrelV, barrel.rotation);
        GameObject bullet1 = Instantiate(bulletPrefab, barrelV, barrel1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, barrelV, barrel2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, barrelV, barrel3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, barrelV, barrel4.rotation);




        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(barrel.up * bulletSpeed, ForceMode2D.Impulse);

        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb1.AddForce(barrel1.up * bulletSpeed, ForceMode2D.Impulse);

        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(barrel2.up * bulletSpeed, ForceMode2D.Impulse);

        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(barrel3.up * bulletSpeed, ForceMode2D.Impulse);

        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        rb4.AddForce(barrel4.up * bulletSpeed, ForceMode2D.Impulse);

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

        MachineBullet MB4 = bullet4.GetComponent<MachineBullet>();
        MB4.damage = damage;
        MB4.range = range;
        MB4.isPlayer = isPlayer;

        Destroy(barrel1.gameObject);
        Destroy(barrel2.gameObject);
        Destroy(barrel3.gameObject);
        Destroy(barrel4.gameObject);
    }
}
