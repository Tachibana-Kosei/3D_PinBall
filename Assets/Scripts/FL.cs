using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FL : MonoBehaviour
{
    public float spring = 40000;

    public float openAngle = 60;

    public float closeAngle = -20;

    private HingeJoint hj;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        hj = gameObject.GetComponent<HingeJoint>();
        hj.useSpring = true;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
