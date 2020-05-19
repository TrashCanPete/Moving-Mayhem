using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Driving : MonoBehaviour
{
    [System.Serializable]
    public class Wheel
    {
        [HideInInspector]public string name = "Rear Wheel";
        public WheelController wheelScript;

        public Wheel(string _name)
        {
            name = "test";
        }
    }
    public float enginePower;
    public float reversePower;
    public float brakePower;
    public bool Reversing { get; private set; }
    public bool IsGrounded { get; private set; }
    [Tooltip("Front wheels of the car.")]
    public Wheel[] frontWheels = new Wheel[2] { new Wheel("Left"), new Wheel("Right") };
    [Tooltip("Rear wheels of the car. You can have any number of wheels provided it is at least more than one.")]
    public WheelController[] rearWheels;
    [Tooltip("Allows you to adjust the engines power at different speeds. The Y axis represents power and the X axis represents current speed.")]
    [SerializeField] AnimationCurve powerBySpeed;
    [Range(0, 1)] [Tooltip("0 for front wheels drive, 1 for rear wheel drive.")] [SerializeField] float powerDistribution;
    [Range(0, 1)] [Tooltip("0 for front bias, 1 for rear bias.")] [SerializeField] float brakeBias;
    float zAxis;
    Rigidbody rb;
    Vector3 localVelocity;
    public float DriftFactor { get; private set; }
    private void Start()
    {
        NullChecks();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        zAxis = Input.GetAxis("Vertical");
    }
    void NullChecks()
    {
        ArrayList tempArray = new ArrayList();
        tempArray.AddRange(frontWheels);
        ErrorChecks.EmptyArrayCheck(tempArray, "FrontWheels");
        
        for(int i =0; i < frontWheels.Length; i++)
        {
            ErrorChecks.NullCheck(frontWheels[i].wheelScript, "FrontWheels.wheelScript");
        }

        tempArray = new ArrayList();
        tempArray.AddRange(rearWheels);
        ErrorChecks.EmptyArrayCheck(tempArray, "RearWheels");
    }
    private void FixedUpdate()
    {
        localVelocity = transform.InverseTransformVector(rb.velocity);
        if (zAxis > 0)
        {
            Reversing = false;
            ApplyPower(enginePower);
        }
        else if (zAxis < 0)
        {
            if (localVelocity.z < 0.5f)
            {
                Reversing = true;
                ApplyPower(reversePower);
            }
            else
            {
                ApplyBrake();
            }
        }
        ApplyGrip();
    }
    void ApplyGrip()
    {
        DriftFactor = 0;
        IsGrounded = false;
        for (int i = 0; i < frontWheels.Length; i++)
        {
            DriftFactor += frontWheels[i].wheelScript.SidewaysSlip;
            frontWheels[i].wheelScript.ApplyGrip(transform, DriftFactor);
            if (frontWheels[i].wheelScript.IsGrounded)
                IsGrounded = true;
        }
        for (int i = 0; i < rearWheels.Length; i++)
        {
            DriftFactor += rearWheels[i].SidewaysSlip;
            rearWheels[i].ApplyGrip(transform, DriftFactor);
            if (rearWheels[i].IsGrounded)
                IsGrounded = true;
        }
        DriftFactor /= (frontWheels.Length + rearWheels.Length);
    }
    void ApplyPower(float power)
    {
        float targetPower = powerBySpeed.Evaluate(localVelocity.z / 40);
        targetPower *= power;
        float frontPower = (targetPower * zAxis) * (1 - powerDistribution);
        float rearPower = (targetPower * zAxis) * (powerDistribution);
        frontPower /= frontWheels.Length;
        rearPower /= rearWheels.Length;
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].wheelScript.PowerMotor(frontPower);
        }
        for (int i = 0; i < rearWheels.Length; i++)
        {
            rearWheels[i].PowerMotor(rearPower);
        }
    }
    void ApplyBrake()
    {
        float frontBrakePower = brakePower * zAxis * (1 - brakeBias);
        float rearBrakePower = brakePower * zAxis * (brakeBias);
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].wheelScript.Brake(frontBrakePower);
        }
        for (int i = 0; i < rearWheels.Length; i++)
        {
            rearWheels[i].Brake(rearBrakePower);
        }
    }
}