using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1500;
    public float rotationalSpeed = 1500f;
    public WheelJoint2D backwheel;
    private float movement = 0f;
    private float rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = -Input.GetAxisRaw("Vertical")*speed; // It will return 1 for upward key( or W) & -1 for downward key(or S) or otherwise 0
        rotation = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        if (movement == 0f)
        {
            backwheel.useMotor = false;
        }
        else{
            backwheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000};
            backwheel.motor = motor;
        }
        
        rb.AddTorque(-rotation * rotationalSpeed * Time.fixedDeltaTime);
    }
}
