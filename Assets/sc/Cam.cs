using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour {

    float moveSpeedMax;
    float moveSpeedMin;
    float rotSpeed;
    bool isPressed;
    Vector3 oldPos;

    Vector2 rangeX;
    Vector2 rangeY;
    Vector2 rangeZ;

    Vector2 rangeRotX;
    Vector2 rangeRotY;

    void Start () {
        isPressed = false;
        moveSpeedMax = 0.024f;
        moveSpeedMin = 0.008f;
        rotSpeed = 0.035f;
        rangeX = new Vector2(-37, 37);
        rangeY = new Vector2(15, 55);
        rangeZ = new Vector2(-77, 20);
        rangeRotX = new Vector2(40, 80);
        rangeRotY = new Vector2(-45, 45);
    }
	
	void Update () {
        MoveCam();
        ScrollCam();
        rotateCam();
        oldPos = Input.mousePosition;
        CheckRange();
    }

    void MoveCam()
    {
        if (Input.GetMouseButton(0)) {
            if (Input.mousePosition == oldPos){
                return;
            }

            
            Vector3 moveVector = Input.mousePosition - oldPos;
            moveVector *= getSpeed();
            Vector2 worldV2;
            worldV2.y = moveVector.x * Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad) + moveVector.y * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
            worldV2.x = moveVector.x * Mathf.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad) + moveVector.y * Mathf.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
            transform.position = new Vector3(transform.position.x - worldV2.x, transform.position.y, transform.position.z - worldV2.y);
        }
    }

    void ScrollCam()
    {
        float scrollValue = Input.mouseScrollDelta.y;
        if (scrollValue == 0)
            return;
        if (Mathf.Sign(scrollValue) == 1)
        {
            StopAllCoroutines();
            StartCoroutine(scrollingCam(true));
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(scrollingCam(false));
        }
    }

    IEnumerator scrollingCam(bool Isdown)
    {
        float currentY = transform.position.y;
        float targetY = Isdown ? (currentY - 8) : (currentY + 8);
        float speed = 6;
        while (true)
        {
            currentY = Mathf.Lerp(currentY, targetY, Time.unscaledDeltaTime * speed);

            transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
            CheckRange();
            if (Mathf.Abs(currentY - targetY) < 0.001f)
                yield break;
          
            yield return null;
        }
    }


    void rotateCam()
    {
        if (Input.GetMouseButton(1))
        {
            float rotY = Input.mousePosition.x - oldPos.x;
            float rotX = Input.mousePosition.y - oldPos.y;
            rotY *= rotSpeed;
            rotX *= rotSpeed;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x + rotX, transform.rotation.eulerAngles.y + rotY, transform.rotation.eulerAngles.z);
        }
    }

    void CheckRange()
    {
        float newX = Mathf.Clamp(transform.position.x, rangeX.x, rangeX.y);
        float newY = Mathf.Clamp(transform.position.y, rangeY.x, rangeY.y);
        float newZ = Mathf.Clamp(transform.position.z, rangeZ.x, rangeZ.y);

        transform.position = new Vector3(newX, newY, newZ);

        float newRotX = Mathf.Clamp(transform.rotation.eulerAngles.x, rangeRotX.x, rangeRotX.y);

        //float newRotY = transform.rotation.eulerAngles.y;
        //if (transform.rotation.eulerAngles.y > rangeRotY.y && transform.rotation.eulerAngles.y < 360 + rangeRotY.x) {
        //    if(Mathf.Abs(transform.rotation.eulerAngles.y - rangeRotY.y) < Mathf.Abs(transform.rotation.eulerAngles.y - 360 + rangeRotY.x))
        //        newRotY = rangeRotY.y;
        //    else
        //        newRotY = rangeRotY.x;
        //}
          

        transform.rotation = Quaternion.Euler(newRotX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    float getSpeed()
    {
        float posYinScale = transform.position.y / rangeY.y ;
        return Mathf.Lerp(moveSpeedMin, moveSpeedMax, posYinScale);
    }
}
