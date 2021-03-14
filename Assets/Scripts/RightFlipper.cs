using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RightFlipper : MonoBehaviour
{
    public float spring = 4000;
    public float openAngle = 60;
    public float closeAngle = -35;

    private HingeJoint hjR;

    private JointSpring jR;

    // Start is called before the first frame update
    void Start()
    {
        GameObject RightFlipper = GameObject.Find("CylinderR");

        hjR = RightFlipper.GetComponent<HingeJoint>();

        hjR.useSpring = true;

        jR = hjR.spring;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            jR.spring = spring;
            jR.targetPosition = -openAngle;
            hjR.spring = jR;
        }
        if (Input.GetKeyUp("j"))
        {
            jR.spring = spring;
            jR.targetPosition = -closeAngle;
            hjR.spring = jR;
        }
    }
}
