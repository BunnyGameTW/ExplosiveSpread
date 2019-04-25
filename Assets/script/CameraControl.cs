using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    public float speed, scrollScale, rotateSpeed, moveSpeed;
    public Transform rotateTrans;
    float number;
    Vector3 lastMousePosition, cameraPosition;
    bool isPress = false, isRotate = false;
    float x, y=60;
    Quaternion rotateEular;
    float distance;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        //}

        number = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView -= number * scrollScale;
        if (Camera.main.fieldOfView < 1) Camera.main.fieldOfView = 60;
        else if (Camera.main.fieldOfView > 120) Camera.main.fieldOfView = 60;

        if (Input.GetMouseButtonDown(0))
            isPress = true;
        else if (Input.GetMouseButtonUp(0))
            isPress = false;

        Vector3 vec = Vector3.Normalize(lastMousePosition - Input.mousePosition);
        if (isPress) transform.position += new Vector3(vec.x * moveSpeed * Time.unscaledDeltaTime, 0, vec.y * moveSpeed * Time.unscaledDeltaTime);
        lastMousePosition = Input.mousePosition;

        if (Input.GetMouseButtonDown(1))
            isRotate = true;
        else if (Input.GetMouseButtonUp(1))
            isRotate = false;
        if(isRotate)
        {
            x += Input.GetAxis("Mouse X") * rotateSpeed * Time.unscaledDeltaTime;
            y -= Input.GetAxis("Mouse Y") * rotateSpeed * Time.unscaledDeltaTime; //+ 90;
         //   print("y" + y);
            if (x > 360) x -= 360;
            else if (x < 0) x += 360;

            if (y > 360) y -= 360;
             else if (y < 0) y += 360;
            rotateEular = Quaternion.Euler(y, x, 0);
            transform.rotation = rotateEular;
          //  cameraPosition = rotateEular * new Vector3(0, 0, 20);// + rotateTrans.position;
           // transform.position = cameraPosition;
        }
    }
}
