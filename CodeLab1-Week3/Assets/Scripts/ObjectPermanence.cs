using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectPermanence : MonoBehaviour
{
    public static ObjectPermanence instance;
    public int currentLevel = 0;
    public TMP_Text scoreText;
    private string defaultScoreText = "Interactions: <score>";
    //using this to helps avoid errors due to typos
    const string KeyScore = "Score";
    //variable for current score
    private int score;
    //the property that will modify the variable score
    public int Score
    {
        set
        {   
            Debug.Log("You have interacted with:" + value +" strangers");
            //I'm going to use playerprefs
            score = value;
            PlayerPrefs.SetInt(KeyScore, score);
        }
        get
        {
            score = PlayerPrefs.GetInt(KeyScore);
            Debug.Log("You have interacted with a total of:" + score + " strangers");
            return score;
        }
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score = 0;
        //checks to see if the instance exists
        if (instance == null)
        {
            //if instance does not exist this line sets it
            instance = this;
            //object will not be destroyed in next scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //but if another instance exists this one gets destroyed
            Debug.Log("There can be only one.");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        string updatedScoreText = defaultScoreText;

        // Replace placeholders with current values
        updatedScoreText = updatedScoreText.Replace("<score>", Score + ""); //always use the property to make sure the value is properly loaded
        //updatedScoreText = updatedScoreText.Replace("<high>", HighScore + "");

        // Update the UI text if assigned (avoid null reference)
        if (scoreText != null)
        {
            scoreText.text = updatedScoreText;
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            Debug.Log("Scene Change has been triggered.");
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
            

        }
    }
}
