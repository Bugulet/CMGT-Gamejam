using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperties : MonoBehaviour
{
    public float LifespanRandomizer = 1;
    public float Lifespan=5;
    [HideInInspector]
    public float CountDownValue;
    // Start is called before the first frame update
    void Start()
    {
        Lifespan += Random.Range(-LifespanRandomizer, +LifespanRandomizer);
        CountDownValue = Lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        CountDownValue -= Time.deltaTime;
        if (CountDownValue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
