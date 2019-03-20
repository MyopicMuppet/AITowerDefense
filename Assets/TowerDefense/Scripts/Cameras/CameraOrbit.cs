using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    public Transform target;
    //Distance the camera is from world zero
    public float distance = 10f;
    //X and Y rotation speed
    public float xSpeed = 120f, ySpeed = 120f;
    //X and Y rotation limits
    public float yMin = 15f, yMax = 80f;
    //Store current x and y rotation
    private float x, y;

    void Start()
    {
        Vector3 euler = transform.eulerAngles;
        x = euler.y;
        y = euler.x;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        //If the left right mouse button is pressed
        if (Input.GetMouseButton(1))
        {

            // Get input X and Y offset
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            //Offset rotation with mouse X and Y
            x += mouseX * xSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                y -= mouseY * ySpeed * Time.deltaTime;
            }
            y -= mouseY * ySpeed * Time.deltaTime;
            //Clamp the Y between min and max limits
            //y = Mathf.Clamp(y, yMin, yMax);
        }
        //Update transform
        transform.rotation = Quaternion.Euler(y, x, 0);
        transform.position = -transform.forward * distance;
    }
}
