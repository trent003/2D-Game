using UnityEngine;

public class DoorScript : MonoBehaviour
{
    //determine which player can use door
    public string whichPlayer;

    //switch from close to open
    public Sprite closedDoorSprite;
    public Sprite openDoorSprite;

    public bool startDoorLocked = true;

    //check if play is standing in doorway
    public bool playerInsideDoor;

    bool doorIsOpen;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        doorIsOpen = !startDoorLocked;

        //checking if door should be open or closed and have the correct sprite based off that
        if (doorIsOpen)
        {
            sr.sprite = openDoorSprite;

        }
        else
        {
            sr.sprite = closedDoorSprite;
        }
    }

    //used when key is picked up to open door
    public void Open()
    {
        doorIsOpen = true;
        sr.sprite = openDoorSprite;
    }

    //checking correct player is at correct door
    void OnTriggerEnter2D(Collider2D player)
    {
        //asking if both players are standing at their open doors to win level
        if (doorIsOpen && player.CompareTag(whichPlayer))
        {
            playerInsideDoor = true;
            
            LevelScript.LevelInstance.CheckWin();
        }
    }

    //checking if player leaves being in front of door
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag(whichPlayer))
        {
            playerInsideDoor = false;
        }
    }
}
