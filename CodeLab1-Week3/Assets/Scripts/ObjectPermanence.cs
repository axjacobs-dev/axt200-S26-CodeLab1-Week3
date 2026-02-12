using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPermanence : MonoBehaviour
{
    public static ObjectPermanence instance;
    public int currentLevel = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
