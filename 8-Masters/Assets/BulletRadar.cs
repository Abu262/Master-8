using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRadar : MonoBehaviour
{

    public Vector3 Location;
    public bool near;
    int mask = (1 << 8);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MachineBullet>() != null)
        {
            if (collision.gameObject.layer == 8 && collision.GetComponent<MachineBullet>().isPlayer)
            {

                near = true;
                Location = collision.gameObject.transform.position;
            }
        }
        else if (collision.gameObject.GetComponent<OverrideAtk>() != null)
        {
            if (collision.gameObject.layer == 8 && collision.GetComponent<OverrideAtk>().isPlayer)
            {

                near = true;
                Location = collision.gameObject.transform.position;
            }
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<MachineBullet>() != null)
        {
            if (collision.gameObject.layer == 8 && collision.GetComponent<MachineBullet>().isPlayer)
            {
                near = false;
            }
        }
        else if (collision.gameObject.GetComponent<OverrideAtk>() != null)
        {
            if (collision.gameObject.layer == 8 && collision.GetComponent<OverrideAtk>().isPlayer)
            {
                near = false;
            }
        }


    }
}
