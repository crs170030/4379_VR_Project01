using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPositionController : MonoBehaviour
{
    //the camera to teleport in front of
    public Transform cam;
    public Vector3 menuOffset = new Vector3(0,1.6f,0);
    public float menuOffsetScale = 2f;
    Vector3 defaultPosition = new Vector3(0, 1.6f, 2.251f);
    Vector3 positionToMove;

    void Start()
    {
        //reset canvas position
        transform.position = defaultPosition;
    }

    public void WarpMenu()
    {
        //transform.position = cam.transform.position + menuOffset;

        //set new position
        positionToMove = (cam.transform.forward * menuOffsetScale) + menuOffset;
        transform.position = positionToMove;

        //set new rotation
        transform.LookAt(transform.position + cam.forward);
    }
}
