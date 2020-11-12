using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    
    public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    bool isPaused = false;
    private CharacterController controller;
    private Vector3 forward;
    private Vector3 side;
    private Vector3 upDown;
    public float speed;
    private int lane=1;
    bool down;
    int score=0;
    int hp =3;


    //Collectible Vars
    //HP
    private int hpInterval;
    public GameObject HPprefap;
    private int lastHPTime;

    //Obstacle
    private int obstacleInterval;
    public GameObject obstaclePrefab;
    private int lastObstacleTime;

    //ScoreOrb
    private int orbInterval;
    public GameObject orbPrefab;
    private int lastOrbTime;


    // Change color
    private int colorInterval;


    //ROAD CODE
    public GameObject road;
    private int roadX = 200;
    private int roadNum = 0;
    public GameObject[] roads;

    public Text ScoreText;
    public Text HpText;

    private void Awake()
    {
        Time.timeScale = 1f;

    }
    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = 1f;
        speed=10;
        int colorRandom = Random.Range(0,3);
        this.gameObject.GetComponent<Renderer>().material.color=  new Color(colorRandom*80f/255f, 80f/255f, colorRandom*80f/255f); 

        //ROAD CODE
        for(int i =0;i<3;i++)
        {
            Instantiate(road, new Vector3(roadX, 0, (float)4.7), Quaternion.identity);
            Instantiate(road, new Vector3(roadX, 20, (float)4.7), Quaternion.identity);
            roadX+=100;
        }
        colorInterval=0;

        controller= GetComponent<CharacterController>();
        down = true;

        // Collectibles
        hpInterval=8;
        lastHPTime=0;

        lastObstacleTime=0;
        obstacleInterval= 5;

        lastOrbTime=0;
        orbInterval= 3;

    }

    // Update is called once per frame
    void Update()
    {
        //ROAD CODE

        if (this.gameObject.transform.position.x+300 > 20 + roadNum * 100)
        {
            Instantiate(road, new Vector3(roadX, 0, (float)4.7), Quaternion.identity);
            Instantiate(road, new Vector3(roadX, 20, (float)4.7), Quaternion.identity);
            roadX += 100;
            roadNum++;
        }
            if (Input.GetKeyDown(KeyCode.Space)&&Time.timeScale==1)
            {
                if(down)
                {
                    upDown.y =16;
                    controller.Move(upDown);
                }
                else{
                   upDown.y=-16;
                   controller.Move(upDown);
                }
                down=!down;
                GetComponents<AudioSource>()[5].Play();
            }
        roads = GameObject.FindGameObjectsWithTag("ROAD");
        foreach (GameObject iroad in roads)
        {
            if(iroad.gameObject.transform.position.x+100<=this.gameObject.transform.position.x)
            {
                Destroy(iroad.gameObject);
            }
        }
        GameObject[] hps = GameObject.FindGameObjectsWithTag("HP");
        foreach (GameObject ihp in hps)
        {
            if(ihp.gameObject.transform.position.x+30<=this.gameObject.transform.position.x)
            {
                Destroy(ihp.gameObject);
            }
        } 
        GameObject[] obs = GameObject.FindGameObjectsWithTag("OBSTACLE");
        foreach (GameObject iob in obs)
        {
            if(iob.gameObject.transform.position.x+30<=this.gameObject.transform.position.x)
            {
                Destroy(iob.gameObject);
            }
        } 
        GameObject[] orbs = GameObject.FindGameObjectsWithTag("ORB");
        foreach (GameObject iorb in orbs)
        {
            if(iorb.gameObject.transform.position.x+30<=this.gameObject.transform.position.x)
            {
                Destroy(iorb.gameObject);
            }
        }   
        // Setting the auto forward speed
        if(Time.timeScale==1)
        {
            forward.x=speed;
            controller.Move(forward*Time.fixedDeltaTime);
        }


        if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D))&&lane<2&&Time.timeScale==1){
            side.z=-10;
            controller.Move(side);
            lane++;

        }
        else if((Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A))&&lane>0&&Time.timeScale==1){
            side.z=10;
            controller.Move(side);
            lane--;
        }

        //Collectibles 

        //HP
        if ((int)Time.time%hpInterval ==0 &&(int)Time.time != (int)lastHPTime && (int)Time.time%obstacleInterval !=0 && (int)Time.time%orbInterval !=0 ) {
            int hpRandom = Random.Range(-1,2)*10;
            int randomY= Random.Range(0,2)*16;
            Instantiate(HPprefap, new Vector3((this.gameObject.transform.position.x)+90, 2+randomY, (float)4.7+hpRandom), Quaternion.identity);
            lastHPTime = (int)Time.time;
        }

        //Obstacle
        if ((int)Time.time%obstacleInterval ==0 &&(int)Time.time != (int)lastObstacleTime  ) {
            int randomY= Random.Range(0,2)*16;
            lastObstacleTime = (int)Time.time;
            int numOfObstacles = Random.Range(1,4);
            if(numOfObstacles==1)
            {
                int obRandom = Random.Range(-1,2)*10;
                Instantiate(obstaclePrefab, new Vector3((this.gameObject.transform.position.x)+90, 2+randomY, (float)4.7+obRandom), Quaternion.identity);
            }
            else if(numOfObstacles==2)
            {
                int obRandom = Random.Range(-1,2);
                for(int i=-1;i<2&&i!=obRandom;i++)
                {
                    Instantiate(obstaclePrefab, new Vector3((this.gameObject.transform.position.x)+90, 2+randomY, (float)4.7+i*10), Quaternion.identity);
                }

            }
            else{
                for(int i=-1;i<2;i++)
                {
                    Instantiate(obstaclePrefab, new Vector3((this.gameObject.transform.position.x)+90, 2+randomY, (float)4.7+i*10), Quaternion.identity);
                }
            }

            lastObstacleTime = (int)Time.time;
        }


        //ScoreOrb
        if ((int)Time.time%orbInterval ==0 &&(int)Time.time != (int)lastOrbTime && (int)Time.time%obstacleInterval !=0 && (int)Time.time%hpInterval !=0 ) {
            int orbRandom = Random.Range(0,3);
            int randomY= Random.Range(0,2)*16;
            var newOrb= Instantiate(orbPrefab, new Vector3((this.gameObject.transform.position.x)+90, 2+randomY, (float)4.7+orbRandom), Quaternion.identity);
            newOrb.GetComponent<Renderer>().material.color=  new Color(orbRandom*80f/255f, 80f/255f, orbRandom*80f/255f);
            lastOrbTime = (int)Time.time;
        }

        //Change Color
        if ((int)Time.time>=colorInterval+ 15) {
            Color32 colorCom = this.gameObject.GetComponent<Renderer>().material.color;
            int colorRandom = Random.Range(0,3);
            while(true) {
                if(colorRandom*80!=colorCom.r)
                {
                   this.gameObject.GetComponent<Renderer>().material.color=  new Color(colorRandom*80f/255f, 80f/255f, colorRandom*80f/255f); 
                    colorInterval = (int)Time.time;
                    break;
                }
                colorRandom = Random.Range(0,3);
            }
            GetComponents<AudioSource>()[6].Play();
        }

        //Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale!=0)

        {
            if(isPaused)
                Resume();
            else
                Pause();
        }
    }
        void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    void FixedUpdate() {
        // Setting the Forward to be called.
    }



    void OnTriggerEnter(Collider other)
    {
        //   other.attachedRigidbody.useGravity = false;
        if (other.CompareTag("OBSTACLE"))
        {
            if(hp>0)
                hp--;
            GetComponents<AudioSource>()[1].Play();
            Destroy(other.gameObject);

        }

        else if (other.CompareTag("HP"))
        {
            if(hp<3)
                hp++;
            GetComponents<AudioSource>()[2].Play();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ORB"))
        {
            Color32 colorPlayer= this.gameObject.GetComponent<Renderer>().material.color;
            Color32 colorOrb= other.gameObject.GetComponent<Renderer>().material.color;
            if(this.gameObject.transform.position.y<15)
            {
                if(colorPlayer.r==colorOrb.r)
                {
                    score+=10;
                    GetComponents<AudioSource>()[3].Play();

                }
                else{
                    if(score>0)
                        score-=5;
                    GetComponents<AudioSource>()[4].Play();

                }
            }
            else{
                if(colorPlayer.r!=colorOrb.r)
                {
                    score+=10;
                    GetComponents<AudioSource>()[3].Play();
                }
                else{
                    if(score>0)
                        score-=5;
                        GetComponents<AudioSource>()[4].Play();

                }
            }
            Destroy(other.gameObject);
        }
        ScoreText.text= "Score: "+score;
        HpText.text="Health Points: "+hp;
        speed=(10+(score/50)*10>speed)?10+(score/50)*10:speed;
    }
    public void quitButton()
    {
        Application.Quit();

    }
    public void resumeButton()
    {
        Resume();

    }
    public void restartButton()
    {
        SceneManager.LoadScene("SampleScene");
        Resume();

    }
    public void startButton()
    {
        mainMenuUI.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        Resume();

    }
    
}


