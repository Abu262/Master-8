using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponClass : MonoBehaviour
{
    public Material Emitter;
    public string partName;
    public int ID;
    public Sprite part;
    public int weight;
    public int ammo;
    public float reloadRate;
    public bool rightHand;
    public float range;
    public float barrelLength;
    public bool fire;
    public bool activated;
    public float fireRate;
    public int damage;

    //public bool isPlayer;

    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float timestamp = 0.0f;
    // Start is called before the first frame update

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Alive?");
        if (fire == true)
        {
            activated = true;
        }
        else
        {
            activated = false;
        }
    }

    public virtual void Atk(Transform barrel, AudioManager AM, bool isPlayer)
    {
        Debug.Log("Why");
        //from here we should be able to do whatever we  want with the object


    }
}
