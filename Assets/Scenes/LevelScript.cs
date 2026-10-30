using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public static LevelScript LevelInstance;

    public DoorScript fireDoor;
    public DoorScript waterDoor;


    //adding level complete audio
    AudioSource audioSource;
    public AudioClip levelCompleteSound;
    bool islevelComplete;

    void Awake()
    {
        LevelInstance = this;
        audioSource = GetComponent<AudioSource>();
    }

    //whenever a player reaches door checks if both players at door
    public void CheckWin()
    {
        if (fireDoor.playerInsideDoor && waterDoor.playerInsideDoor)
        {
            //fixing problem so audio doesnt repeat endlessly
            if (islevelComplete)
            {
                return;
            }
            islevelComplete = true;

            //audio doesnt overlap
            audioSource.PlayOneShot(levelCompleteSound);
            //goes to level select after beating level
            Invoke("GoToLevelSelect", 2f);
            //SceneManager.LoadScene("LevelSelect");
        }
    }

    //after winning goes to level select
    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");

    }
}