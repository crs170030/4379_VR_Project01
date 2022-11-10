using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysicsController : MonoBehaviour
{
    public Transform parentObject;

    void Update()
    {
        //go to current hand position(and rotation?)
        transform.position = parentObject.transform.position;

        //rotate block to hand's rotation
        transform.LookAt(parentObject.forward);
    }
}
