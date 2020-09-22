using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSelf : MonoBehaviour
{
    public GameManager GM;
    public GameObject Self;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        if (GM.slainEnemies < 8)
        {
            Self.SetActive(false);// = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
