using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsong : MonoBehaviour
{
    public AudioManager AM;
    // Start is called before the first frame update
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
        if (!AM.Playing("MenuSong"))
        {
            AM.Play("MenuSong");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
