using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class myDroneMovement : MonoBehaviour
{
    private PhotonView PV;

    Rigidbody myDrone;
    public float upForce;
    private float movementForwardSpeed = 40f;
    private float tiltAmountForward = 0f;
    private float tiltVelocityForward;

    private float wantedYrotation;
    private float currentYrotation;
    private float rotateAmountByKeys = 2.5f;
    private float rotationYVelocity;

    private Vector3 velocityToSmoothDampToZero;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
        myDrone = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        movementUPdown();
        movementForward();
        rotation();
        clampingSpeedValues();
        myDrone.AddRelativeForce(Vector3.up * upForce);
        myDrone.rotation = Quaternion.Euler(
            new Vector3(tiltAmountForward, currentYrotation ,myDrone.rotation.z)
            );
    }

    private void clampingSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            myDrone.velocity = Vector3.ClampMagnitude(myDrone.velocity, Mathf.Lerp(myDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            myDrone.velocity = Vector3.ClampMagnitude(myDrone.velocity, Mathf.Lerp(myDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            myDrone.velocity = Vector3.ClampMagnitude(myDrone.velocity, Mathf.Lerp(myDrone.velocity.magnitude, 5.0f, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            myDrone.velocity = Vector3.SmoothDamp(myDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }
    }
    private void rotation()
    {
        if (Input.GetKey(KeyCode.J))
        {
            wantedYrotation -= rotateAmountByKeys;
        }
        if (Input.GetKey(KeyCode.K))
        {
            wantedYrotation += rotateAmountByKeys;
        }
        currentYrotation = Mathf.SmoothDamp(currentYrotation, wantedYrotation, ref rotationYVelocity, 0.25f);
    }

    void movementForward()
    {
        if(Input.GetAxis("Vertical") != 0)
        {
            myDrone.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * movementForwardSpeed);
            tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * Input.GetAxis("Vertical"), ref tiltVelocityForward, 0.1f);

        }
    }

    void movementUPdown()
    {
        if (Input.GetKey(KeyCode.I))
        {
            upForce = 300;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            upForce = -300;
        }
        else if(!Input.GetKey(KeyCode.I) && !Input.GetKey(KeyCode.L))
        {
            upForce = 98.1f;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
