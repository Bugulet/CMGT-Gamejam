using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonScript : MonoBehaviour
{
    public bool bullet, aoe, wall;
    private ShootingScript shootingScript;
    private ShopScript shopScript;
    // Start is called before the first frame update
    void Start()
    {
        shopScript = FindObjectOfType<ShopScript>();
        shootingScript = FindObjectOfType<ShootingScript>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void IncrementLevel()
    {
        if (shopScript.skillPointsLeft > 0)
        {
            if (bullet)
            {
                shootingScript.IncrementBullet();
            }
            if (aoe)
            {
                shootingScript.IncrementAOE();
            }
            if (wall)
            {
                shootingScript.IncrementLine();
            }
            shopScript.skillPointsLeft--;
        }
    }
}
