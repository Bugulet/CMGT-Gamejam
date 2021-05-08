using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourGlassColor : MonoBehaviour
{
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer= GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSceneManager.PlayerHealth == 5)
        {
            Color emissiveColor =new Color(0, 1, 0);
            renderer.material.SetColor("_EmissiveColor", emissiveColor);
        }
        if (CurrentSceneManager.PlayerHealth == 4)
        {
            Color emissiveColor = new Color(0.6608964f, 1, 0);
            renderer.material.SetColor("_EmissiveColor", emissiveColor);
        }
        if (CurrentSceneManager.PlayerHealth == 3)
        {
            Color emissiveColor = new Color(1, 0.9312868f, 0);
            renderer.material.SetColor("_EmissiveColor", emissiveColor);
        }
        if (CurrentSceneManager.PlayerHealth == 2)
        {
            Color emissiveColor = new Color(1, 0.4700873f, 0);
            renderer.material.SetColor("_EmissiveColor", emissiveColor);
        }
        if (CurrentSceneManager.PlayerHealth == 1)
        {
            Color emissiveColor = new Color(1, 0, 0);
            renderer.material.SetColor("_EmissiveColor", emissiveColor);
        }

    }
}
