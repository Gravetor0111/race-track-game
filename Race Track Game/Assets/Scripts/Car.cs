using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Rigidbody carRegidbody;
    public Transform centerOfMass;

    public WheelCollider wheelFLCollider;
    public WheelCollider wheelFRCollider;
    public WheelCollider wheelRLCollider;
    public WheelCollider wheelRRCollider;

    public Transform wheelFL;
    public Transform wheelFR;
    public Transform wheelRL;
    public Transform wheelRR;

    public float motorTorque = 100f;
    public float maxSteer = 20f;
    


    void Start()
    {
        carRegidbody = GetComponent<Rigidbody>();
        carRegidbody.centerOfMass = centerOfMass.localPosition;
    }
    void FixedUpdate()
    {
        wheelRLCollider.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelRRCollider.motorTorque = Input.GetAxis("Vertical") * motorTorque;
        wheelFLCollider.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
        wheelFRCollider.steerAngle = Input.GetAxis("Horizontal") * maxSteer;
    }

    void Update()
    {
        var pos = Vector3.zero;
        var rot = Quaternion.identity;

        wheelFLCollider.GetWorldPose(out pos, out rot);
        wheelFL.position = pos;
        wheelFL.rotation = rot;

        wheelFRCollider.GetWorldPose(out pos, out rot);
        wheelFR.position = pos;
        wheelFR.rotation = rot;

        wheelRLCollider.GetWorldPose(out pos, out rot);
        wheelRL.position = pos;
        wheelRL.rotation = rot;

        wheelRRCollider.GetWorldPose(out pos, out rot);
        wheelRR.position = pos;
        wheelRR.rotation = rot;
    }
}
