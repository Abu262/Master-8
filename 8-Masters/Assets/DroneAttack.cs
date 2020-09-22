using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttack : MonoBehaviour
{
    AudioManager AM;
    public bool isPlayer;
    public int droneDamage;
    int moveSpeed = 6;
    public float range;
    public int speed;
    public float fireRate;
    public GameObject bulletPrefab;
    bool firing;
    public float timeStamp = 0.0f;
    public Transform barrel;
    Rigidbody2D rb;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (isPlayer == true)
        {
            target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
            AM = FindObjectOfType<AudioManager>();
        }
        else
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            AM = FindObjectOfType<AudioManager>();
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        if (firing == true && Time.time > timeStamp)
        {
            timeStamp = Time.time + fireRate;
            
            Atk(barrel, AM);
        }

        if (firing == false)
        {
//            rb.position + transform.up * LC.boosters * Time.fixedDeltaTime
            rb.AddForce(transform.up * moveSpeed * Time.fixedDeltaTime);
        }


        Vector3 targ = target.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle-90));



    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //player fired it
        if (isPlayer == true)
        {
            if (collision.tag == "Enemy")
            {
                firing = true;
            }
        }

        else if (isPlayer == false)
        {
            if (collision.tag == "Player")
            {
                firing = true;
            }
        }
    }

    public void Atk(Transform barrel, AudioManager AM)
    {
        AM.Play("Rifle");
        Vector2 barrelV = new Vector2(barrel.position.x, barrel.position.y);
        GameObject bullet = Instantiate(bulletPrefab, barrelV, barrel.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(barrel.up * speed, ForceMode2D.Impulse);
        MachineBullet MB = bullet.GetComponent<MachineBullet>();
        MB.damage = droneDamage;
        MB.range = range;
        MB.isPlayer = isPlayer;

    }
}
