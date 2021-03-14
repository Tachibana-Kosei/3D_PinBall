using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class LeftFlipper : MonoBehaviour
{
    public float spring = 4000;
    public float openAngle = 60;
    public float closeAngle = -35;

    private HingeJoint hjL;

    private JointSpring jL;

    // Start is called before the first frame update
    void Start()
    {
        GameObject LeftFlipper = GameObject.Find("CylinderL");

        hjL = LeftFlipper.GetComponent<HingeJoint>();

        hjL.useSpring = true;

        jL = hjL.spring;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            jL.spring = spring;
            jL.targetPosition = openAngle;
            hjL.spring = jL;
        }
        if (Input.GetKeyUp("f"))
        {
            jL.spring = spring;
            jL.targetPosition = closeAngle;
            hjL.spring = jL;
        }
    }
}
