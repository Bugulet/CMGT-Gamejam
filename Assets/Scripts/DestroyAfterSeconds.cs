using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float DestroyTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyManually()
    {
        Destroy(gameObject, DestroyTime);
    }
}
