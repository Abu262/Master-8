using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverrideAtk : MonoBehaviour
{
    float timestamp = 0.0f;
    public Transform T;
    public SpriteRenderer SR;
    public Animator anim;
    public bool isPlayer;
    Vector3 scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
    float speed = 0.75f;
    bool blast = false;
    float timeStampDamage = 0.0f;
    public float damage = 20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (T.localScale.x < 4 && Time.time > timestamp + speed)
        {
            if (speed != 0.75f)
            {
                if (speed > 0.01f)
                {
                    if (blast == false)
                    {
                        blast = true;
                        AudioManager AM = FindObjectOfType<AudioManager>();
                        AM.Play("OverDriveBlast");
                    }


                    speed = 0.0005f;
                }
                transform.localScale += scaleChange;
            }

            timestamp = Time.time + speed;
            speed = 0.05f;
        }
        if (T.localScale.x >= 4 && Time.time > timestamp + 0.001f)
        {
            anim.speed = 0;
            Color tmp = SR.color;
            tmp.a = tmp.a - 0.01f;
            SR.color = tmp;
            timestamp = Time.time + 0.001f;
        }
        if (SR.color.a <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        if (isPlayer && collision.gameObject.tag == "Enemy" && collision.isTrigger)
        {

            if (Time.time > timeStampDamage)
            {
                collision.GetComponentInParent<EnemyScr>().currentHP -= (int)damage;
                timeStampDamage = Time.time + 0.1f;
            }
        }
        else if (!isPlayer && collision.gameObject.tag == "Player" && collision.isTrigger)
        {
            if (collision.gameObject.layer == 15)
            {
                if (Time.time > timeStampDamage)
                {
                    collision.GetComponentInParent<EnemyScr>().currentHP -= (int)damage;
                    timeStampDamage = Time.time + 0.1f;
                }

            }
            else
            {
                if (Time.time > timeStampDamage)
                {
                    collision.GetComponentInParent<PlayerScr>().currentHP -= (int)damage;
                    timeStampDamage = Time.time + 0.1f;
                }
                //   Debug.Log(collision.gameObject.layer);

            }

        }


    }
}


