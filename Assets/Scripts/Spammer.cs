using System.Collections;
using UnityEngine;

public class Spammer : MonoBehaviour
{   //obstacles variables
    public GameObject obstacle;
    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject[] obstacles;
    public GameObject player;
    private int obst;
    public bool moving;
    //positions variables
    private Vector3 initialPosition;
    private float minY = -2;
    private float maxY = 2;
    private float y;
    //spamming variables
    private float respamRate = 1.5f;
    public float nextSpam;
    
  




    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.Find("Player");
        obstacles= new GameObject[3];
        obstacles[0] = obstacle;
        obstacles[1] = obstacle1;
        obstacles[2] = obstacle2;
    }

    // Update is called once per frame
    void Update()
    {   //checks to see if the player is moving
        moving = player.GetComponent<PlayerScript>().isMoving;
        Spam();


    }
    //Spams a obstacle in a radom y position after 1.5 seconds
    void Spam()
    {
 
        if ( moving && Time.time > nextSpam)
        {
            y = Random.Range(minY, maxY);
            obst = Random.Range(0, 3);
            initialPosition = new Vector3(16, y, 0.5f);
            nextSpam = Time.time + respamRate;
            Instantiate(obstacles[obst], initialPosition, Quaternion.identity);
            
        }

    }
    
}
