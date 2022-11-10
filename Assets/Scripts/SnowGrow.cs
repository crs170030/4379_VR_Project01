using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowGrow : MonoBehaviour
{
    public float startRadius = 0.2f;
    public float sizeLimit = 0.8f;
    public float grabLimit = 0.5f;
    public float rateOfChange = 0.1f;
    public float minSpeed = 0.1f;
    public float rateOfMassChange = 0.01f;

    public GameObject socketGroup = null;
    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;
    PlayQuickSound soundPlayer = null;
    ProgressController progControl;

    bool isGrounded = false;
    Vector3 scaleChange;
    Rigidbody _rb;

    void Start()
    {
        //get rigidbody component
        _rb = GetComponent<Rigidbody>();
        //set snowball rate of change
        scaleChange = new Vector3(rateOfChange, rateOfChange, rateOfChange);
        //set snowball to starting size
        transform.localScale = new Vector3(startRadius, startRadius, startRadius);
        //get sound component
        soundPlayer = GetComponent<PlayQuickSound>();
        //get ref to progress controller
        progControl = FindObjectOfType<ProgressController>();
        //turn off item sockets
        if(socketGroup != null)
            socketGroup.SetActive(false);
    }

    void FixedUpdate()
    {
        GrowCheck();

        //UnGrabbable();
    }

    void GrowCheck()
    {
        //update ground distance to size of new snowball
        groundDistance = transform.localScale.x; //keep to localScale or divide by 2?

        //check if snowball is on the ground (snow layer)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && transform.localScale.x < sizeLimit)
        {
            //Debug.Log("Snowball has made contact with ground. scale=" + transform.localScale + " velocity= " + _rb.velocity);
            //check velocity
            if (Mathf.Abs(_rb.velocity.x) > minSpeed || Mathf.Abs(_rb.velocity.y) > minSpeed || Mathf.Abs(_rb.velocity.z) > minSpeed)
            {
                //apply scale change
                transform.localScale += scaleChange;
                //apply weight change
                _rb.mass += rateOfMassChange;
                //Debug.Log("Snowball size increased to :" + transform.localScale + " velocity= " + _rb.velocity);
            }
            if (transform.localScale.x >= sizeLimit)
            {
                TurnOnSockets();
            }
        }
    }

    void TurnOnSockets()
    {
        if (socketGroup != null && socketGroup.activeSelf == false)
        {
            socketGroup.SetActive(true);

            //call progress script
            progControl.Progress(this);

            //play sfx
            if (soundPlayer != null)
                soundPlayer.Play();
        }
    }

    void UnGrabbable()
    {
        if(transform.localScale.x > grabLimit)
        {
            // doesn't work because xrgrabinteractable is in the package not in assets so
            // unity doesn't recognize it as a component
            //GetComponent<XRGrabInteractable>().enabled = false;
        }
    }
}
