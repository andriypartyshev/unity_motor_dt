using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Animations;


public enum JointDirection
{
    PASS_THROUGH=1,
    STRAIGHT=0,
    REVERSE=-1
}

public enum GearApplication{
    Guided,
    Unguided,
    ScaleBased
}


//[RequireComponent(typeof(Rigidbody))]
public abstract class SuperGear : MonoBehaviour
{
    public bool Invert;
    public int ToothCount;
    public float DiameterMillimiters;
    public float ThicknessMillimiters;
    public List<SuperGear> JointGears;
    public List<JointDirection> Direction;
    public float AngularVelocity;
    public Axis axis;
    public GearApplication app;
    public float torque;
    
    public float ratio=1f;
    //public float ratioPrint=1f;
    
    public bool printer;
    protected Vector3 rotate;
    protected Rigidbody r;
    protected Transform t;
    
    
    // Start is called before the first frame update
    protected void Start()
    {
        rotate = new Vector3();
        
        r = gameObject.GetComponent<Rigidbody>();
        t = gameObject.GetComponent<Transform>();
        if(r!=null)
            r.maxAngularVelocity = Mathf.Infinity;

        switch (app)
        {
            case GearApplication.Guided:
                DiameterMillimiters = t.localScale.x * 100f;
                ThicknessMillimiters = t.localScale.z * 100f;
                break;
            case GearApplication.Unguided:
                break;
            case GearApplication.ScaleBased:
                
                Vector3 scale;
                scale.x = DiameterMillimiters / 100f;
                scale.y = DiameterMillimiters / 100f;
                scale.z = ThicknessMillimiters / 100f;
                t.localScale = scale;
                break;
            
        }
        
    }

  
}
