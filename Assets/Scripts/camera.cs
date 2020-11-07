using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private bool thirdPerson;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Sphere");
        thirdPerson = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            thirdPerson=!thirdPerson;
            if(thirdPerson)
               { 
                   this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x-15,30,-40);
                //    this.gameObject.transform.Rotate(0,90,0, Space.Self);
               }
            else
            {
                this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x-15,player.gameObject.transform.position.y+3,4);
                // this.gameObject.transform.Rotate(0,0,0);

            }

        }
        if(player.gameObject.transform.position.y<10)
            this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x-15,player.gameObject.transform.position.y+3,this.gameObject.transform.position.z);
        else 
            this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x-17,player.gameObject.transform.position.y+2,this.gameObject.transform.position.z);
    
    }

}
