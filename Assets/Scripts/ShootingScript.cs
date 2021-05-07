using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private GameObject AoEObject;
    [SerializeField]
    private GameObject WallObject;

    [SerializeField]
    private GameObject BulletOrigin;

    public enum WeaponType{ bullet,aoe,wall};

    public WeaponType weaponType;
    // Start is called before the first frame update
    void Start()
    {
        weaponType = WeaponType.bullet;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponType = WeaponType.bullet;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponType = WeaponType.aoe;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponType = WeaponType.wall;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        

        if (Input.GetMouseButtonDown(0))
        {
            switch (weaponType)
            {
                case WeaponType.bullet:
                    Instantiate(Bullet, BulletOrigin.transform.position, transform.rotation);
                    break;
                case WeaponType.aoe:
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "Floor")
                        {
                            Instantiate(AoEObject, hit.point, Quaternion.identity);
                        }
                    }
                   
                    break;
                case WeaponType.wall:
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "Floor")
                        {
                           GameObject wall= Instantiate(WallObject, hit.point, Quaternion.identity);
                            wall.transform.rotation = gameObject.transform.rotation;
                        }
                    }
                    break;
                default:
                    break;
            }

        }
    }
}
