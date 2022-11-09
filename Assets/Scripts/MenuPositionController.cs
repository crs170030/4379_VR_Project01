using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPositionController : MonoBehaviour
{
    //the camera to teleport in front of
    public Transform cam;
    //public Vector3 menuOffset = new Vector3(0,1.6f,0);
    public float menuOffsetScale = 2f;
    Vector3 defaultPosition = new Vector3(0, 1.6f, 2.251f);
    Vector3 positionToMove;

    void Start()
    {
        //reset canvas position
        //transform.position = defaultPosition;
    }

    public void WarpMenu()
    {
        //set new position
        //Debug.Log("cam forward == " + cam.transform.forward);
        positionToMove = cam.transform.position + (cam.transform.forward * menuOffsetScale);
        //Debug.Log("position to move == " + positionToMove);
        transform.position = positionToMove;

        //set new rotation
        transform.LookAt(transform.position + cam.forward);
    }
}
