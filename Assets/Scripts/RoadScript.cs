using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public GameObject road;
    private int roadX = 200;
    private int roadNum = 0;
    // Start is called before the first frame update
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Sphere");
        for(int i =0;i<3;i++)
       {
            Instantiate(road, new Vector3(roadX, 0, (float)4.7), Quaternion.identity);
            Instantiate(road, new Vector3(roadX, 20, (float)4.7), Quaternion.identity);
            roadX+=100;
       } 

    }

    void Update()
    {
        if (player.gameObject.transform.position.x+300 > 20 + roadNum * 100)
        {
            Instantiate(road, new Vector3(roadX, 0, (float)4.7), Quaternion.identity);
            Instantiate(road, new Vector3(roadX, 20, (float)4.7), Quaternion.identity);
            roadX += 100;
            roadNum++;
        }
    }
}
