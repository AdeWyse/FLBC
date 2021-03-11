using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   //control variables
    public GameObject player;
    public bool moving;
    
    public int points;
  

    //UI and SFX variables
    private GameObject startPannel;
    private GameObject creditsText;
    private GameObject creditsOnButton;
    private GameObject creditsOffButton;
    private TextMeshProUGUI displayScore;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
       
        startPannel = GameObject.Find("StartPanel");
        creditsText = GameObject.Find("CreditsText");
        creditsOnButton = GameObject.Find("Credits");
        creditsOffButton = GameObject.Find("Credits Off");
        displayScore = GameObject.Find("HighScoreValue").GetComponent<TextMeshProUGUI>();
        displayScore.text = PlayerPrefs.GetInt("Score").ToString();

        //deactivates the credits at the start
        creditsText.SetActive(false);
        creditsOffButton.SetActive(false);
        

        points = 0;


    }

    // Update is called once per frame
    void Update()
    {
        moving = player.GetComponent<PlayerScript>().isMoving;
        EndGame();



    }
    //adds 1 point for each obstacle destroied
    public void UpdateScore(int scoreToAdd)

    { 
            points += scoreToAdd;
    }
    //Makes the player start to move, the UI to vanish and music play
    public void StartGame()
    {
        player.GetComponent<PlayerScript>().isMoving = true;

        startPannel.SetActive(false);
        music.Play();
    }
    // the opost of the StartGame
    public void EndGame()
    {   // Does the highscore checking and setting
        if (!moving)
        {
            if (points > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", points);
                displayScore.text = PlayerPrefs.GetInt("Score").ToString();
            }

           
            player.GetComponent<PlayerScript>().isMoving = false;
            startPannel.SetActive(true);
            music.Stop();
            points = 0;
        }

    }
    //Shows the credits, turns the Off button on and dissables the On button
    public void CreditsOn()
    {
        creditsText.SetActive(true);
        creditsOnButton.SetActive(false);
        creditsOffButton.SetActive(true);
    }
    // the opost of the CreditsOn
    public void CreditsOff()
    {
        creditsText.SetActive(false);
        creditsOffButton.SetActive(false);
        creditsOnButton.SetActive(true);

    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Score");
        displayScore.text = "0";
    }

}
