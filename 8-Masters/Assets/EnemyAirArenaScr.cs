using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class EnemyAirArenaScr : EnemyScr
{




    public List<Transform> movePoints;





    bool misslesArmed;
    bool misslesLoading;
    bool inRifleRange;



    private void Awake()
    {
        AM = FindObjectOfType<AudioManager>();
        GM = FindObjectOfType<GameManager>();
        if (AM.Playing("MenuSong"))
        {
            AM.Stop("MenuSong");
        }
        if (!(GM.slainEnemies == 2 || GM.slainEnemies == 5) || GM.statusE[ID] == true)
        {
            AM.Play("AirArenaSong");
        }
        if (Boosters.isPlaying)
        {
            Boosters.Stop();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ID = 6;
        Hit.enabled = false;
        HitImage.enabled = false;
        seeker = GetComponent<Seeker>();
        AM = FindObjectOfType<AudioManager>();
        GM = FindObjectOfType<GameManager>();
        //GM = GameObject.FindGameObjectWithTag("GameManager");
        LC = GM.LegList[6];
        HC = GM.HeadList[6];
        TC = GM.TorsoList[6];
        WrC = GM.WeaponRList[6];
        WlC = GM.WeaponLList[6];

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
        Anim.SetInteger("ArmorID", 6);
        SRLegs.sprite = LC.part;
        Anim.speed = 0;
        currentHP = HC.hp + TC.hp + LC.hp;
        maxHP = HC.hp + TC.hp + LC.hp;
        maxEnergy = TC.energy;
        currentEnergy = maxEnergy;
        currentAmmoL = WlC.ammo;
        currentAmmoR = WrC.ammo;
        BarrelL.position = new Vector2(BarrelL.position.x, BarrelL.position.y + WlC.barrelLength);
        BarrelR.position = new Vector2(BarrelR.position.x, BarrelR.position.y + WrC.barrelLength);

        if (AM.Playing("MenuSong"))
        {
            AM.Stop("MenuSong");
        }
        //AM.Play("AirArenaSong");
        if (Boosters.isPlaying)
        {
            Boosters.Stop();
        }
        int nextSpot = Random.Range(0, movePoints.Count);
        seeker.StartPath(rb.position, movePoints[nextSpot].position, OnPathComplete);
        InvokeRepeating("UpdatePath", 0f, 0.5f);

    }

    void UpdatePath()
    {
        if (gameObject.tag == "Player")
        {
            //float distance1 = Vector3.Distance(transform.position, AI1.transform.position);
            //float distance2 = Vector3.Distance(transform.position, AI2.transform.position);

            //if (AI1.GetComponent<EnemyScr>().currentHP <= 0)
            //{
            //    Player = AI2;
            //}
            //else if (AI2.GetComponent<EnemyScr>().currentHP <= 0)
            //{
            //    Player = AI1;
            //}
            //else if (distance1 < distance2)
            //{
            //    Player = AI1;
            //}
            //else
            //{
            //    Player = AI2;
            //}
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (GameObject t in AIList)
            {
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (t.GetComponent<EnemyScr>().currentHP > 0 && dist < minDist)
                {
                    Player = t;
                    minDist = dist;
                }
            }
        }
        if (reachedEndOfPath)
        {
            Debug.Log("done");
            int nextSpot = Random.Range(0, movePoints.Count);
            seeker.StartPath(rb.position, movePoints[nextSpot].position, OnPathComplete);
        }

    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Turn()
    {
        int R = Random.Range(0, 2);
        if (R == 0)
        {
            Left = true;
            Right = false;
        }
        else
        {
            Right = true;
            Left = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (active)
        {

            if (struck == true)
            {
                struck = false;
                StartCoroutine(showHit());
            }
            //if (sideL.hittingWall && !sideR.hittingWall)
            //{
            //    Left = false;
            //    Right = true;
            //}
            //else if (sideR.hittingWall && !sideL.hittingWall)
            //{
            //    Left = true;
            //    Right = false;
            //}
            //else if (sideR.hittingWall && sideL.hittingWall)
            //{
            //    Right = false;
            //    Left = false;
            //}

            if (currentAmmoL >= 4)
            {
                misslesArmed = true;
                misslesLoading = false;
            }
            else if (currentAmmoL <= 0)
            {
                misslesArmed = false;
                misslesLoading = true;
            }

            //Armor 8 AI

            //if player not in radar range or IS in range
            //walk towards player


            //if player in viewing range
            //boost towards them
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (!dead)
            {
                isBoosting = true;
                if (distance <= HC.radar)
                {

                    inRifleRange = true;

                    //Left = false;
                    //Right = false;
                }
                else
                {
                    inRifleRange = false;
                    //isBoosting = false;
                }
                /*else if (distance > shotgunRange)
                {
                    isBoosting = true;
                    inCannonRange = true;
                    inShotGunRange = false;

                }
                else if (distance > overrideRange)
                {
                    isBoosting = true;
                    inCannonRange = true;
                    inShotGunRange = true;
                }
                else
                {
                    isBoosting = true;
                    inCannonRange = true;
                    inShotGunRange = true;
                    inOverrideRange = true;
                }*/

                if (inRifleRange && Time.time > timeStampR && currentAmmoR > 0)
                {
                    timeStampR = Time.time + WrC.fireRate;
                    currentAmmoR -= 1;
                    WrC.Atk(BarrelR, AM, ally);
                }

                if (((currentAmmoR < WrC.ammo) || currentAmmoR <= 0) && Time.time > ammoTimeStampR)
                {
                    ammoTimeStampR = Time.time + WrC.reloadRate;
                    currentAmmoR += 1;

                }

                if (misslesArmed && Time.time > timeStampL && currentAmmoL > 0)
                {
                    timeStampL = Time.time + WlC.fireRate;
                    currentAmmoL -= 1;
                    WlC.Atk(BarrelL, AM, ally);
                }

                if (((misslesLoading && currentAmmoL < WlC.ammo) || currentAmmoL <= 0) && Time.time > ammoTimeStampL)
                {

                    ammoTimeStampL = Time.time + WlC.reloadRate;
                    currentAmmoL += 1;

                }

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

                if (path == null)
                    return;
                if (currentWaypoint >= path.vectorPath.Count)
                {
                    reachedEndOfPath = true;
                    return;
                }
                else
                {
                    reachedEndOfPath = false;
                }

                //            Vector2 directoin = 
                movement = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized; //Vector3.Normalize(Player.transform.position - transform.position);

                float d = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
                if (d < nextWaypointDistance)
                {

                    currentWaypoint++;
                }
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

            //if player in shooting range
            //rotate around them and charge towards them
            //shoot the fuck out of them
            //keep a certain distance away

            //if player is really close
            //activate overdrive atk

            //if bullet is near
            //sidestep
            //if missle is near
            //sidestep and charge towards player if near

            //if energy below 20%
            //dont boost unless avoiding a projectile

            //notes: armor 8 is hyper aggressive and tanky, the strategy is to strafe and chagre until in overdrive range, this armor cares very little for their own safety





            //movement.x = Input.GetAxisRaw("Horizontal");
            //movement.y = Input.GetAxisRaw("Vertical");


        }

    }

    void FixedUpdate()
    {
       // Debug.Log(Boosters.isPlaying);
        //Debug.Log(currentHP);
        if (currentHP <= 0)
        {

            if (currentHP < 0)
            {
                currentHP = 0;
            }
            dead = true;

            if (dead == true && createdSpark == false)
            {
                createdSpark = true;
                Vector3 deathPos = this.gameObject.transform.position;
                GameObject E = Instantiate(deathSpark, deathPos, Quaternion.identity);
                E.transform.parent = gameObject.transform;
                StartCoroutine(Reload());
            }
        }



        //if (isBoosting == true && Time.time > timeStampDeplete && currentEnergy > LC.consumptionRate)
        //{
        //    if (!AM.Playing("Boosters"))
        //    {
        //        AM.Play("Boosters");
        //    }
        //    timeStampDeplete = Time.time + LC.consumptionRate;
        //    currentEnergy -= 10;

        //}
        //else if (isBoosting == false && Time.time > timeStampCharge && currentEnergy < maxEnergy)
        //{
        //    if (AM.Playing("Boosters"))
        //    {
        //        AM.Stop("Boosters");
        //    }
        //    currentEnergy += 10;

        //    timeStampCharge = Time.time + TC.chargeRate;
        //}
        ////boosters and movement
        ///
        if (!dead)
        {
            if (isBoosting)// && currentEnergy > LC.consumptionRate)
            {
                if (!Boosters.isPlaying)
                {
                    Boosters.Play();
                }

                rb.MovePosition(rb.position + movement * LC.boosters * Time.fixedDeltaTime);
       

                //Debug.Log("Space");
                //Anim.SetInteger("ArmorSet", -1);
                SRLegs.sprite = LC.part;
                Anim.speed = 0;
            }
            else
            {
                if (Boosters.isPlaying)
                {
                    Boosters.Stop();
                }


                    rb.MovePosition(rb.position + movement * LC.walkSpd * Time.fixedDeltaTime);
                

                if (Anim.GetInteger("ArmorID") < 0)
                {
                    Anim.SetInteger("ArmorID", 6);

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


            Vector2 lookDir = (Vector2)Player.transform.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }







    }

    IEnumerator Reload()
    {


        if (GM.onFinalLevel1 == false && (!(GM.slainEnemies == 2 || GM.slainEnemies == 5) || GM.statusE[ID] == true))
        {
            yield return new WaitForSeconds(5f);
            if (PlayerPrefs.GetInt("statusPref_" + ID) != 1)
            {
                if (GM.statusE[ID] == false)
                {
                    GM.slainEnemies += 1;
                }

                GM.statusE[ID] = true;

                PlayerPrefs.SetInt("statusPref_" + ID, 1);

            }
            Debug.Log(GM.slainEnemies);

            AM.StopAll();
            Debug.Log("Somehow we got here");
            SceneManager.LoadScene(5);
        }

        yield return null;
    }
    //virtual public void showHit()
    //{
    //    float timestamp = 0.0f;
    //    while (timestamp < 1.0f)
    //    {
    //        Hit.enabled = true;
    //        HitImage.enabled = true;
    //        timestamp += Time.time;
    //        //yield return null;
    //    }
    //    Hit.enabled = false;
    //    HitImage.enabled = false;
    //    //yield return null;
    //}
}
