using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleHoming : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 350f;
    [SerializeField] float RotateSpeed = 4000f;
    Rigidbody2D rb;
    public Transform target;
    public bool isPlayer;
    AudioManager AM;
    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        if (isPlayer == true)
        {

            target = GameObject.FindWithTag("Enemy").GetComponent<Transform>();
            AM = FindObjectOfType<AudioManager>();
        }
        else
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            AM = FindObjectOfType<AudioManager>();
        }
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
//        Debug.Log(target.position);
        rb.velocity = transform.up * MoveSpeed * Time.deltaTime;

        Vector3 targetVector = target.position - transform.position;
  //      Debug.Log(targetVector);
        float rotatingIndex = Vector3.Cross(targetVector, transform.up).z;

        rb.angularVelocity = -1 * rotatingIndex * RotateSpeed * Time.deltaTime;
    }
}
