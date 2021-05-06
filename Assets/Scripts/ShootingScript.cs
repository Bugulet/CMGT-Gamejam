using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private GameObject BulletOrigin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, BulletOrigin.transform.position, transform.rotation);
        }
    }
}
