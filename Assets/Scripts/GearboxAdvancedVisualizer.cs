using System.Collections;
using System.Collections.Generic;
using DigitalTwin.Utils.Events;
using UnityEngine;

public class GearboxAdvancedVisualizer : MonoBehaviour
{
    [Range(-20000f,20000f)]
    public float inputRPM;
    
    private float inputAngularVelocity;
    [Range(-27,27)]
    public float inputTorque;

    private float outputAngularVelocity;
    
    public  float outputRPM;

    public float outputTorque;

    public SuperGear input;

    public SuperGear output;

    private float efficeincy;
    
    public UnityEventFloat TorqueEventOutput=new UnityEventFloat();
    
    public UnityEventFloat RPMEventOutput=new UnityEventFloat();
    
    
    public UnityEventString RPMEventTextOutput=new UnityEventString();
    
    
    public UnityEventString TorqueEventTextOutput=new UnityEventString();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rpm = Mathf.Abs(inputAngularVelocity) * 60 / (2 * Mathf.PI);

        inputAngularVelocity = inputRPM * (2 * Mathf.PI) / 60f;
        input.AngularVelocity = inputAngularVelocity;
        input.torque = inputTorque;
        outputTorque = output.torque*efficeincy;
        outputAngularVelocity = output.AngularVelocity;
        outputRPM= Mathf.Abs(outputAngularVelocity) * 60 / (2 * Mathf.PI);
        TorqueEventOutput?.Invoke(outputTorque);
        RPMEventOutput?.Invoke(outputRPM);
        TorqueEventTextOutput?.Invoke(outputTorque.ToString("F2"));
        RPMEventTextOutput?.Invoke(outputRPM.ToString("F2"));
    }

    public void inputEfficiency(double value)
    {
        efficeincy = (float)value;
    }
}
