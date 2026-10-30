using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    //When press play leads to level select screen
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //takes player to selected level
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}