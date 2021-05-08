using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject player;
    [SerializeField] private bool isMoving = false;
    [SerializeField]
    float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            velocity.x += -1;
            isMoving = true;
            //transform.Translate(new Vector3(-1,0,0) * Speed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.x += 1;
            isMoving = true;
           // transform.Translate(new Vector3(1, 0,0) * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.z += -1;
            isMoving = true;
            //transform.Translate(new Vector3(0,0, -1) * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.z += 1;
            isMoving = true;
            //transform.Translate(new Vector3(0,0, 1) * Speed * Time.deltaTime, Space.World);
        }
        
        velocity.Normalize();
        GetComponent<Rigidbody>().AddForce(velocity * Speed * Time.deltaTime);
        //transform.Translate(velocity * Speed * Time.deltaTime, Space.World);

        if (velocity.x == 0 && velocity.z == 0)
        {
            isMoving = false;
        }

        if (isMoving == true)
        {
            playerAnimator.SetBool("isRunning", true);
        }

        else
        {
            playerAnimator.SetBool("isRunning", false);
        }
            
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point);
            transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
