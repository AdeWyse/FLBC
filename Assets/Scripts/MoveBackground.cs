using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    //position variables
    private float xPosition;
    public float comparationPos;
    public float initialPos;

    public float movingSpeed = 30f;

    public GameObject player;
    private bool moving;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()

    {
        moving = player.GetComponent<PlayerScript>().isMoving;
        MoveBackgd();
       
    }
    //moves the background until it reaches the end, then restarts from the begining in a loop. Leaves space for the othe background to "fuse" the two loops
    public void MoveBackgd()
    {
        if (moving)
        {
            if (transform.position.x > comparationPos)
            {
                xPosition = transform.position.x - movingSpeed * Time.deltaTime;

                transform.position = new Vector3(xPosition, transform.position.y, 1);
            }
            else if (transform.position.x <= comparationPos)
            {
                transform.position = new Vector3(initialPos, transform.position.y, 1);
            }
        }
    }
}
