using System.Collections;
using System.Collections.Generic;
using Lights;
using UnityEngine;

public class LightTrigger_LowerLane : MonoBehaviour
{
    private GameObject gameobject;
    private LightScript lightScript;

    private GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    void Start()
    {
        //LightScriptのアクセス
        gameobject = transform.parent.gameObject;
        lightScript = gameobject.GetComponent<LightScript>();

        //MainSystemのアクセス
        mainSystem = GameObject.FindGameObjectWithTag("MainSystem");
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }

    //動作
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.CompareTag("Ball"))
        {
            if (lightScript.isLight)
            {
                lightScript.SetLight(false);
                mainSystemScript.AddScore(20000);
            }
            else
            {
                mainSystemScript.AddScore(10000);
            }
        }
    }
}
