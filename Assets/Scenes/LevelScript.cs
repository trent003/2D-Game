using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public static LevelScript LevelInstance;

    public DoorScript fireDoor;
    public DoorScript waterDoor;

    void Awake()
    {
        LevelInstance = this;
    }

    //whenever a player reaches door checks if both players at door
    public void CheckWin()
    {
        if (fireDoor.playerInsideDoor && waterDoor.playerInsideDoor)
        {
            //goes to level select after beating level
            SceneManager.LoadScene("LevelSelect");
        }
    }
}