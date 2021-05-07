using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUIShowcase : MonoBehaviour
{
    public bool bullet, aoe, wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(ShootingScript.bulletLevel>i+1);
            }
        }
        if (aoe)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(ShootingScript.aoeLevel > i + 1);
            }
        }
        if (wall)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(ShootingScript.lineLevel > i + 1);
            }
        }
    }
}
