using TMPro;
using UnityEngine;

public class WinPointsDisplay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TMP_Text>().text = PlayerPrefs.GetInt("points").ToString();
        PlayerPrefs.SetInt("points", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
