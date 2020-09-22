using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDestroy : MonoBehaviour
{
    public GameObject EB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDestroy()
    {

        GameObject E = Instantiate(EB, gameObject.transform);
    }
}
