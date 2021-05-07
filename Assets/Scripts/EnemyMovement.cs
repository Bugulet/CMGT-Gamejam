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
        transform.LookAt(Player);
        transform.Translate(Vector3.forward * Speed * SpeedMultiplier * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            SpeedMultiplier -= ShootingScript.bulletDamage;
        }
        

        if (SpeedMultiplier < 0.1f)
        {
            SpeedMultiplier = 0.1f;
        }

        if (collision.gameObject.tag == "Player")
        {
            CurrentSceneManager.PlayerHealth--;
            Destroy(gameObject);
            //TODO: add explosion animation for enemy here
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAOE"))
        {
            SpeedMultiplier -= ShootingScript.aoeDamage*Time.deltaTime;
        }
        if (other.gameObject.CompareTag("PlayerWall"))
        {
            SpeedMultiplier -= ShootingScript.lineDamage*Time.deltaTime;
        }
        if (SpeedMultiplier < 0.1f)
        {
            SpeedMultiplier = 0.1f;
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
