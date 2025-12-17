using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferToNextScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnLoad;
    }

    void OnLoad(Scene scene, LoadSceneMode mode)
    {
        print(scene.name);
        if (scene.name == "WinScene")
        {
            Destroy(gameObject);
        }
    }
}
