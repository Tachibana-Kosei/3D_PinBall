using System.Collections;
using System.Collections.Generic;
using Lights;
using UnityEngine;

public class LightTriggerFloor : MonoBehaviour
{
    GameObject gameobject;
    private GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    void Start()
    {
        gameobject = transform.parent.gameObject;
        mainSystem = GameObject.FindGameObjectWithTag("MainSystem");
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }

    //動作
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.CompareTag("Ball"))
        {
            gameobject.GetComponent<LightScript>().ToggleLight();
            mainSystemScript.AddScore(2000);
        }
    }
}
