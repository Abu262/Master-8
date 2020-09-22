using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerScr : MonoBehaviour
{
    public EnemyScr ES;
    public bool active = true;
    LegClass LC;
    HeadClass HC;
    TorsoClass TC;
    WeaponClass WrC;
    WeaponClass WlC;
    public Animator Anim;

    public int currentHP;
    public int maxHP;
    int maxEnergy;
    public int currentEnergy;
    bool isBoosting;
    float timeStampDeplete = 0.0f;
    float timeStampCharge = 0.0f;

    public GameManager GM;
    public AudioManager AM;
    public Camera C;
    public SpriteRenderer SRLegs;
    public SpriteRenderer SRHead;
    public SpriteRenderer SRWeaponL;
    public SpriteRenderer SRWeaponR;
    public SpriteRenderer SRTorso;


    
    public Rigidbody2D rb;
    public GameObject legsChildren;
    public ParticleSystem Boosters;
    public ParticleSystem overBoosters;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI enemyhealthText;
    public TextMeshProUGUI energyText;

    bool overheating;

    public GameObject deathSpark;
    public bool dead = false;
    protected bool createdSpark = false;
    // Start is called before the first frame update
    void Start()
    {
        C = FindObjectOfType<Camera>();
        AM = FindObjectOfType<AudioManager>();
        GM = FindObjectOfType<GameManager>();
        //GM = GameObject.FindGameObjectWithTag("GameManager");
        LC = GM.LegList[GM.legsID];
        HC = GM.HeadList[GM.headID];
        TC = GM.TorsoList[GM.torsoID];
        WrC = GM.WeaponRList[GM.gunRID];
        WlC = GM.WeaponLList[GM.gunLID];

        SRLegs.sprite = LC.part;
        SRLegs.material = LC.Emitter;
        SRHead.sprite = HC.part;
        SRHead.material = HC.Emitter;
        SRTorso.sprite = TC.part;
        SRTorso.material = TC.Emitter;
        SRWeaponR.sprite = WrC.part;
        SRWeaponR.material = WrC.Emitter;
        SRWeaponL.sprite = WlC.part;
        SRWeaponL.material = WlC.Emitter;
        Anim = legsChildren.GetComponent<Animator>();
        Anim.SetInteger("ArmorID", GM.legsID);
        SRLegs.sprite = LC.part;
        currentHP = HC.hp + TC.hp + LC.hp;
        maxHP = HC.hp + TC.hp + LC.hp;
        maxEnergy = TC.energy;
        currentEnergy = maxEnergy;
        C.orthographicSize = 6;
        if (Boosters.isPlaying)
        {
            Boosters.Stop();
        }
        if (overBoosters.isPlaying)
        {
            overBoosters.Stop();
        }
        AM.Play("Start1");
        AM.Play("Start2");
        AM.Play("Start3");
        AM.Play("Start4");
        AM.Play("Start5");
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {


            if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
            {
                if (C.orthographicSize - Input.GetAxis("Mouse ScrollWheel") >= 6 && C.orthographicSize - Input.GetAxis("Mouse ScrollWheel") <= HC.radar)
                {
                    C.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");

                }
            }
            if (overheating)
            {
                energyText.text = "HEAT";
            }
            else
            {
                energyText.text = currentEnergy.ToString();
            }
            if (currentHP > 0)
            {
                healthText.text = currentHP.ToString();
            }
            else
            {
                healthText.text = "0";

            }

            if (ES.currentHP > 0)
            {
                enemyhealthText.text = "Guardian AP: " + ES.currentHP.ToString();
            }
            else
            {
                enemyhealthText.text = "Guardian AP: 0";

            }

            //energyText.text = currentEnergy.ToString();
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            if (!dead)
            {
                if (movement != Vector2.zero)
                {
                    Quaternion newRot = Quaternion.LookRotation(Vector3.forward, movement);
                    legsChildren.transform.rotation = newRot;
                    //Debug.Log(legsChildren.transform.localRotation.eulerAngles.z);
                    if (legsChildren.transform.localRotation.eulerAngles.z > 90 && legsChildren.transform.localRotation.eulerAngles.z < 270)
                    {
                        //    newRot = Quaternion.Inverse(newRot);
                        //    //Vector3 rot = legsChildren.transform.localRotation.eulerAngles;
                        //    //rot = new Vector3(newRot.x, newRot.y, newRot.z - 180);
                        legsChildren.transform.localScale = Vector3.down + Vector3.right + Vector3.forward;
                        //    ////rot = new Vector3(rot.x, rot.y, Mathf.Clamp(rot.z, legsChildren.transform.rotation.eulerAngles.z - 90, legsChildren.transform.rotation.eulerAngles.z + 90));
                        //    //newRot = Quaternion.Euler(rot);
                        //legsChildren.transform.rotation = rot180degrees;
                    }
                    else
                    {
                        legsChildren.transform.localScale = Vector3.up + Vector3.right + Vector3.forward;
                    }
                }
                else
                {

                    legsChildren.transform.rotation = transform.rotation;
                }
            }
        }

    }

    void FixedUpdate()
    {

        if (active)
        {

            if (currentHP <= 0)
            {
                currentHP = 0;
                if (GM.lockHP == false)
                {
                    dead = true;
                }

            }

            if (!dead)
            {
                if (HC.overboost == true && Time.time > timeStampDeplete && currentEnergy > LC.consumptionRate)
                {
                    overBoosters.Play();
                    if (!AM.Playing("overBoosters"))
                    {
                        AM.Play("overBoosters");
                    }
                    if (AM.Playing("Boosters"))
                    {
                        AM.Stop("Boosters");
                    }
                    if (Boosters.isPlaying)
                    {
                        Boosters.Stop();
                    }
                    timeStampDeplete = Time.time + LC.consumptionRate;
                    currentEnergy -= 100;
                }
                else if (isBoosting == true && Time.time > timeStampDeplete && currentEnergy > LC.consumptionRate)
                {
                    Boosters.Play();
                    if (!AM.Playing("Boosters"))
                    {
                        AM.Play("Boosters");
                    }
                    if (AM.Playing("overBoosters"))
                    {
                        AM.Stop("overBoosters");
                    }
                    if (overBoosters.isPlaying)
                    {
                        overBoosters.Stop();
                    }
                    timeStampDeplete = Time.time + LC.consumptionRate;
                    currentEnergy -= 10;

                }


                else if (HC.overboost == false && isBoosting == false && Time.time > timeStampCharge && currentEnergy < maxEnergy)
                {
                    if (Boosters.isPlaying)
                    {
                        Boosters.Stop();
                    }
                    if (overBoosters.isPlaying)
                    {
                        overBoosters.Stop();
                    }
                    if (AM.Playing("Boosters"))
                    {
                        AM.Stop("Boosters");
                    }
                    if (AM.Playing("overBoosters"))
                    {
                        AM.Stop("overBoosters");
                    }
                    currentEnergy += 10;

                    timeStampCharge = Time.time + TC.chargeRate;
                }

                if (currentEnergy <= LC.consumptionRate)
                {
                    overheating = true;
                }
                else if (currentEnergy >= maxEnergy / 4)
                {
                    overheating = false;
                }
                //boosters and movement
                if (Input.GetKey(KeyCode.Space) && currentEnergy > LC.consumptionRate && overheating == false)
                {
                    isBoosting = true;
                    rb.MovePosition(rb.position + movement * LC.boosters * Time.fixedDeltaTime);
                    //Debug.Log("Space");
                    //Anim.SetInteger("ArmorSet", -1);
                    SRLegs.sprite = LC.part;
                    Anim.speed = 0;
                }
                else if (HC.type == "boost" && Input.GetKey(KeyCode.LeftShift) && currentEnergy > LC.consumptionRate && overheating == false)
                {
                    HC.overboost = true;
                    rb.MovePosition(rb.position + movement * LC.boosters * 3 * Time.fixedDeltaTime);
                    //Debug.Log("Space");
                    //Anim.SetInteger("ArmorSet", -1);
                    SRLegs.sprite = LC.part;
                    Anim.speed = 0;
                }
                else
                {
                    isBoosting = false;
                    HC.overboost = false;
                    rb.MovePosition(rb.position + movement * LC.walkSpd * Time.fixedDeltaTime);

                    if (Anim.GetInteger("ArmorID") < 0)
                    {
                        Anim.SetInteger("ArmorID", GM.legsID);

                    }
                    if (movement != Vector2.zero)
                    {
                        Anim.speed = 1;
                    }
                    else
                    {
                        Anim.speed = 0;
                    }

                }
                Vector2 lookDir = mousePos - rb.position;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
            }
            else
            {
                rb.velocity = Vector2.zero;
                if (Boosters.isPlaying)
                {
                    Boosters.Stop();
                }
                Anim.speed = 0;
                movement = Vector2.zero;
            }

            if (dead == true && createdSpark == false )
            {
                createdSpark = true;
                Vector3 deathPos = this.gameObject.transform.position;
                GameObject E = Instantiate(deathSpark, deathPos, Quaternion.identity);
                E.transform.parent = gameObject.transform;
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {

        yield return new WaitForSeconds(5f);
        AM.StopAll();
        SceneManager.LoadScene(5);
        yield return null;
    }
}
