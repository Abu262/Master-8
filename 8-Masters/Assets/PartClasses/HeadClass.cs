using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeadClass : MonoBehaviour
{
    public Material Emitter;
    public string partName;
    public string type;
    public int ID;
    public Sprite part;
    public int weight;
    public int hp;
    public int radar;
    public float cooldown;
    public float damage;
    public int cost;
    public GameObject Override;
    public bool overboost = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Special(Transform pos, bool isPlayer)
    {
  


    }
}
