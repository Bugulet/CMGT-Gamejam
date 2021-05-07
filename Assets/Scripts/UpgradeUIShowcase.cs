using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeUIShowcase : MonoBehaviour
{
    public bool bullet, aoe, wall;
    public GameObject backgroundImage;
    public List<Sprite> currentImages;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            currentImages.Add(transform.GetChild(i).GetComponent<Image>().sprite);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if(ShootingScript.bulletLevel > i + 1)
                {
                    transform.GetChild(i).gameObject.GetComponent<Image>().sprite = currentImages[i];
                }
                else
                {
                    transform.GetChild(i).gameObject.GetComponent<Image>().sprite = backgroundImage.GetComponent<Image>().sprite;
                }
            }
        }
        if (aoe)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (ShootingScript.aoeLevel > i + 1)
                {
                    transform.GetChild(i).gameObject.GetComponent<Image>().sprite = currentImages[i];
                }
                else
                {
                    transform.GetChild(i).gameObject.GetComponent<Image>().sprite = backgroundImage.GetComponent<Image>().sprite;
                }
            }
        }
        if (wall)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (ShootingScript.lineLevel > i + 1)
                {
                    transform.GetChild(i).gameObject.GetComponent<Image>().sprite = currentImages[i];
                }
                else
                {
                    transform.GetChild(i).gameObject.GetComponent<Image>().sprite = backgroundImage.GetComponent<Image>().sprite;
                }
            }
        }
    }
}
