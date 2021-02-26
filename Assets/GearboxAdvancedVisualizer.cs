using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearboxAdvancedVisualizer : MonoBehaviour
{
    public float inputAngularVelocity;

    public float inputTorque;

    public float outputAngularVelocity;

    public float outputTorque;

    public SuperGear input;

    public SuperGear output;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input.AngularVelocity = inputAngularVelocity;
        input.torque = inputTorque;
        outputTorque = output.torque;
        outputAngularVelocity = output.AngularVelocity;
    }
}
