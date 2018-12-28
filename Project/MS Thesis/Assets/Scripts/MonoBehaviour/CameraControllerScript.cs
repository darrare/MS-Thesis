using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{
    Vector3 velocity;
    float speed = 5f;
    float speedBoostMultiplier = 3;

    float rotateSpeedH = 3.0f;
    float rotateSpeedV = 3.0f;

    float yaw = 0f;
    float pitch = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) //Forward
        {
            velocity += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A)) //Left (Strafe)
        {
            velocity += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S)) //Backwards
        {
            velocity += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D)) //Right (Strafe)
        {
            velocity += Vector3.right;
        }
        if (Input.GetKey(KeyCode.X)) //Down
        {
            velocity += Vector3.down;
        }
        if (Input.GetKey(KeyCode.Space)) //Up
        {
            velocity += Vector3.up;
        }

        if (Input.GetMouseButton(1))
        {
            yaw += rotateSpeedH * Input.GetAxis("Mouse X");
            pitch -= rotateSpeedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0);
        }


        velocity *= (Input.GetKey(KeyCode.LeftShift) ? speed * speedBoostMultiplier : speed);
        transform.Translate(velocity * Time.deltaTime, Space.Self);
           

    }
}
