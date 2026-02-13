using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectPermanence : MonoBehaviour
{
    //static means it doesn't change for all instances of it
    public static ObjectPermanence instance;
    //goes by numbered order in the build rather than scene name
    public int currentLevel = 0;
    public TMP_Text scoreText;
    private string defaultScoreText = "Interactions: <score>";
    private string updatedScoreText;
    //constant means the variable type will always be the same
    //averts problems due to typos
    //KeyScore saves data to PlayerPrefs
    const string KeyScore = "Score";
    //variable for current score
    private int score;
    //the property that will modify the score variable
    public int Score
    {
        get //reading
        {
            //retrieves score from PlayerPrefs
            score = PlayerPrefs.GetInt(KeyScore); 
            Debug.Log("You have interacted with a total of " + score + " strangers");
            //returns value of score variable
            return score;
        }
        set  //writing
        {   
            
            //I'm going to use PlayerPrefs
            //sets score variable to value of property Score
            score = value;
            Debug.Log("You have interacted with " + value +" strangers");
            PlayerPrefs.SetInt(KeyScore, score);
            //can add juice here
        }
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //starting with a Score value of zero
        Score = 0;
        //call the singleton at Start
        //this script bundles the player and game manager as one singleton
        //this may be a mistake
        //checks to see if the instance exists
        if (instance == null)
        {
            //if instance of THIS class does not exist this line sets it
            instance = this;
            //object will not be destroyed in next scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //but if another instance of this class exists this one gets destroyed
            Debug.Log("There can be only one.");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    //this score is constantly updating in the console
    //so will move this to the property and create an update score function
    void Update()
    {
        updatedScoreText = defaultScoreText;
        // Replace placeholders with current values 
        updatedScoreText = updatedScoreText.Replace("<score>", Score.ToString()); 
        //always use the property to make sure the value is properly loaded

        // Update the UI text if assigned (avoid null reference)
        if (scoreText != null)
        {
            scoreText.text = updatedScoreText;
        }
    }
    //function for changing scenes
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            Debug.Log("Scene Change has been triggered.");
            //goes to the next level by number order in build
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
            

        }
    }
}
