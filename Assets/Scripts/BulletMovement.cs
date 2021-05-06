using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    [SerializeField]
    private float Speed = 1f;

    public int MaxPassThrough = 2;
    private float currentPassThrough = 0;


    void Start()
    {
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentPassThrough++;
            if (currentPassThrough >= MaxPassThrough)
            {
                Destroy(gameObject);
            }
        }
    }

}
