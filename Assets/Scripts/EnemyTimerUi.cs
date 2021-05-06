using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyTimerUi : MonoBehaviour
{
    [SerializeField]
    private Image TimerImage;
    private EnemyProperties enemyProperties;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        enemyProperties = transform.parent.GetComponent<EnemyProperties>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerImage.fillAmount = (float)(enemyProperties.CountDownValue / enemyProperties.Lifespan);
        //print((float)(enemyProperties.Lifespan / enemyProperties.CountDownValue));
        transform.LookAt(mainCamera.transform);
    }
}
