using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    //internal use variables
    private Rigidbody2D rb;
    private float yPosition;
    public float verticalVelocity = 8;
    private Vector3 initialPos = new Vector3(-13.5f, -3.54f, 1);
    public bool isMoving;


    //UI and SFX variables
    private SpriteRenderer spriteRender;
    public AudioSource audioCrash;
    public AudioSource audioJump;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        spriteRender = gameObject.GetComponent<SpriteRenderer>();
        //freezes the rigidbody to start the game on the ground
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        
        isMoving = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        Jump();
        Limits();


    }
    // unfreezes the player and controls the jumps
    void Jump()
    {
        if (isMoving)
        {
            spriteRender.enabled = true;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            
        }
        if (isMoving &&  Input.GetMouseButtonDown(0) /*Input.touchCount > 0*/)
        {
           
            rb.AddForce(Vector2.up * verticalVelocity, ForceMode2D.Impulse);
            audioJump.Play();



        }
    }
    //checks to see if the player is inside the screen, and creates a barrier by aplying force on the other direction to keep the player inside and of the "ground"
    void Limits()
    {
        yPosition = transform.position.y;

        if (yPosition < -3.34)
        {
            rb.AddForce(Vector2.up * 0.5f , ForceMode2D.Impulse);

        }
        if (yPosition > 5)
        {
            rb.AddForce(Vector2.down, ForceMode2D.Impulse);

        }
    }
    //Checks for colision with the obstacles, ends the game if one happens, sets the initial position and plays hit audio 
    void OnCollisionEnter2D(Collision2D collision)
    {
        isMoving = false;
        spriteRender.enabled = false;
        transform.position = initialPos;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;


        audioCrash.Play();
       
    }
}
