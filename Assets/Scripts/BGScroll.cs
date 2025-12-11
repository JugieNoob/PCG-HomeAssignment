using UnityEngine;

public class BGScroll : MonoBehaviour
{

    Material bgMaterial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        bgMaterial.mainTextureOffset += new Vector2(0f, 0.02f) * Time.deltaTime;
    }
}
