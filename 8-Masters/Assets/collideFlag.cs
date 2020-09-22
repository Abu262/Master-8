using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideFlag : MonoBehaviour
{
    [HideInInspector]
    public bool hittingWall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "wall" || collision.tag == "Impassable")
        {
            hittingWall = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "wall" || collision.tag == "Impassable")
        {
            hittingWall = false;
        }
    }
}
