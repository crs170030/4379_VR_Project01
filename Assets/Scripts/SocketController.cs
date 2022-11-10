using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script enables gameobjects according to the passed along value
public class SocketController : MonoBehaviour
{
    //this is basically a seperate script so all the inspector components are in one place

    public GameObject midSnowball;
    public GameObject headSnowball;
    public GameObject armSockets;
    public GameObject eyeSockets;
    public GameObject mouthSockets;
    public GameObject noseSockets;
    public GameObject hatSockets;

    void Start()
    {
        //disable all the sockets and objects
        if (midSnowball != null)
            midSnowball.SetActive(false);
        if (headSnowball != null)
            headSnowball.SetActive(false);
        if (armSockets != null)
            armSockets.SetActive(false);
        if (eyeSockets != null)
            eyeSockets.SetActive(false);
        if (mouthSockets != null)
            mouthSockets.SetActive(false);
        if (noseSockets != null)
            noseSockets.SetActive(false);
        if (hatSockets != null)
            hatSockets.SetActive(false);
    }

    public void EnableObjects(int stepNum)
    {
        switch (stepNum)
        {
            case 3:
                if (midSnowball != null)
                    midSnowball.SetActive(true);
                break;

            case 5:
                if (headSnowball != null)
                    headSnowball.SetActive(true);
                break;

            case 7:
                if (armSockets != null)
                    armSockets.SetActive(true);
                break;

            case 8:
                if (eyeSockets != null)
                    eyeSockets.SetActive(true);
                break;

            case 9:
                if (mouthSockets != null)
                    mouthSockets.SetActive(true);
                break;

            case 10:
                if (noseSockets != null)
                    noseSockets.SetActive(true);
                break;

            case 11:
                if (hatSockets != null)
                    hatSockets.SetActive(true);
                break;

            default: break;
        }
    }
}
