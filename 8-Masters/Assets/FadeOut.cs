using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer SR;
    float timestamp = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Created");
        if (Time.time > timestamp + 0.001f)
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
}
