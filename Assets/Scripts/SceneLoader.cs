using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void Quit()
    {
        print("Quitting Game...");
        Application.Quit();
    }
}
