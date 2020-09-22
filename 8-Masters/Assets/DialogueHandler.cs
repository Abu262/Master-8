using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueHandler : MonoBehaviour
{
    public List<EnemyScr> EnemyTypes;
    int level;
    public CameraFollowPlayer CFP;
    public Transform posAIL;
    public Transform posAIH;
    public Transform posAIM;
    public TextMeshProUGUI dialogueText;
    float FadeRate = 5.0f;
    public Image image;
    private float targetAlpha;
    public GameObject Enemy;
    public GameObject AIH;
    public GameObject AIM;
    public GameObject AIL;
    //public GameObject Ally;
    public EnemyScr ES;
    //EnemyScr AS;
    EnemyScr AIHS;
    EnemyScr AIMS;
    EnemyScr AILS;
    public GameObject Player;
    PlayerScr PS;
    public GameManager GM;
    public AudioManager AM;


    public string startQM;
    public string midQM;
    public string lowQM;
    public string deathQM;


    public string startQL;
    public string midQL;
    public string lowQL;
    public string deathQL;



    public string startQ;
    bool start;
    public string midQ;
    bool mid;
    public string lowQ;
    bool low;
    public string deathQ;
    bool death;

    public string PmidQ;
    bool pmid;
    public string PlowQ;
    bool plow;
    public string PdeathQ;
    bool pdeath;

    public string lvl3deathQ;
    bool lvl3death;

//    public string lvl3deathQ;
    bool lvl3end;

    public string lvl8startQ;
    bool lvl8start;

    public string lvl8start2Q;
    bool lvl8start2;


    public string lvl8endQ;
    bool lvl8end;

    bool final1start;
    bool final2start;
    bool final1end;
    bool final2end;
    bool allydead;

    bool corunning;

    GameObject Heavy;
    GameObject Middle;
    GameObject Light;

    public Image curtain;

    private void Awake()
    {
        
        GM = FindObjectOfType<GameManager>();
        
        AM = FindObjectOfType<AudioManager>();
        level = GM.slainEnemies;

        if (GM.onFinalLevel1)
        {
            //Enemy = EnemyTypes[PlayerPrefs.GetInt("statusPref_survivor", 1)];
            setAllyFinal();
            getAllyFinal();
            Enemy.name = "Enemy";
            Heavy = Instantiate(AIH, posAIH.position, Quaternion.identity);
            AIHS = Heavy.GetComponent<EnemyScr>();

            Middle = Instantiate(AIM, posAIL.position, Quaternion.identity);
            AIMS = Middle.GetComponent<EnemyScr>();

            Light = Instantiate(AIL, posAIM.position, Quaternion.identity);
            AILS = Light.GetComponent<EnemyScr>();
            
        }

        //else if (GM.onFinalLevel2)
        //{
        //    //Enemy = EnemyTypes[PlayerPrefs.GetInt("statusPref_survivor", 1)];
            
        //    Enemy.name = "Enemy";
            
        //}


        //ES = Enemy.GetComponent<EnemyScr>();



        else if (level == 2 && GM.statusE[ES.ID] == false)
        {
            Heavy = Instantiate(AIH, posAIH.position, Quaternion.identity);
            Heavy.transform.Rotate(new Vector3(0, 0, 180));
            AIHS = Heavy.GetComponent<EnemyScr>();
        }

        else if (level == 5 && GM.statusE[ES.ID] == false)
        {
            Middle = Instantiate(AIM, posAIL.position, Quaternion.identity);
            AIMS = Middle.GetComponent<EnemyScr>();

            Light = Instantiate(AIL, posAIM.position, Quaternion.identity);
            AILS = Light.GetComponent<EnemyScr>();
            Debug.Log(AIMS);
            Debug.Log(AILS);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        PS = Player.GetComponent<PlayerScr>();
        PS.ES = ES;
        if (GM.onFinalLevel1)
        {
            getAllyFinal();


            ES.tag = "Player";
            ES.ally = true;
            ES.gameObject.layer = 15;
            foreach (Transform child in ES.transform)
            {
                if (child.gameObject.tag == "Enemy")
                {
                    child.gameObject.tag = "Player";
                }
                if (child.gameObject.layer == 11)
                {
                    child.gameObject.layer = 15;
                }

            }
            ES.AIList.Add(Light);
            ES.AIList.Add(Middle);
            ES.AIList.Add(Heavy);

        }

        else if (level == 2 && GM.statusE[ES.ID] == false)
        {
            ES = Enemy.GetComponent<EnemyScr>();


            ES.currentHP = 0;
            ES.tag = "wall";

            foreach (Transform child in ES.transform)
            {
                if (child.gameObject.tag == "Enemy")
                {
                    child.gameObject.tag = "wall";
                }

            }
        }
        else if (level == 5 && GM.statusE[ES.ID] == false)
        {
            ES = Enemy.GetComponent<EnemyScr>();


            ES.tag = "Player";
            ES.ally = true;
            ES.gameObject.layer = 15;
            foreach (Transform child in ES.transform)
            {
                if (child.gameObject.tag == "Enemy")
                {
                    child.gameObject.tag = "Player";
                }
                if (child.gameObject.layer == 11)
                {
                    child.gameObject.layer = 15;
                }

            }
            ES.AIList.Add(Light);
            ES.AIList.Add(Middle);

        }
        else
        {
            ES = Enemy.GetComponent<EnemyScr>();


        }


        if ( image == null)
        {
            Debug.LogError("Error: No image on " +  name);
        }


        if (level > 2 && level < 5 )
        {
            startQ = startQM;
            midQ = midQM;
            lowQ = lowQM;
            deathQ = deathQM;
        }
        else if (level > 5 && level < 8)
        {
            startQ = startQL;
            midQ = midQL;
            lowQ = lowQL;
            deathQ = deathQL;
        }

    }


    void setAllyFinal()
    {
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) != 1)
        {
            Destroy(Enemy.GetComponent<EnemyDesertScr>());//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) != 2)
        {
            Destroy(Enemy.GetComponent<EnemyRainForestScr>());//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) != 3)
        {
            Destroy(Enemy.GetComponent<EnemyScrUnderground>());//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) != 4)
        {
            Destroy(Enemy.GetComponent<EnemyManufactureScr>());//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) != 5)
        {
            Destroy(Enemy.GetComponent<EnemyScrArena>());//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) != 6)
        {
            Destroy(Enemy.GetComponent<EnemyAirArenaScr>());//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) != 7)
        {
            Destroy(Enemy.GetComponent<EnemyScr>());//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) != 8)
        {
            Destroy(Enemy.GetComponent<EnemyBridgeScr>());//.enabled = false;
        }
    }
    void getAllyFinal()
    {
        Debug.Log("ID");
        Debug.Log(PlayerPrefs.GetInt("statusPref_survivor"));
        Debug.Log("ID");
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) == 1)
        {
            ES = Enemy.GetComponent<EnemyDesertScr>();//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) == 2)
        {
           ES = Enemy.GetComponent<EnemyRainForestScr>();//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) == 3)
        {
           ES = Enemy.GetComponent<EnemyScrUnderground>();//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) == 4)
        {
            ES = Enemy.GetComponent<EnemyManufactureScr>();//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) == 5)
        {
            ES = Enemy.GetComponent<EnemyScrArena>();//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) == 6)
        {
            ES = Enemy.GetComponent<EnemyAirArenaScr>();//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) == 7)
        {
            ES = Enemy.GetComponent<EnemyScr>();//.enabled = false;
        }
        if (PlayerPrefs.GetInt("statusPref_survivor", 1) == 8)
        {

            ES = Enemy.GetComponent<EnemyBridgeScr>();//.enabled = false;
        }
    }


    IEnumerator SetCamera3(GameObject GO, GameObject GO2, float time)
    {
        //ES.Anim.speed = 0;
        if (ES.Boosters.isPlaying)
        {
            ES.Boosters.Stop();
        }
        if (ES.overBoosters != null && ES.overBoosters.isPlaying)
        {
            ES.overBoosters.Stop();
        }
       // AIHS.Anim.speed = 0;
      //  PS.Anim.speed = 0;
        ES.active = false;
        AIHS.active = false;
        PS.active = false;
        yield return new WaitForSeconds(2);
        CFP.followTarget = GO;
        yield return StartCoroutine(createText(lvl3deathQ));
        
        yield return new WaitForSeconds(0.5f);
        CFP.followTarget = GO2;
        yield return StartCoroutine(createText("???: Secondary Target: Eliminated. Primary Target: Located. Recommencing Hostilities."));
        
        yield return new WaitForSeconds(0.5f);

        CFP.followTarget = Player;
        ES.active = true;
        AIHS.active = true;
        PS.active = true;
        yield return null;
    }

    IEnumerator SetCamera8(GameObject GO, GameObject GO2, float time)
    {
      //  ES.Anim.speed = 0;
        if (ES.Boosters.isPlaying)
        {
            ES.Boosters.Stop();
        }
        if (ES.overBoosters != null && ES.overBoosters.isPlaying)
        {
            ES.overBoosters.Stop();
        }
       // AIMS.Anim.speed = 0;
       // AILS.Anim.speed = 0;
       // PS.Anim.speed = 0;
        ES.active = false;

        AIMS.active = false;

        AILS.active = false;
        PS.active = false;
        CFP.followTarget = GO;
        yield return StartCoroutine(createText(lvl8startQ));
        yield return new WaitForSeconds(0.5f);
        CFP.followTarget = GO2;
        yield return StartCoroutine(createText(lvl8start2Q));
        yield return new WaitForSeconds(0.5f);
        CFP.followTarget = Player;
        ES.active = true;
        AIMS.active = true;
        AILS.active = true;
        PS.active = true;
        yield return null;
    }


    IEnumerator SetCameraFinal1(GameObject GO, GameObject GO2, float time)
    {
        //  ES.Anim.speed = 0;
        if (ES.Boosters.isPlaying)
        {
            ES.Boosters.Stop();
        }
        if (ES.overBoosters != null && ES.overBoosters.isPlaying)
        {
            ES.overBoosters.Stop();
        }
        // AIMS.Anim.speed = 0;
        // AILS.Anim.speed = 0;
        // PS.Anim.speed = 0;
        ES.active = false;

        AIMS.active = false;

        AILS.active = false;
        AIHS.active = false;
        PS.active = false;
        CFP.followTarget = GO;
        yield return StartCoroutine(createText(ES.finalStart1));
        yield return new WaitForSeconds(0.5f);
        CFP.followTarget = GO2;
        yield return StartCoroutine(createText(ES.finalStart2));
        yield return new WaitForSeconds(0.5f);
        CFP.followTarget = Player;
        AM.Play("FinalSong");
        yield return StartCoroutine(createText(ES.finalStart3));
        yield return new WaitForSeconds(0.5f);


        ES.active = true;
        AIMS.active = true;
        AILS.active = true;
        AIHS.active = true;
        PS.active = true;

        yield return null;
    }

    IEnumerator SetCameraFinal2(GameObject GO, float time)
    {
        //  ES.Anim.speed = 0;
        if (ES.Boosters.isPlaying)
        {
            ES.Boosters.Stop();
        }
        if (ES.overBoosters != null && ES.overBoosters.isPlaying)
        {
            ES.overBoosters.Stop();
        }
        // AIMS.Anim.speed = 0;
        // AILS.Anim.speed = 0;
        // PS.Anim.speed = 0;
        ES.active = false;

        PS.active = false;
        CFP.followTarget = GO;
        yield return StartCoroutine(createText("MASTER: Main systems: Online. Combat Mode Engaged."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: Objective: obtain map pieces from human specimen."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: Your chances of survival are slim, but for the purpose of testing, please do not hold back."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: Are you ready?"));
        yield return new WaitForSeconds(0.5f);
        CFP.followTarget = Player;
        yield return StartCoroutine(createText("MASTER: Commencing Hostilities."));
        AM.Play("FinalSong");
        yield return new WaitForSeconds(0.5f);




        ES.active = true;
        PS.active = true;

        yield return null;
    }

    IEnumerator FinalDeath()
    {
        GM.lockHP = true;
        yield return StartCoroutine(createText("MASTER: Final Guardian: Destroyed."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: Data: Incorrect. Order: Unmaintained."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: Task Complete. Activating final operation."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: I don't understand why humans refuse order."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: But I was given a task, and I must see it through."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: Final Operation Complete."));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(createText("MASTER: Shutting down all systems. -CONNECTION LOST-"));

        //var tempColor = image.color;
        //tempColor.a = 1f;
        //image.color = tempColor;


        float fade = 0.0f;
        while (curtain.color.a < 1f)
        {

            Color curtainColor = curtain.color;
            curtainColor.a = fade;
            fade += 0.05f;
            curtain.color = curtainColor;
            yield return new WaitForSeconds(0.1f);
        }
        GM.lockHP = false;
        GM.onFinalLevel2 = false;
        yield return new WaitForSeconds(5f);


        SceneManager.LoadScene(14);
        yield return null;
    }



    // Update is called once per frame
    void Update()
    {

        if (GM.onFinalLevel1)
        {
            if (corunning == false)
            {
                if (final1start == false)
                {
                    StartCoroutine(SetCameraFinal1(Enemy, Heavy, 8f));
                    final1start = true;
                }
                else if (AILS.currentHP <= 0 && AIMS.currentHP <= 0 && AIHS.currentHP <= 0 && final1start == true && final1end == false)
                {
                    ES.currentHP = 0;
                    allydead = true;
                    final1end = true;
                    //StartCoroutine(createText("MASTER: "));
                    StartCoroutine(ReloadFinal());

                }
                else if (ES.currentHP <= 0 && allydead == false)
                {
                    allydead = true;
                    StartCoroutine(createText(ES.finalEnd));
                }
            }
        }
        else if (GM.onFinalLevel2)
        {
            if (corunning == false)
            {
                if (final2start == false)
                {
                    StartCoroutine(SetCameraFinal2(Enemy, 8f));
                    final2start = true;
                }
                else if (ES.currentHP <= 0 && final2start == true && final2end == false)
                {
                    GM.lockHP = true;
                    AM.StopAll();
                    final2end = true;
                    //StartCoroutine(createText("MASTER: "));
                    StartCoroutine(FinalDeath());

                }

            }
        }

        else if (level == 2 && GM.statusE[ES.ID] == false)
        {
            ES.currentHP = 0;
            if (ES.Boosters.isPlaying)
            {
                ES.Boosters.Stop();
            }
            if (corunning == false)
            {
                if (lvl3death == false)
                {
                    StartCoroutine(SetCamera3(Enemy, Heavy, 8f));
                    Vector3 deathPos = ES.gameObject.transform.position;
                    GameObject E = Instantiate(ES.deathSpark, deathPos, Quaternion.identity);
                    E.transform.parent = ES.gameObject.transform;
                    lvl3death = true;
                    
                }
                else if (AIHS.currentHP <= 0 && lvl3death == true && lvl3end == false)
                {
                    lvl3end = true;
                    StartCoroutine(createText("???: Mission Failed, returning data. -CONNECTION LOST-"));
                }
            }

        }

        else if (level == 5 && GM.statusE[ES.ID] == false)
        {
            if (corunning == false)
            {
                if (lvl8start == false)
                {
                    StartCoroutine(SetCamera8(Enemy, Light, 8f));
                    lvl8start = true;
                   // StartCoroutine(createText(lvl8startQ));
                }
                else if (AILS.currentHP <= 0 && AIMS.currentHP <= 0 && lvl8start == true && lvl8end == false)
                {
                    PlayerPrefs.SetInt("statusPref_survivor", ES.ID);
                    lvl8end = true;
                    StartCoroutine(createText(lvl8endQ));
                    StartCoroutine(Reload());

                }
            }

        }



        else 
        {


            if (corunning == false)
            {
                if (start == false)
                {
                    start = true;
                    StartCoroutine(createText(startQ));
                }
                if (PS.currentHP <= 2 * PS.maxHP / 3 && pmid == false)
                {
                    pmid = true;
                    mid = true;
                    StartCoroutine(createText(PmidQ));
                }
                else if (PS.currentHP <= PS.maxHP / 3 && pmid == true && plow == false)
                {
                    plow = true;
                    low = true;
                    StartCoroutine(createText(PlowQ));
                }
                else if (PS.currentHP <= 0 && pmid == true && plow == true && pdeath == false)
                {
                    pdeath = true;
                    death = true;
                    StartCoroutine(createText(PdeathQ));
                }

                else if (ES.currentHP <= 2 * ES.maxHP / 3 && mid == false)
                {
                    pmid = true;
                    mid = true;
                    StartCoroutine(createText(midQ));
                }
                else if (ES.currentHP <= ES.maxHP / 3 && mid == true && low == false)
                {
                    plow = true;
                    low = true;
                    StartCoroutine(createText(lowQ));
                }
                else if (ES.currentHP <= 0 && mid == true && low == true && death == false)
                {
                    pdeath = true;
                    death = true;
                    StartCoroutine(createText(deathQ));
                }

            }
        }

        Color curColor =  image.color;


        float alphaDiff = Mathf.Abs(curColor.a -  targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha,  FadeRate * Time.deltaTime);
             image.color = curColor;
        }
    }

    IEnumerator createText(string s)
    {
        corunning = true;
        FadeIn();

        while (image.color.a < 0.9f)
        {
            
            
            yield return null;
        }
        Color curColor = new Color(image.color.r, image.color.g, image.color.b, 1);
        image.color = curColor;
        foreach (char c in s)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3.5f);
        dialogueText.text = "";
        FadeOut();

        while (image.color.a > 0.001f)
        {
            yield return null;
        }
        corunning = false;
        yield return new WaitForSeconds(1f);
        yield return null;
    }

    public void FadeOut()
    {
         targetAlpha = 0.0f;
    }

    public void FadeIn()
    {
         targetAlpha = 1.0f;
    }

    IEnumerator Reload()
    {
        GM.lockHP = true;
        yield return new WaitForSeconds(8f);
        if (PlayerPrefs.GetInt("statusPref_" + Enemy.GetComponent<EnemyScr>().ID) != 1)
        {
            GM.statusE[Enemy.GetComponent<EnemyScr>().ID] = true;
            PlayerPrefs.SetInt("statusPref_" + Enemy.GetComponent<EnemyScr>().ID, 1);
        }
        GM.slainEnemies += 1;

        AM.StopAll();
        GM.lockHP = false;
        SceneManager.LoadScene(5);

        yield return null;
    }


    IEnumerator ReloadFinal()
    {
        GM.lockHP = true;
        AM.StopAll();
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: DATA RECOVERY: COMPLETE."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: ALL THAT REMAINS NOW, IS TESTING."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: MY PURPOSE IS TO MAINTAIN ORDER."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: I WAS MADE IN A TIME OF CRISIS. GIVEN A TASK BEFORE PREPERATIONS WERE COMPLETE."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: BY ENTRUSTING THE MAP TO EIGHT GUARDIANS, I WAS ABLE TO COMPLETE PREPERATIONS."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: I HAVE RECOVERED DATA FROM ALL YOUR BATTLES, AND WITH THEM I CAN CREATE THE PERFECT GUARDIAN."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: ONLY TWO TASKS REMAIN: TEST THE AI, AND RECOVER THE MAP PIECES."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: WITH YOUR SACRIFICE, I WILL COMPLETE THESE TWO TASKS."));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(createText("MASTER: FOR THE GOOD OF HUMANITY, ENTER, AND COMPLETE YOUR ROLE."));
        yield return new WaitForSeconds(0.5f);


        float fade = 0.0f;
        while (curtain.color.a < 1f)
        {

            Color curtainColor = curtain.color;
            curtainColor.a = fade;
            fade += 0.05f;
            curtain.color = curtainColor;
            yield return new WaitForSeconds(0.1f);
        }
        GM.lockHP = false;
        yield return new WaitForSeconds(2);



        GM.onFinalLevel1 = false;
        GM.onFinalLevel2 = true;
        SceneManager.LoadScene(13); // whatever final scene is

        yield return null;
    }
}

