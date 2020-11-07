using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 forward;
    private Vector3 side;
    private Vector3 upDown;
    public float speed;
    private int lane=1;
    bool down;


    //Collectible Vars
    private int hpInterval;
    public GameObject HPprefap;
    private int hpNum;

    
    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
        speed =5;
        down = true;

        // Collectibles
        hpInterval=10;
        hpNum=1;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
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
            }
        // Setting the auto forward speed
        forward.x=speed;
        controller.Move(forward*Time.fixedDeltaTime);


        if((Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D))&&lane<2){
            side.z=-10;
            controller.Move(side);
            lane++;

        }
        else if((Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A))&&lane>0){
            side.z=10;
            controller.Move(side);
            lane--;
        }

        //Collectibles 


        if (Time.time > hpInterval*hpNum  ) {
            int hpRandom = Random.Range(-1,2)*10;
            int randomY= Random.Range(0,2)*16;
            Instantiate(HPprefap, new Vector3((this.gameObject.transform.position.x)+90, 2+randomY, (float)4.7+hpRandom), Quaternion.identity);
            hpNum++;
        }
    }
    void FixedUpdate() {
        // Setting the Forward to be called.
    }
    
}
