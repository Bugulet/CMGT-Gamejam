using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{

    Image ImageComponent;
    // Start is called before the first frame update
    void Start()
    {
        ImageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ImageComponent.fillAmount = (float)CurrentSceneManager.PlayerHealth / CurrentSceneManager.PlayerMaxHealth;
    }
}
