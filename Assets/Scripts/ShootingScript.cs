using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    static public float fireRate=3;
    static public int bulletLevel = 1, aoeLevel = 1, lineLevel = 1;
    static public float bulletDamage = 0.1f, aoeDamage = 0.2f, lineDamage = 1f;
    static public float bulletSpeed = 10, aoeTime = 3, lineTime = 3;
    static public float aoeSize = 1, lineSize = 1;
    static public bool tripleShot = false;

    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private GameObject AoEObject;
    [SerializeField]
    private GameObject WallObject;

    [SerializeField] private bool isShooting;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject player;

    [SerializeField]
    private GameObject BulletOrigin;

    public enum WeaponType{ bullet,aoe,wall};

    public WeaponType weaponType;

    private bool canShootAoE = true;
    private bool canSHootWall = true;
    

    private void ShootingUpdate()
    {
        
        if (bulletLevel > 1)
        {
            bulletDamage = 0.2f;
        }
        if (bulletLevel > 2)
        {
            tripleShot = true;
        }
        if (bulletLevel > 3)
        {
            fireRate = 6;
            bulletSpeed = 20;
        }

        if (aoeLevel > 1)
        {
            aoeSize = 1.5f;
        }
        if (aoeLevel > 2)
        {
            aoeDamage = 0.5f;
        }
        if (aoeLevel > 3)
        {
            aoeTime = 5;
        }

        if (lineLevel > 1)
        {
            lineTime = 5f;
        }
        if (lineLevel > 2)
        {
            lineSize = 1.5f;
        }
        if (lineLevel > 3)
        {
            lineDamage = 2f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        weaponType = WeaponType.bullet;
    }

    public void IncrementBullet()
    {
        bulletLevel++;
    }
    public void IncrementAOE()
    {
        aoeLevel++;
    }

    public void IncrementLine()
    {
        lineLevel++;
    }

    // Update is called once per frame
    void Update()
    {
        ShootingUpdate();

        #region Cheats
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            IncrementBullet();
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            IncrementAOE();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            IncrementLine();
        }
        #endregion



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
            playerAnimator.SetBool("isCasting", true);
            isShooting = true;
            switch (weaponType)
            {
                case WeaponType.bullet:
                    InvokeRepeating("ShootBullet",0,1f/fireRate);
                    break;
                case WeaponType.aoe:
                    if (Physics.Raycast(ray, out hit))
                    {
                        
                        if (hit.transform.gameObject.tag == "Floor" && canShootAoE==true)
                        {
                            GameObject aoe= Instantiate(AoEObject, hit.point, Quaternion.identity);
                            aoe.transform.localScale *= aoeSize;
                            aoe.GetComponent<DestroyAfterSeconds>().DestroyTime = aoeTime;
                            aoe.GetComponent<DestroyAfterSeconds>().DestroyManually();
                            canShootAoE = false;
                            Invoke("ResetAOE", aoeTime);
                        }
                    }
                   
                    break;
                case WeaponType.wall:
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.gameObject.tag == "Floor" && canSHootWall==true)
                        {
                           GameObject wall= Instantiate(WallObject, hit.point, Quaternion.identity);
                            wall.transform.rotation = gameObject.transform.rotation;
                            wall.transform.localScale *= lineSize;
                            wall.GetComponent<DestroyAfterSeconds>().DestroyTime = aoeTime;
                            wall.GetComponent<DestroyAfterSeconds>().DestroyManually();
                            canSHootWall = false;
                            Invoke("ResetWall", lineTime);
                        }
                    }
                    break;
                default:
                    break;
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke("ShootBullet");
            playerAnimator.SetBool("isCasting", false);
        }
    }

    private void ShootBullet()
    {
       
        Quaternion bulletRotation = transform.rotation;
        Quaternion bulletRotationLeft = Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y-15,transform.eulerAngles.z);
        Quaternion bulletRotationRight = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 15, transform.eulerAngles.z);

        Instantiate(Bullet, BulletOrigin.transform.position, transform.rotation);

        if (tripleShot)
        {
            Instantiate(Bullet, BulletOrigin.transform.position, bulletRotationLeft);
            Instantiate(Bullet, BulletOrigin.transform.position, bulletRotationRight);
        }
    }

    private void ResetAOE()
    {
        canShootAoE = true;
    }
    private void ResetWall()
    {
        canSHootWall = true;
    }
}
