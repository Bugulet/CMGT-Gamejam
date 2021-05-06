using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            velocity.x += -1;
            //transform.Translate(new Vector3(-1,0,0) * Speed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            velocity.x += 1;
           // transform.Translate(new Vector3(1, 0,0) * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity.z += -1;
            //transform.Translate(new Vector3(0,0, -1) * Speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity.z += 1;
            //transform.Translate(new Vector3(0,0, 1) * Speed * Time.deltaTime, Space.World);
        }
        velocity.Normalize();
        transform.Translate(velocity * Speed * Time.deltaTime, Space.World);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point);
            transform.localRotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
