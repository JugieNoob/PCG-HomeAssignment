using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TransferToNextScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnLoad;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneLoader>().LoadGameOver();
        }
        if (Input.GetKey(KeyCode.W))
        {
            GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneLoader>().LoadWinScene();
        }
    }

    void OnLoad(Scene scene, LoadSceneMode mode)
    {
        print(scene.name);

        if (scene.name == "WinScene" || scene.name == "GameOver")
        {
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }

        }





    }
}
