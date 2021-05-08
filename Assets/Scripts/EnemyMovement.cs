using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1;
    [HideInInspector]
    public float SpeedMultiplier = 1;
    private Transform Player;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<CharacterMovement>().gameObject.transform;
        InvokeRepeating("ResumeSpeed",0,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (SpeedMultiplier < 1f)
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }
        if (transform.GetChild(0).gameObject.activeSelf == true)
        {
            transform.LookAt(Player);
            transform.Translate(Vector3.forward * Speed * SpeedMultiplier * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (transform.GetChild(0).gameObject.activeSelf == true)
        {
            //print(collision.gameObject.name);
            if (collision.gameObject.CompareTag("PlayerProjectile"))
            {
                SpeedMultiplier -= ShootingScript.bulletDamage;
            }

            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(true);

            if (SpeedMultiplier < 0.1f)
            {
                SpeedMultiplier = 0.1f;
            }

            if (collision.gameObject.tag == "Player")
            {
                print(CurrentSceneManager.PlayerHealth);
                CurrentSceneManager.PlayerHealth--;
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(2).gameObject.SetActive(true);
                Destroy(gameObject, 1);
                //TODO: add explosion animation for enemy here
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (transform.GetChild(0).gameObject.activeSelf == true)
        {
            if (other.gameObject.CompareTag("PlayerAOE"))
            {
                SpeedMultiplier -= ShootingScript.aoeDamage * Time.deltaTime;
            }
            if (other.gameObject.CompareTag("PlayerWall"))
            {
                SpeedMultiplier -= ShootingScript.lineDamage * Time.deltaTime;
            }
            if (SpeedMultiplier < 0.1f)
            {
                SpeedMultiplier = 0.1f;
            }
        }
    }

    void ResumeSpeed()
    {
        SpeedMultiplier += 0.1f;
        if (SpeedMultiplier > 1)
        {
            SpeedMultiplier = 1;
        }
    }
}
