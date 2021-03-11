using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
   // variables for internal use
    public float horizontalVelocity = 8f;
    public bool moving;
  
     public GameObject player;
   //variables for external use
    public int fpoints;
    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //sets the game as ongoing, so everytime a obstacle is destroyed it won't interfere with the score
         
    }

    // Update is called once per frame
    void Update()
    {
        moving = player.GetComponent<PlayerScript>().isMoving;
        Move();
        
    }
    //moves the object while the player is moving and cleans the screen when the game is over or the object is outside the screen
     void Move()
    {
        if (moving)
        {
            Vector2 movement = new Vector2(-1 * horizontalVelocity * Time.deltaTime, 0);
            transform.Translate(movement);
           
        }
       else
        {
           Object.Destroy(gameObject);
           
       }
        //destroys the obstacle when it passes the player
        if (transform.position.x < -15.48)
        {
            Object.Destroy(gameObject);
        }

    }
    //adds points at the end of the game for every object that was destroie after passing the player
    private void OnDestroy()
    {
        
        fpoints = gameManager.GetComponent<GameManager>().points;
        if (moving)
        {
            gameManager.UpdateScore(1);
        }
        
      
    }

}
