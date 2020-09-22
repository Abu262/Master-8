using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBullet : MonoBehaviour
{
    public float range;
    public float damage;
    public bool isPlayer;
    public GameObject EB;
    public float scaleFactor;
    Vector3 scaleChange;
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        range = Time.time + range;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > range)
        {
            Vector3 deathPos = this.gameObject.transform.position;
            GameObject E = Instantiate(EB, deathPos, Quaternion.identity);
            E.transform.localScale = scaleChange;
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag != "Drone")
        {

     
            if (isPlayer && collision.gameObject.tag == "Enemy" && collision.isTrigger)
            {
                Vector3 deathPos = this.gameObject.transform.position;
                GameObject E = Instantiate(EB, deathPos, Quaternion.identity);
                E.transform.localScale = scaleChange;
                Destroy(this.gameObject);
                collision.GetComponentInParent<EnemyScr>().currentHP -= (int)damage;
                collision.GetComponentInParent<EnemyScr>().struck = true ;
                //            Debug.Log(collision.gameObject.tag);
                //Debug.Log(collision.GetComponentInParent<EnemyScr>().currentHP);

            }
            else if (!isPlayer && collision.gameObject.tag == "Player" && collision.isTrigger)
            {
                Debug.Log(collision.name);
                Vector3 deathPos = this.gameObject.transform.position;
                GameObject E = Instantiate(EB, deathPos, Quaternion.identity);
                E.transform.localScale = scaleChange;
                Destroy(this.gameObject);
                if (collision.gameObject.layer == 15)
                {
                    collision.GetComponentInParent<EnemyScr>().currentHP -= (int)damage;
                }
                else
                {
                    Debug.Log(collision.gameObject.layer);
                    collision.GetComponentInParent<PlayerScr>().currentHP -= (int)damage;
                }

                //Debug.Log(collision.GetComponentInParent<PlayerScr>().currentHP);
                
            }
            else if (collision.gameObject.tag == "wall")
            {
                Vector3 deathPos = this.gameObject.transform.position;
                GameObject E = Instantiate(EB, deathPos, Quaternion.identity);
                E.transform.localScale = scaleChange;
                Destroy(this.gameObject);
            }

        }
    }
    
}
